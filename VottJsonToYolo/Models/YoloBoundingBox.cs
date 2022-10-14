using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class YoloBoundingBox
    {
        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("left")]
        public double YCenter { get; set; }

        [JsonProperty("top")]
        public double XCenter { get; set; }
    }
}
