using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Auth
{
    /// <summary>
    /// To access users data, you will need an access token for each of your users. 
    /// The fastest way to retrieve a token is to authenticate your app with your user Netatmo credentials. 
    /// You'll be given a pair access_token + refresh_token and the validity period of the access_token.
    /// Access_tokens expire, you will need to get a new one using the refresh_token flow.
    /// https://dev.netatmo.com/resources/technical/guides/authentication/clientcredentials
    /// </summary>
    public class Authentication
    {
        public AuthTokens GetAccessTokens(string clientId, string clientSecret, string username, string password, List<string> requestedScopes)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var vals = new NameValueCollection
                    {
                        { "grant_type", "password" },
                        { "client_id", clientId },
                        { "client_secret", clientSecret },
                        { "username", username },
                        { "password", password },
                        { "scope", string.Join(" ", requestedScopes) }
                    };
                    var url = $"https://{Netatmo.ApiHost}/oauth2/token";
                    var response = client.UploadValues(url, HttpMethod.Post.Method, vals);
                    var json = Encoding.ASCII.GetString(response);
                    var tokens = JsonConvert.DeserializeObject<AuthTokens>(json);
                    return tokens;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}
