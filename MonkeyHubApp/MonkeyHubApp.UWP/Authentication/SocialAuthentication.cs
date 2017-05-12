using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using MonkeyHubApp.Authentication;
using MonkeyHubApp.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MonkeyHubApp.UWP.Authentication.SocialAuthentication))]
namespace MonkeyHubApp.UWP.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null)
        {
            try
            {
                var user = await c.LoginAsync(p);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
