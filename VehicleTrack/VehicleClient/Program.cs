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
        static HttpClient _client;
        static  void Main(string[] args)
        {

         
            while (true)
            {
                Console.WriteLine("Enter Vehicle Id");
                vehicleId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Vehicle status");
                status = bool.Parse(Console.ReadLine());
                sendData(vehicleId, status);

               
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
