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

        private async void Button_Clicked(object sender, EventArgs e)
        {

            List<string> vs = new List<string>();
            foreach(var p in await ServerController.GetAsyncStudents(int.Parse(offset.Text), int.Parse(count.Text)))
            {
                vs.Add(p.Text);
            }
            TextList.ItemsSource = vs;
        }
    }
}
