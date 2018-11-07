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
            DialogLView.ItemSelected += (e,o) => int t = 11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111;

        }

        private async void DialogList_MeasureInvalidated(object sender, EventArgs e)
        {
            DialogLView.ItemsSource = await ServerController.GetDialogList();
        }

    }
}