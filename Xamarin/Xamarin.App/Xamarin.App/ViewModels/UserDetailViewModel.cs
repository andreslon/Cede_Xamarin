using System;

using Xamarin.App.Models;

namespace Xamarin.App.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public User User { get; set; }
        public UserDetailViewModel(User user = null)
        {
            Title = $"{user?.Name} {user?.LastName}";
            User = user;
        }
    }
}
