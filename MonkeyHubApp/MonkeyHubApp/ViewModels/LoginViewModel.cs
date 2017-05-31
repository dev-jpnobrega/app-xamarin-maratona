using System.Threading.Tasks;
using Xamarin.Forms;

using MonkeyHubApp.Helpers;
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using MonkeyHubApp.Views;

namespace MonkeyHubApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService _azureService;
        IFacebookService _iFacebookService;
        
        public Command LoginCommand { get; }

        public Command SignUpCommand { get; }

        public LoginViewModel()
        {
            Title = "Monkey Hub ";
            IsBusy = false;

            LoginCommand = new Command(ExecuteLoginCommand);
            SignUpCommand = new Command(ExecuteSignUpCommand);
            
            _iFacebookService = DependencyService.Get<IFacebookService>();
            _azureService = DependencyService.Get<AzureService>();
        }

        private async void ExecuteLoginCommand()
        {
            IsBusy = true;
            if (await LoginAsync())
            {
                IsBusy = false;
                Application.Current.MainPage = new MainDetailPage();   
            }
        }

        private async void ExecuteSignUpCommand()
        {
            await MessegerAlert("MonkeyHubApp", "Sign Up ainda não está implementado.", "OK");
        }

        private void RemovePageFromStack()
        {
            INavigation cs;
            //  var existingPage = cs.NavigationStack.ToList();

        }


        public async Task<bool> LoginAsync()
        {
            bool r = false;
            r = Settings.IsLoggedIn;

            if (!Settings.IsLoggedIn)
               r = await _azureService.LoginAsync();

            if (!r) return false;

            Newtonsoft.Json.Linq.JToken j = await _azureService.GetInfoProvider("/.auth/me");
            Settings.TokenAuthFacebook = j[0].Value<string>("access_token");

            UserFacebook us = await _iFacebookService.GetPublicPerfil(Settings.TokenAuthFacebook);
            User.Email = us.Email;
            User.UrlPicture = us.UrlPicture;
            User.UID = us.UID;
            User.FirstName = us.FirstName;
            User.LastName = us.LastName;

            return true;
        }
    }
}
