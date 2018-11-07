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
	public partial class MessagePage : ContentPage
	{
        int Userid { get; set; }
		public MessagePage(int id)
		{
			InitializeComponent ();
            Userid = id;
        }

        private async Task SendButton_Clicked(object sender, EventArgs e)
        {
           await ServerController.SendMessage(MessageText.Text, Userid);
        }
    }
}