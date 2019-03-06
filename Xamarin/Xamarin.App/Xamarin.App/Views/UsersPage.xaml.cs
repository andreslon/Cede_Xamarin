using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.App.Models;
using Xamarin.App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        UsersViewModel viewModel;

        public UsersPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UsersViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as User;
            if (item == null)
                return;

            await Navigation.PushAsync(new UserDetailPage(new UserDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewUserPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Users.Count == 0)
                viewModel.LoadUsersCommand.Execute(null);
        }
    }
}