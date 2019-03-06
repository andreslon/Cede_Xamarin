using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.App.Extensions;
using Xamarin.App.Extensions.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(HttpClientService))]

namespace Xamarin.App.Extensions
{
    public class HttpClientService : IHttpClientService
    {
        async public Task<HttpResponseMessage> Get(string apiUri)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(new Uri(apiUri));
            }
        }

        async public Task<HttpResponseMessage> Post<T>(string apiUri, T request)
        {
            using (var client = new HttpClient())
            {
                string body = JsonConvert.SerializeObject(request);
                var o = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(body);
                o.Property("UserId").Remove();
                body = o.ToString();

                return await client.PostAsync(apiUri,
                    new StringContent(body, Encoding.UTF8, "application/json"));
            }
        }
        async public Task<HttpResponseMessage> Delete(string apiUri)
        {
            using (var client = new HttpClient())
            {
                return await client.DeleteAsync(new Uri(apiUri));
            }
        }
    }
}
