using Akavache;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Rosies_pie_shared
{

    public partial class App : Application
    {
        private readonly SalesViewModel _salesVM;


        public App()
        {
            InitializeComponent();

            //initialize akavache
            BlobCache.ApplicationName = "AuntRosiesAkavache";


            // register webservice
            ServiceContainer.Register<IWebService>(() => new HerokuWebService());

            var tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(new MainPage { Icon = "baseline_local_grocery_store_white_18dp.png", Title="Sell" });
            tabbedPage.Children.Add(new SalesPage { Icon = "baseline_attach_money_white_18dp.png", Title = "Sales" });
            tabbedPage.Children.Add(new EventsPage { Icon = "baseline_event_white_18dp.png", Title = "Events" });

            

            MainPage = new NavigationPage(tabbedPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
