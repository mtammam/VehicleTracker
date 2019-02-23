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

namespace VehicleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var x = Console.ReadLine();
                if ( x== 1.ToString())
                    sendData(true);
                else if (x == 2.ToString())
                    sendData(false);
            }
        }

        static void sendData(bool flage)
        {
            var postData = new
            {
                Id = 9,
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
