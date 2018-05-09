using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect
{
    public class SmartHome
    {
        /// <summary>
        /// https://dev.netatmo.com/resources/technical/reference/security/gethomedata
        /// </summary>
        public static HomeData GetHomeData(string accessToken)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var vals = new NameValueCollection
                    {
                        { "access_token", accessToken },
                        { "size", "0" }
                    };
                    var url = $"https://{Netatmo.ApiHost}/api/gethomedata";
                    var response = client.UploadValues(url, HttpMethod.Post.Method, vals);
                    var json = Encoding.ASCII.GetString(response);
                    var homeData = JsonConvert.DeserializeObject<ResponseFrame<HomeData>>(json);

                    if (homeData.IsOk())
                    {
                        return homeData.Body;
                    }
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