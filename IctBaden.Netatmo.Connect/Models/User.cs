using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class User
    {
        [JsonProperty("reg_locale")]
        public string Locale { get; set; }
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("mail")]
        public string Mail { get; set; }
    }
}