using System.Threading.Tasks;
using Xamarin.Forms;

using MonkeyHubApp.Helpers;
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;

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
            LoginCommand = new Command(ExecuteLoginCommand);
            SignUpCommand = new Command(ExecuteSignUpCommand);


            _iFacebookService = DependencyService.Get<IFacebookService>();
            _azureService = DependencyService.Get<AzureService>();
        }

        private async void ExecuteLoginCommand()
        {
            if (await LoginAsync())
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        private async void ExecuteSignUpCommand()
        {
            await MessegerAlert("MónkeyHubApp", "Sign Up ainda não está implementado.", "OK");
        }


        private void RemovePageFromStack()
        {
            INavigation cs;
          //  var existingPage = cs.NavigationStack.ToList();
           
        }

        public async Task<bool> LoginAsync()
        {
            if (!Settings.IsLoggedIn)
                await _azureService.LoginAsync();

            Newtonsoft.Json.Linq.JToken j = await _azureService.GetInfoProvider("/.auth/me");
            Settings.TokenAuthFacebook = j[0].Value<string>("access_token");

            User s = await _iFacebookService.GetPublicPerfil(Settings.TokenAuthFacebook);

            return false;
        }
    }
}
