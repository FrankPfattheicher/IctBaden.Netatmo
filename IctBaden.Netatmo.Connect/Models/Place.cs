using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class Place
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}