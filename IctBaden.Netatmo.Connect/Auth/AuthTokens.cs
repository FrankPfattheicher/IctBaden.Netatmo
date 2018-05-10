using System.Collections.Generic;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Auth
{
    public class AuthTokens
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("scope")]
        public List<string> Scopes { get; set; }
    }
}