using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class VottBoundingBox
    {
        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("left")]
        public double Left { get; set; }

        [JsonProperty("top")]
        public double Top { get; set; }
    }
}
