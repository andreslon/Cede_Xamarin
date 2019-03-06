using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.App.Extensions.Interfaces
{
    public interface INetworkService
    {
        Task<bool> IsNetworkAvailable();
    }
}
