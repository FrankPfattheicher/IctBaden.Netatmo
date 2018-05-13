using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Api
{
    public static class WebHook
    {
        /// <summary>
        /// https://dev.netatmo.com/en-US/resources/technical/reference/security/addwebhook
        /// </summary>
        public static bool Add(string accessToken, string webhookUrl)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var vals = new NameValueCollection
                    {
                        { "access_token", accessToken },
                        { "url", webhookUrl },
                        { "app_type", "app_camera" }
                    };
                    var url = $"https://{Netatmo.ApiHost}/api/addwebhook";
                    var response = client.UploadValues(url, HttpMethod.Post.Method, vals);
                    var json = Encoding.ASCII.GetString(response);
                    var homeData = JsonConvert.DeserializeObject<ResponseFrame<object>>(json);

                    return homeData.IsOk();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }


        /// <summary>
        /// https://dev.netatmo.com/en-US/resources/technical/reference/security/dropwebhook
        /// </summary>
        public static bool Drop(string accessToken)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var vals = new NameValueCollection
                    {
                        { "access_token", accessToken },
                        { "app_type", "app_camera" }
                    };
                    var url = $"https://{Netatmo.ApiHost}/api/dropwebhook";
                    var response = client.UploadValues(url, HttpMethod.Post.Method, vals);
                    var json = Encoding.ASCII.GetString(response);
                    var homeData = JsonConvert.DeserializeObject<ResponseFrame<object>>(json);

                    return homeData.IsOk();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

    }
}
