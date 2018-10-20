using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rosies_pie_shared.Services;
using ZXing.Net.Mobile.Forms;

namespace Rosies_pie_shared
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXingScannerPage();
                await Navigation.PushAsync(scanner);
                scanner.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        lblResult.Text = result.Text;
                    });
                };

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void btnEvents_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EventsPage());
        }
    }
}
