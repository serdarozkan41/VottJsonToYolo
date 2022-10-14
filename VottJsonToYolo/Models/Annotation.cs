using System.Collections.Generic;

namespace VottJsonToYolo.Models
{
    public class Annotation
    {
        public List<YoloRegion> YoloRegions { get; set; }
        public string FileName { get; set; }
    }
}
