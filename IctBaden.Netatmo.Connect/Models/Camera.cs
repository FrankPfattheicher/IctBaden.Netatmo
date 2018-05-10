using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class Camera
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("sd_status")]
        public string SdStatus { get; set; }
        [JsonProperty("alim_status")]
        public string AlimStatus { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("last_setup")]
        public long LastSetup{ get; set; }
    }
}