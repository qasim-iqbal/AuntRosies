using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace Rosies_pie_shared
{
    class HerokuWebService : BaseHttpService, IWebService
    {

        //readonly Uri _baseUri = new Uri("https://aunt-rosie-api.herokuapp.com");
        //readonly IDictionary<string, string> _headers;

        //string appkeyHash = "3529b84fde78a643f6c619fed2da272853c9f924a98836d4b0cfbaa7513c52c381f45c8dfb16dddc122f33f63ed667e0629a354cf2adae2e5e92911e6c0ff640";

        //public HerokuWebService()
        //{
        //    _headers = new Dictionary<string, string>();

        //    _headers.Add("app_key", appkeyHash);
        //}

        HttpClient webClient; // HTTP request/response client
        readonly Uri _baseUri = new Uri("https://aunt-rosie-api.herokuapp.com");
        readonly IDictionary<string, string> _headers = new Dictionary<string, string>();
        string appkeyHash = "3529b84fde78a643f6c619fed2da272853c9f924a98836d4b0cfbaa7513c52c381f45c8dfb16dddc122f33f63ed667e0629a354cf2adae2e5e92911e6c0ff640";
        string pageFor = "Default";


        public HerokuWebService()
        {
            webClient = new HttpClient();
            _headers = new Dictionary<string, string>();
            _headers.Add("app_key", appkeyHash);

            webClient.MaxResponseContentBufferSize = 256000; // buffers out the http client request
            webClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json' "));

        }



        #region IwebserviceImplementation
        public async Task<List<Event>> GetEventListAsync()
        {
            var url = new Uri(_baseUri, string.Format("/events"));
            //var response = await SendRequestAsync<Event[]>(url, HttpMethod.Get /*,_headers*/);
            //foreach (var header in _headers)
            //{
            //    //request.Headers.Add(header.Key, header.Value);
            //    webClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            //}

            try
            {

                List<Event> obj = null;
                var response = await webClient.GetAsync(url);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<List<Event>>(jsonString);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

    }
}
