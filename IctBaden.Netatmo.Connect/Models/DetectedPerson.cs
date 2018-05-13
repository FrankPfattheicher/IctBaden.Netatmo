using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Models
{
    public class DetectedPerson
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("face_id")]
        public string FaceId { get; set; }
        [JsonProperty("face_key")]
        public string FaceKey { get; set; }
        [JsonProperty("is_known")]
        public bool IsKnown { get; set; }
        [JsonProperty("face_url")]
        public string FaceUrl { get; set; }
    }
}