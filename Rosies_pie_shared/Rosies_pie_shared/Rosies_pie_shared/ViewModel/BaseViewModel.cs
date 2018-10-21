using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Rosies_pie_shared
{
    public class BaseViewModel : BindableObject
    {
        protected readonly IWebService service = ServiceContainer.Resolve<IWebService>();

        private bool isBusy = false;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

    }
}
