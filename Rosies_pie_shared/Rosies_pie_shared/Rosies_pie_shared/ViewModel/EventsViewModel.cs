using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rosies_pie_shared
{
    public class EventsViewModel : BaseViewModel
    {
        //public List<Event> Events { get; set; }

  
        public async void GetEventsList()
        {
            Events = new List<Event>();
            Events = await service.GetEventListAsync();
            evetss = Events[0].EventName;
        }
        public string evetss { get; set; }

        private List<Event> _events;

        public List<Event> Events
        {
            get { return _events; }
            set { _events = value; OnPropertyChanged("Events"); }
        }
        public EventsViewModel()
        {
            GetEventsList();
        }

    }
    
}
