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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.Item == null) return;

            // Optionally pause a bit to allow the preselect hint.
            Task.Delay(500);

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}