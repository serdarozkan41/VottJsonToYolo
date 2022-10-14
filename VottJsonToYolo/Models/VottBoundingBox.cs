using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class VottBoundingBox
    {
        [JsonProperty("height")]
        public float Height { get; set; }

        [JsonProperty("width")]
        public float Width { get; set; }

        [JsonProperty("left")]
        public float Left { get; set; }

        [JsonProperty("top")]
        public float Top { get; set; }
    }
}
