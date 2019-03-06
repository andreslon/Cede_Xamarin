using System;

using Xamarin.App.Models;

namespace Xamarin.App.ViewModels
{
    public class UserDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public UserDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
