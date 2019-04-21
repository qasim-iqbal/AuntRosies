using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace Rosies_pie_shared
{
    class HerokuWebService :  IWebService
    {

        HttpClient webClient; // HTTP request/response client
        readonly Uri _baseUri = new Uri("https://aunt-rosie-api.herokuapp.com");
        readonly IDictionary<string, string> _headers = new Dictionary<string, string>();
        string appkeyHash = "3529b84fde78a643f6c619fed2da272853c9f924a98836d4b0cfbaa7513c52c381f45c8dfb16dddc122f33f63ed667e0629a354cf2adae2e5e92911e6c0ff640";

        public HerokuWebService()
        {
            webClient = new HttpClient();
            _headers = new Dictionary<string, string>();
            _headers.Add("app_key", appkeyHash);

            webClient.MaxResponseContentBufferSize = 256000; // buffers out the http client request
            webClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json' "));

        }

        /// <summary>
        /// checks of internet connection
        /// </summary>
        /// <returns></returns>
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        #region IwebserviceImplementation
        async Task<ObservableCollection<Event>> IWebService.GetEventListAsync()
        {
            var url = new Uri(_baseUri, string.Format("/events"));
            
            try
            {

                ObservableCollection<Event> obj = null;
                var response = await webClient.GetAsync(url);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonString);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        async Task<ObservableCollection<EventSales>> IWebService.GetProductListAsync()
        {
            var url = new Uri(_baseUri, string.Format("/event_product_list"));

            try
            {

                ObservableCollection<EventSales> obj = null;
                var response = await webClient.GetAsync(url);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<ObservableCollection<EventSales>>(jsonString);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IWebService.UpdateProductAsync(ObservableCollection<EventSales> updatedList)
        {
            var url = new Uri(_baseUri, string.Format("/update_event_products"));

            try
            {

                var eventSalesList = JsonConvert.SerializeObject(updatedList);

                StringContent myContent = new StringContent(eventSalesList);
                
                var response =  webClient.PostAsync(url,myContent).Result;
                
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
