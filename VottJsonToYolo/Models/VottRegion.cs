using Newtonsoft.Json;
using System.Collections.Generic;

namespace VottJsonToYolo.Models
{
    public class VottRegion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("boundingBox")]
        public VottBoundingBox BoundingBox { get; set; }

        [JsonProperty("points")]
        public List<VottPoint> Points { get; set; }
    }
}
