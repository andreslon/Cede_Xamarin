using System;
using Xamarin.App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserPage : ContentPage
    {
        public User User { get; set; }

        public NewUserPage()
        {
            InitializeComponent();

            User = new User
            {
                BirthDay = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.LastName) && !string.IsNullOrEmpty(User.Nit))
            {
                MessagingCenter.Send(this, "AddUser", User);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Required Fields", "The fields name, lastname and nit are required", "Ok");
            }

        }
    }
}