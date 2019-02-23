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
       static string username = "";
       static string password = "";
        static int vehicleId;
        static bool status;
        static HttpClient _client;
        static  void Main(string[] args)
        {
            //Console.Write("Username : ");
            //username = Console.ReadLine();
            //Console.Write("Password : ");
            //password = Console.ReadLine();
            //authontication(username, password);

            call();
            while (true)
            {
                //Console.WriteLine("Enter Vehicle Id");
                //vehicleId = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter Vehicle status");
                //status = bool.Parse(Console.ReadLine());
                //sendData(vehicleId, status);

                //var request = WebRequest.Create(ConfigurationSettings.AppSettings["ServerUrl"]) as HttpWebRequest;
                //request.Method = "GET";
                //request.Headers.Add(HttpRequestHeader.Authorization, "Bearer <api-token>"); //example: "Bearer F4dfghuhgudhfgJL3"

                //// Get response here
                //var response = request.GetResponse() as HttpWebResponse;
                //if (response.StatusCode == HttpStatusCode.OK)
                //{
                //    // ....
                //}
            }
        }


        static async void call()
        {
            HttpClient client = new HttpClient();
           //var byteArray = Encoding.ASCII.GetBytes();
            client.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue(
        "Basic",
        Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(
                string.Format("{0}:{1}", "customer2@reg.com","ITC123itc**"))));
            HttpResponseMessage response = await client.GetAsync(ConfigurationSettings.AppSettings["ServerUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Object>(data);
            }

            Console.Read();
        }
        static void authontication(string username, string password)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", username, password))));
            var list=_client.GetStringAsync(ConfigurationSettings.AppSettings["ServerUrl"]);

            //client.Credentials = new NetworkCredential("Customer1@reg.com", System.Text.Encoding.ASCII.GetBytes("ITC123itc**").ToString());
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
