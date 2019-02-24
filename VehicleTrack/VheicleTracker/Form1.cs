using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VheicleTracker
{
    public partial class Form1 : Form
    {
        HttpClient client;
       
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getVehicles(); 
        }

        public async void getVehicles()
        {
            HttpResponseMessage response = await client.GetAsync(ConfigurationSettings.AppSettings["ServerUrl"]);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var vehicels = JsonConvert.DeserializeObject<Vehicle>(data);

                
            }

           
        }
    }
}
