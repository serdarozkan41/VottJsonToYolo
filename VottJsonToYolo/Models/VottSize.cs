using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class VottSize
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
