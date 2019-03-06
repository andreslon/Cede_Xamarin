using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.App.Models;

namespace Xamarin.App.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> SaveUser(User user);
        Task<bool> DeleteUser(string userId);
    }
}
