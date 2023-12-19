using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.Json.Nodes;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http;

namespace Health_Advice_Group
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string baseRequestCurrent = "http://api.weatherapi.com/v1/current.json?key=APIKEY&q=LOCATION&aqi=no";
        string requestCurrent;
        public Menu()
        {
            InitializeComponent();
            requestCurrent = baseRequestCurrent.Replace("LOCATION", "Leeds");
            requestCurrent = requestCurrent.Replace("APIKEY", API.Key);
            showJSON(requestCurrent);
        }

        private void btnUpdateLocation_Click(object sender, RoutedEventArgs e)
        {
            requestCurrent = baseRequestCurrent.Replace("LOCATION",txtLocation.Text);
            MessageBox.Show(requestCurrent);
            requestCurrent = requestCurrent.Replace("APIKEY", API.Key);
            showJSON(requestCurrent);
        }
        private void showJSON(string request)
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(request).Result;
            var jsonObject = JsonNode.Parse(response);
            output.Text = jsonObject.ToString();
        }
    }
}
