using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VottJsonToYolo.Models;

namespace VottJsonToYolo
{
    internal class Program
    {
        static List<VottLabel> VottLabels = new List<VottLabel>();
        static List<YoloLabel> YoloLabels = new List<YoloLabel>();
        static void Main(string[] args)
        {
            #region INIT
            var vottFolderPath = @"C:\Users\serda\Documents\GitHub\JSON2YOLO\vott-json-export";
            var vottJsonFilePath = vottFolderPath + @"\Captcha-export.json";
            var outFolderPath = @"C:\Users\serda\Pictures\Neova\YoloV5Export";

            var testFolder = Path.Combine(outFolderPath, "test");
            var trainFolder = Path.Combine(outFolderPath, "train");
            var validFolder = Path.Combine(outFolderPath, "valid");

            if (Directory.Exists(outFolderPath))
            {
                Directory.Delete(outFolderPath, true);
            }

            Directory.CreateDirectory(outFolderPath);

            Directory.CreateDirectory(testFolder);
            Directory.CreateDirectory(Path.Combine(testFolder, "images"));
            Directory.CreateDirectory(Path.Combine(testFolder, "labels"));

            Directory.CreateDirectory(trainFolder);
            Directory.CreateDirectory(Path.Combine(trainFolder, "images"));
            Directory.CreateDirectory(Path.Combine(trainFolder, "labels"));

            Directory.CreateDirectory(validFolder);
            Directory.CreateDirectory(Path.Combine(validFolder, "images"));
            Directory.CreateDirectory(Path.Combine(validFolder, "labels"));

            File.WriteAllText(outFolderPath + @"\VottJsonToYolo.yaml", "");
            #endregion

            #region LOAD VOTT
            LoadVottLabels(vottJsonFilePath);
            #endregion

            #region
            ConvertToYoloLabel();
            #endregion

            var validCount = (YoloLabels.Count * 20) / 100;
            var testCount = (YoloLabels.Count * 10) / 100;


            int index = 0;
            foreach (var yoloLabel in YoloLabels)
            {
                var extension = Path.GetExtension(yoloLabel.FileName);
                var lines = new List<string>();

                foreach (var yoloRegion in yoloLabel.YoloRegions)
                {
                    lines.Add($"{yoloRegion.Class} {yoloRegion.XCenter} {yoloRegion.YCenter} {yoloRegion.BoxWidth} {yoloRegion.BoxHeight}");
                }

                if (index < testCount)//test
                {
                    File.Copy(vottFolderPath + @"\" + yoloLabel.FileName, Path.Combine(testFolder, "images") + @"\" + yoloLabel.FileName);
                    File.WriteAllLines(Path.Combine(testFolder, "labels") + @"\" + yoloLabel.FileName.Replace(extension, ".txt"), lines);
                }

                if (index > testCount)//valid
                {
                    File.Copy(vottFolderPath + @"\" + yoloLabel.FileName, Path.Combine(trainFolder, "images") + @"\" + yoloLabel.FileName);
                    File.WriteAllLines(Path.Combine(trainFolder, "labels") + @"\" + yoloLabel.FileName.Replace(extension, ".txt"), lines);
                }

                if (index > validCount)//train
                {
                    File.Copy(vottFolderPath + @"\" + yoloLabel.FileName, Path.Combine(validFolder, "images") + @"\" + yoloLabel.FileName);
                    File.WriteAllLines(Path.Combine(validFolder, "labels") + @"\" + yoloLabel.FileName.Replace(extension, ".txt"), lines);
                }

                index++;
            }

            //Yaml Create Added

            Console.ReadLine();
        }

        static void LoadVottLabels(string vottJsonFilePath)
        {
            var vottJsonData = File.ReadAllText(vottJsonFilePath);
            var data = (JObject)JsonConvert.DeserializeObject(vottJsonData);

            foreach (var asset in data.SelectTokens("assets.*"))
            {
                VottLabels.Add(asset.ToObject<VottLabel>());
            }
        }

        static void ConvertToYoloLabel()
        {
            foreach (var vottLabel in VottLabels)
            {
                var fileName = vottLabel.Asset.Name;

                var origWidth = vottLabel.Asset.Size.Width;

                var origHeight = vottLabel.Asset.Size.Height;

                var regions = vottLabel.VottRegions;

                var yoloRegions = new List<YoloRegion>();

                foreach (var region in regions)
                {
                    var label = region.Tags.First();
                    var yoloBox = ConvertYoloBox(region.BoundingBox, origWidth, origHeight);
                    var yoloRegion = new YoloRegion()
                    {
                        Class = label,
                        BoxHeight = yoloBox.Height,
                        BoxWidth = yoloBox.Width,
                        XCenter = yoloBox.XCenter,
                        YCenter = yoloBox.YCenter
                    };
                    yoloRegions.Add(yoloRegion);
                }

                var yoloLabel = new YoloLabel();
                yoloLabel.FileName = fileName;
                yoloLabel.YoloRegions = yoloRegions;

                YoloLabels.Add(yoloLabel);
            }
        }

        static YoloBoundingBox ConvertYoloBox(VottBoundingBox vottBoundingBox, long widht, long height)
        {
            var box = new YoloBoundingBox();

            box.XCenter = (vottBoundingBox.Left + (0.5 * vottBoundingBox.Width)) / widht;
            box.YCenter = (vottBoundingBox.Top + (0.5 * vottBoundingBox.Height)) / height;

            box.Width = vottBoundingBox.Width;
            box.Height = vottBoundingBox.Height;

            return box;
        }
    }
}
