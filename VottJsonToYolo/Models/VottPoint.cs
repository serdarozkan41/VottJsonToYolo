using Newtonsoft.Json;

namespace VottJsonToYolo.Models
{
    public class VottPoint
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }
}
