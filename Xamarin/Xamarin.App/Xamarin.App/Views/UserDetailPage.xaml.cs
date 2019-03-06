using System;
using Xamarin.App.Models;
using Xamarin.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        UserDetailViewModel viewModel;

        public UserDetailPage(UserDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public UserDetailPage()
        {
            InitializeComponent();

            var item = new User
            {

            };

            viewModel = new UserDetailViewModel(item);
            BindingContext = viewModel;
        }

        async private void Delete_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "DeleteUser", viewModel.User.UserId);
            await Navigation.PopAsync();
        }
    }
}