using System.Collections.Generic;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class HomeData
    {
        [JsonProperty("homes")]
        public List<Home> Homes { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("global_info")]
        public GlobalInfo GlobalInfo { get; set; }
    }
}
