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
        }


        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new MessagePage(((Chat)sender).Conversation.Peer.Id));
        }
    }
}