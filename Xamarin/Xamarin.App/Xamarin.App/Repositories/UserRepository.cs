using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.App.Extensions.Interfaces;
using Xamarin.App.Models;
using Xamarin.App.Repositories;
using Xamarin.App.Repositories.Interfaces;
using Xamarin.App.Resources; 
using Xamarin.Forms;

[assembly: Dependency(typeof(UserRepository))]
namespace Xamarin.App.Repositories
{
    public class UserRepository: IUserRepository
    {
        public string ApiUri { get; set; } = AppResources.ApiUri;
        public INetworkService NetworkService { get; set; }
        public IHttpClientService HttpClientService { get; set; }
        public UserRepository()
        {
            NetworkService = DependencyService.Get<INetworkService>();
            HttpClientService = DependencyService.Get<IHttpClientService>();
        }

        async public Task<List<User>> GetUsers()
        {
            if (await NetworkService.IsNetworkAvailable())
            {
                var response = await HttpClientService
                    .Get($"{ApiUri}/user");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(content);
                }
            } 
            return null;
        }
    }
}
