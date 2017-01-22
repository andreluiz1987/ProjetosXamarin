using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TutorialApiCep.Model;
using Xamarin.Forms;

namespace TutorialApiCep.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand BuscarCommand { get; set; }
        public ObservableCollection<OpenWeatherMap.Root> ocItens { get; set; }

        public MainPageViewModel()
        {
            BuscarCommand = new Command(GetTemperature);
            ocItens = new ObservableCollection<OpenWeatherMap.Root>();
        }

        private async void GetTemperature()
        {
            var fdfd = await RefreshDataAsync();

            this.ocItens.Add(fdfd);
        }

        public async Task<OpenWeatherMap.Root> RefreshDataAsync()
        {
            OpenWeatherMap.Root Items = null;
            HttpClient client;
            client = new HttpClient();

            try
            {
                var uri = new Uri("http://api.openweathermap.org/data/2.5/weather?q=BeloHorizonte,br&APPID=a21ef9796e7d68f9519bd55c4e12f48b");

                var response = client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<OpenWeatherMap.Root>(content);
                }

            }
            catch (Exception ex)
            {
                var errr = ex.Message;
            }

            Items.weather[0].icon = GetImageResource(Items.weather[0].icon);
            Items.main.temp = Celcius(Items.main.temp);

            return Items;

        }

        private string GetImageResource(string strImage)
        {
            return strImage.Insert(0, "a").Insert(strImage.Length + 1, ".png");
        }

        int Celcius(double kelvin)
        {
            double c = kelvin - 273.15F;

            return (int)Math.Round(c);
        }
    }
}
