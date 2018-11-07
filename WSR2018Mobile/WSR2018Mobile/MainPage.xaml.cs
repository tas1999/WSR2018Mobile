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
        }

        

        private async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogInBrowser());
        }
    }
}
