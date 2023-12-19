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

namespace Health_Advice_Group
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        string requestCurrent = "http://api.weatherapi.com/v1/current.json?key=APIKEY&q=Leeds&aqi=no";
        public Menu()
        {
            InitializeComponent();
            MessageBox.Show(requestCurrent);
            requestCurrent = requestCurrent.Replace("APIKEY", API.Key);
            MessageBox.Show(requestCurrent);
        }
    }
}
