using MonkeyHubApp.Models;
using System.Threading.Tasks;

namespace MonkeyHubApp.Services
{
    interface IFacebookService
    {
        Task<User> GetPublicPerfil(string accessToken);
    }
}
