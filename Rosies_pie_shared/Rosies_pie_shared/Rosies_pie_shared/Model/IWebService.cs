using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rosies_pie_shared
{
    public interface IWebService
    {
        Task<Event[]> GetEventListAsync();
    }
}
