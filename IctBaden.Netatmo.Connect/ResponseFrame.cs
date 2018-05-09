using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect
{
    public class ResponseFrame<T>
    {
        [JsonProperty("body")]
        public T Body { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("time_exec")]
        public double TimeExec { get; set; }
        [JsonProperty("time_server")]
        public long TimeServer { get; set; }

        public bool IsOk() => Status == "ok";
    }
}