using System.Collections.Generic;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class HookEvent
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("app_type")]
        public string AppType { get; set; }
        [JsonProperty("persons")]
        public List<DetectedPerson> Persons { get; set; }
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }
        [JsonProperty("snapshot_key")]
        public string SnapshotKey { get; set; }
        [JsonProperty("event_type")]
        public string EventType { get; set; }
        [JsonProperty("camera_id")]
        public string CameraId { get; set; }
        [JsonProperty("home_id")]
        public string HomeId { get; set; }
        [JsonProperty("home_name")]
        public string HomeName { get; set; }
        [JsonProperty("event_id")]
        public string EventId { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
