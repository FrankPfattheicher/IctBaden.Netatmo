using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class Snapshot
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("version")]
        public long Version { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}