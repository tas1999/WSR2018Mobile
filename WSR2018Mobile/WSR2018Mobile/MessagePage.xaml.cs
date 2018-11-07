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
            Userid = id;
            InitializeComponent ();
            this.MeasureInvalidated += MessagePage_MeasureInvalidated;
        }

        private async void MessagePage_MeasureInvalidated(object sender, EventArgs e)
        {
            ListMessage.ItemsSource = await ServerController.GetMessageList(Userid);
            
        }

        private async Task SendButton_Clicked(object sender, EventArgs e)
        {
           await ServerController.SendMessage(MessageText.Text, Userid);
           ListMessage.ItemsSource = await ServerController.GetMessageList(Userid);
        }
    }
}