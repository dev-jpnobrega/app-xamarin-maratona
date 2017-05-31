using MonkeyHubApp.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.Services
{
    public interface IFacebookService
    {
        Task<UserFacebook> GetPublicPerfil(string accessToken);

        Task<ImageSource> GetImageUser(string uri);
    }
}
