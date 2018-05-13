using System;
using System.Diagnostics;
using System.IO;
using IctBaden.Netatmo.Connect.Models;
using Newtonsoft.Json;

namespace IctBaden.Netatmo.Connect.HookServer
{
    public class WebHookServer : SimpleHttpServer
    {
        public event Action<HookEvent> OnEvent;

        public WebHookServer(int tcpPort) : base(tcpPort)
        {
        }

        public override void HandleGetRequest(SimpleHttpProcessor processor)
        {
            Console.WriteLine("GET");
            processor.WriteSuccess("ok", "text/html");
        }

        public override void HandlePostRequest(SimpleHttpProcessor processor, StreamReader inputData)
        {
            var json = inputData.ReadToEnd();
            Debug.WriteLine(json);
            Console.WriteLine(json);

            try
            {
                var hookEvent = JsonConvert.DeserializeObject<HookEvent>(json);
                OnEvent?.Invoke(hookEvent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            processor.WriteSuccess("", "");
        }
    }
}
