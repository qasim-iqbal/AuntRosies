using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rosies_pie_shared
{
    public class EventsViewModel : BaseViewModel
    {
        public Event[] Events { get; set; }

  
        public async void GetEventsList()
        {
            Events = await service.GetEventListAsync();
        }
    }
}
