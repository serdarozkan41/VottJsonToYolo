using System.Collections.Generic;

namespace VottJsonToYolo.Models
{
    public class YoloLabel
    {
        public string FileName { get; set; }
        public List<YoloRegion> YoloRegions { get; set; }
    }
}
