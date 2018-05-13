using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class CameraEvent
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("camera_id")]
        public string CameraId { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("snapshot")]
        public Snapshot Snapshot { get; set; }
        [JsonProperty("vignette")]
        public Vignette Vignette { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public DateTime LocalTime()
        {
            var utc = DateTimeOffset.FromUnixTimeSeconds(Time).DateTime;
            DateTime.SpecifyKind(utc, DateTimeKind.Utc);
            return utc.ToLocalTime();
        }

        public string MessageText() => Regex.Replace(Message, "<.*?>", string.Empty);

        public string PersonName()
        {
            if (Type != "person") return null;

            var extractName = new Regex("<b>(.+)</b>").Match(Message);
            return extractName.Success
                ? extractName.Groups[1].Value
                : null;
        }
    }
}