using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.App.Extensions.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> Get(string apiUri);
        Task<HttpResponseMessage> Delete(string apiUri);
        Task<HttpResponseMessage> Post<T>(string apiUri, T request);
    }
}
