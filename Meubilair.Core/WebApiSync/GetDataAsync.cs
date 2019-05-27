using Meubilair.Core.DomainBase;
using Meubilair.Core.RepositoryFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.WebApiSync
{
    public abstract class GetDataAsync<T> : IDataApi<T> where T : EntityBase
    {


        HttpClient client;
        HttpResponseMessage response;
        string baseAddress;
        EntityRequestStatus responseObj;
        string postUrl;

        public GetDataAsync()
        {

            this.baseAddress = GetBaseUrlPath();
            client = new HttpClient();
            client.BaseAddress = new Uri(this.baseAddress);
            AddMediaType("application / json");
            // Setting timeout.  
            client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));
            response = new HttpResponseMessage();
            responseObj = new EntityRequestStatus();
            postUrl = GetPostUrl();
        }



        public void AddMediaType(string mediaType)
        {

            // Setting content type.  
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
        }

        #region IDataApi Resion 

        public T Get(object key)
        {
            using (resource)
            {

            }
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public string BuilGetItemdUrlPath(string getItemUrlPath)
        {

            StringBuilder builder = new StringBuilder();
            builder.Append(baseAddress);
            builder.Append(string.Format(@"/{0}", getItemUrlPath));
            return builder.ToString();
        }

        #region abstract Methods
        public abstract string GetBaseUrlPath();
        public abstract string GetItemUrlPath();
        public abstract string GetPostUrl();

        #endregion

        public async Task<EntityRequestStatus> Put(object key)
        {
          


            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public async Task<EntityRequestStatus> Post(T Item)
        {
            using (client)
            {
                EntityRequestStatus requestObj =
                    new EntityRequestStatus();
                this.response = await client.PostAsJsonAsync(postUrl, requestObj);
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    responseObj = JsonConvert.DeserializeObject<EntityRequestStatus>(result);
                    // Releasing.  
                    response.Dispose();
                }
                else
                    responseObj.Code = 602;

                return requestObj;
            }

        }



        #endregion
    }
}
