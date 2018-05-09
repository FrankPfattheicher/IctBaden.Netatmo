using System.Collections.Generic;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect
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


    public class Home
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("place")]
        public HomePlace Place { get; set; }

        [JsonProperty("cameras")]
        public List<Camera> Cameras { get; set; }

        [JsonProperty("smokedetectors")]
        public List<string> SmokeDetectors { get; set; }

        [JsonProperty("events")]
        public List<string> Events { get; set; }
    }

    public class HomePlace
    {
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }


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

    public class GlobalInfo
    {
        [JsonProperty("show_tags")]
        public bool ShowTags { get; set; }
    }


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

    public class Event
    {
        
    }
}
