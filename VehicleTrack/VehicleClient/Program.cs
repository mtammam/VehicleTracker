using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;

namespace VehicleClient
{
    class Program
    {
      
        static int vehicleId;
        static bool status;
        static string YorN;
        static HttpClient _client;
        static  void Main(string[] args)
        {

            Console.WriteLine("Welcom To Car Tracker");
            while (true)
            {
                Console.WriteLine("Please Enter Your Vehicle Id");
                vehicleId = int.Parse(Console.ReadLine());
                Console.WriteLine("Is Your Car Enggaged [Y] BreakDown[N]");
            l: YorN = Console.ReadLine();
                if (YorN.ToLower() == "y")
                {
                    sendData(vehicleId, true);
                    Console.WriteLine("Vehicle Is Engaged Now ...");
                }
                else if (YorN == "n")
                {
                    sendData(vehicleId, false);
                    Console.WriteLine("Vehicle Is Disengaged Now ...");
                }
                else
                {
                    Console.WriteLine("Please Enter Y/N");
                    goto l;
                }

            }
        }


     
    

        static void sendData(int vehicleId,bool flage)
        {
            var postData = new
            {
                Id = vehicleId,
                Status= flage
            };

            var json = JsonConvert.SerializeObject(postData);

            // Post the data to the server
            var serverUrl = new Uri (ConfigurationSettings.AppSettings["ServerUrl"]);
            

            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
  

            Console.WriteLine(client.UploadString(serverUrl, json));
        }
    }
}
