using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rosies_pie_shared
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsPage : ContentPage
	{
        readonly EventsViewModel eventsVM = new EventsViewModel();
		public EventsPage ()
		{
            BindingContext = eventsVM;
           
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            eventsVM.LoadEntries(true);
            base.OnAppearing();
        }
    }
}