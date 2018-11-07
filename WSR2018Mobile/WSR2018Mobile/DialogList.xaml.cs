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
	public partial class DialogList : ContentPage
	{
		public DialogList ()
		{
            InitializeComponent();
            this.MeasureInvalidated += DialogList_MeasureInvalidated;
        }

        private async void DialogList_MeasureInvalidated(object sender, EventArgs e)
        {
            DialogLView.ItemsSource = await ServerController.GetDialogList();
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
           await DisplayAlert("", sender.ToString(), "ok");
           // await Navigation.PushModalAsync(new MessagePage(((Chat)sender).Conversation.Peer.Id));
        }
    }
}