using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WSR2018Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.MeasureInvalidated += MainPage_MeasureInvalidated;
        }

        private async void MainPage_MeasureInvalidated(object sender, EventArgs e)
        {
            if (App.Current.Properties.TryGetValue("token", out object token))
            {
                ServerController.Token = token.ToString();
                await Navigation.PushAsync(new DialogList());
            }
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInBrowser());
        }
    }
}
