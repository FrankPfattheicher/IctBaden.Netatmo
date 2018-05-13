using System.Collections.Generic;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class Home
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("cameras")]
        public List<Camera> Cameras { get; set; }

        [JsonProperty("smokedetectors")]
        public List<string> SmokeDetectors { get; set; }

        [JsonProperty("events")]
        public List<CameraEvent> Events { get; set; }
    }
}