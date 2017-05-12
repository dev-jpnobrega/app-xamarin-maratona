
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using MonkeyHubApp.Helpers;
using Xamarin.Forms;
using MonkeyHubApp.Authentication;
using MonkeyHubApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(MonkeyHubApp.Services.AzureService))]
namespace MonkeyHubApp.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://maratonaxamarinsocialplugin.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };                
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("OPS!", "Não conseguimos efetuar o login.", "OK");
                });

                return false;
            }
            
            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;
                        
            return true;
        }


        public async Task<Newtonsoft.Json.Linq.JToken> GetInfoProvider(string path)
        {
            try
            {
                return await Client.InvokeApiAsync(path, System.Net.Http.HttpMethod.Get, null);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
