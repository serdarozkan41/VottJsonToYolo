using Newtonsoft.Json;
using System.Collections.Generic;

namespace VottJsonToYolo.Models
{
    internal class VottLabel
    {
        [JsonProperty("asset")]
        public VottAsset Asset { get; set; }

        [JsonProperty("regions")]
        public List<VottRegion> VottRegions { get; set; }
    }
}
