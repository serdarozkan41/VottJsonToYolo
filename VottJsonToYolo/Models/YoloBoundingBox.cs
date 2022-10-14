using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class YoloBoundingBox
    {
        [JsonProperty("height")]
        public float Height { get; set; }

        [JsonProperty("width")]
        public float Width { get; set; }

        [JsonProperty("left")]
        public float YCenter { get; set; }

        [JsonProperty("top")]
        public float XCenter { get; set; }
    }
}
