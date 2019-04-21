using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

using System.Threading.Tasks;

namespace Rosies_pie_shared
{
    public interface IWebService
    {
        Task<ObservableCollection<Event>> GetEventListAsync();

        // Task to get Event sales information
        Task<ObservableCollection<EventSales>> GetProductListAsync();
     
        // Update - Update Pie info
        bool UpdateProductAsync(ObservableCollection<EventSales> updatedList);

    }
}
