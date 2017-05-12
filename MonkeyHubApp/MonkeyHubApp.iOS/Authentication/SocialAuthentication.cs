
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MonkeyHubApp.Authentication;
using MonkeyHubApp.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MonkeyHubApp.iOS.Authentication.SocialAuthentication))]
namespace MonkeyHubApp.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    { 
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null)
        {
            try
            {
                var current = GetController();
                var user = await c.LoginAsync(current, p);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            var current = root;
            while (current.PresentedViewController != null)
                current = current.PresentedViewController;

            return current;
        }
    }
}
