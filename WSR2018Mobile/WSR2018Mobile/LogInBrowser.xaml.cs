using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSR2018Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInBrowser : ContentPage
	{
		public LogInBrowser ()
		{
			InitializeComponent();
            LoginBrowser.Source = new Uri(@"https://oauth.vk.com/authorize?client_id=6743084&redirect_uri=https://oauth.vk.com/blank.html&scope=messages wall groups&response_type=token&v=5.87");
            
        }

        private async void LoginBrowser_BindingContextChanged(object sender, EventArgs e)
        {
            string url = ((UrlWebViewSource)LoginBrowser.Source).Url;
            string suchText = "blank.html#access_token=";
            int startIndex = url.IndexOf(suchText);
            if (startIndex > -1)
            {
                startIndex += suchText.Length;
                int endIndex = url.IndexOf("&expires_in");
                string token = url.Substring(startIndex, endIndex - startIndex);
                ServerController.Token = token;
                App.Current.Properties.Add("token", token);
                await Navigation.PushAsync(new DialogList());
            }
        }
    }
}