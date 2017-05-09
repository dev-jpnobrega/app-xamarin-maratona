using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace MonkeyHubApp.Authentication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null);
    }
}
