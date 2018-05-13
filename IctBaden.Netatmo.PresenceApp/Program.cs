using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IctBaden.Netatmo.Connect;
using IctBaden.Netatmo.Connect.Api;
using IctBaden.Netatmo.Connect.Auth;
using IctBaden.Netatmo.Connect.HookServer;

namespace IctBaden.Netatmo.PresenceApp
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Console.WriteLine("Netatmo Presence App");

            var auth = new Authentication();

            var fileName = @"C:\Temp\Netatmo.cfg";
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Missing config file: {fileName}");
                Console.WriteLine("Containing one text line clientId <TAB> clientSecret <TAB> username <TAB> password");
                Environment.Exit(1);
            }
            var authParams = File.ReadAllLines(fileName).First().Split('\t');
            var token = auth.GetAccessTokens(authParams[0], authParams[1], authParams[2], authParams[3], 
                new List<string> { Scopes.ReadCamera, Scopes.ReadPresence });
            if (token == null)
            {
                Console.WriteLine("Failed to authenticate.");
                Environment.Exit(1);
            }

            Console.WriteLine($"AccessToken = {token.AccessToken}");

            var homeData = SmartHome.GetHomeData(token.AccessToken);
            foreach (var home in homeData.Homes)
            {
                Console.WriteLine($"Home({home.Id}): {home.Name}, {home.Place.City}");
                foreach (var camera in home.Cameras)
                {
                    Console.WriteLine($"Camera({camera.Id}): {camera.Name}");
                }
            }

            var firstCamera = homeData.Homes.First().Cameras.First();
            var events = Presence.GetCameraEvents(token.AccessToken, firstCamera.Id, 5);
            foreach (var ev in events)
            {
                Console.WriteLine($"{ev.LocalTime():g} {ev.Type}({ev.Category}): {ev.MessageText()}");
            }

            fileName = @"C:\Temp\WebHook.cfg";
            if (File.Exists(fileName))
            {
                var hookUrl = File.ReadAllLines(fileName).First().Trim();
                Console.WriteLine("Start WebHook Server");
                var hook = new WebHookServer(60606);
                hook.OnEvent += ev =>
                {
                    Console.WriteLine($"HookEvent: {ev.EventType} {ev.Message}");
                };
                hook.Start();

                Console.WriteLine($"Register WebHook Server on {hookUrl}");
                var ok = WebHook.Add(token.AccessToken, hookUrl);
                Console.WriteLine("Register WebHook Server: " + (ok ? "OK" : "FAILED"));

                Console.WriteLine();
                Console.WriteLine("Press RETURN to exit.");
                Console.ReadLine();

                Console.WriteLine("Unegister WebHook Server");
                ok = WebHook.Drop(token.AccessToken);
                Console.WriteLine("Unegister WebHook Server: " + (ok ? "OK" : "FAILED"));

                Console.WriteLine("Terminate WebHook Server");
                hook.Terminate();
            }
            else
            {
                Console.WriteLine("No WebHook configured.");

                Console.WriteLine();
                Console.WriteLine("Press RETURN to exit.");
                Console.ReadLine();
            }

            Console.WriteLine("Netatmo Presence App DONE.");
        }
    }
}
