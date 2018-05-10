using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class GlobalInfo
    {
        [JsonProperty("show_tags")]
        public bool ShowTags { get; set; }
    }
}