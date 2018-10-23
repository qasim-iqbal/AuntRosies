using Akavache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace Rosies_pie_shared
{
    public class EventsViewModel : BaseViewModel
    {

         
        public async Task GetEventsList()
        {
            Events = new ObservableCollection<Event>();
            Events = await service.GetEventListAsync();
        }


        private ObservableCollection<Event> _events;

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged("Events"); }
        }



        #region experimental


        public EventsViewModel()
        {
            LoadEntries(true);
        }

        public async Task<ObservableCollection<Event>> ReturnEventsList()
        {
           
            return await service.GetEventListAsync();
        }


        public async void LoadEntries(bool force)
        {
            try
            {
                Event eve = new Event { EventID = 2, EventEndDate = DateTime.Now, EventName = "myName", City = "pickering", Address = "asfee", EventStartDate = DateTime.Now, PostalCode = "asfd" };
                await BlobCache.LocalMachine.InsertObject<Event>(
                   "events",
                    eve);
                //BlobCache.LocalMachine.GetAndFetchLatest("events",
                //  async () => await ReturnEventsList(), null).Subscribe(eventLogs =>
                // {

                //     Events = eventLogs;

                // });



            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Error", ex.Message,"ok");
            }
            

        }
        #endregion

    }

}
