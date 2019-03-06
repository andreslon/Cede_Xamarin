using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.App.Models;
using Xamarin.App.Repositories.Interfaces;
using Xamarin.App.Views;
using Xamarin.Forms;

namespace Xamarin.App.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public IUserRepository Repository => DependencyService.Get<IUserRepository>();
        public ObservableCollection<User> Users { get; set; }
        public Command LoadUsersCommand { get; set; }

        public UsersViewModel()
        {
            Title = "Users";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());

            MessagingCenter.Subscribe<NewUserPage, User>(this, "AddUser", async (obj, User) =>
            {
                var newUser = User as User; 
                await Repository.SaveUser(newUser);
                await ExecuteLoadUsersCommand();
            });
            MessagingCenter.Subscribe<UserDetailPage, string>(this, "DeleteUser", async (obj, userId) =>
            { 
                await Repository.DeleteUser(userId);
                await ExecuteLoadUsersCommand();
            });
        }

        async Task ExecuteLoadUsersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Users.Clear();  
                var response = await Repository.GetUsers();
                foreach (var User in response)
                {
                    Users.Add(User);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}