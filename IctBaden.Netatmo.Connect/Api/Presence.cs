using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using IctBaden.Netatmo.Connect.Models;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.Api
{
    public class Presence
    {
        /// <summary>
        /// https://dev.netatmo.com/resources/technical/reference/security/gethomedata
        /// </summary>
        public static List<Event> GetCameraEvents(string accessToken, string cameraId, int maxCount)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var vals = new NameValueCollection
                    {
                        { "access_token", accessToken },
                        { "device_id", cameraId },
                        { "size", maxCount.ToString() }
                    };
                    var url = $"https://{Netatmo.ApiHost}/api/gethomedata";
                    var response = client.UploadValues(url, HttpMethod.Post.Method, vals);
                    var json = Encoding.ASCII.GetString(response);
                    var homeData = JsonConvert.DeserializeObject<ResponseFrame<HomeData>>(json);

                    if (homeData.IsOk())
                    {
                        return homeData.Body.Homes.First().Events;
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
