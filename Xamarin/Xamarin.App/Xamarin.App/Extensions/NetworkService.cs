using System.Threading.Tasks; 
using Plugin.Connectivity;
using Xamarin.App.Extensions.Interfaces;
using Xamarin.App.Extensions;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkService))]
namespace Xamarin.App.Extensions
{
    public class NetworkService : INetworkService
    {
        async public Task<bool> IsNetworkAvailable()
        {
            var connectivity = CrossConnectivity.Current;
            if (!connectivity.IsConnected)
                return false;

            var reachable = await connectivity.IsRemoteReachable("https://medicalappointmentapi.azurewebsites.net/");
            return reachable;
        }
    }
}
