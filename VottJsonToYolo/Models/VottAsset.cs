using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class VottAsset
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("size")]
        public VottSize Size { get; set; }

        [JsonProperty("state")]
        public long State { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("predicted")]
        public bool Predicted { get; set; }
    }
}
