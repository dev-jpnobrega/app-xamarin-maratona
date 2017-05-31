using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;
using MonkeyHubApp.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MonkeyHubApp.Services.FacebookService))]
namespace MonkeyHubApp.Services
{
    public class FacebookService : IFacebookService
    {
        private string _Url = "https://graph.facebook.com/";

        private readonly string _TokenAcess = string.Empty;
        private readonly HttpClient HttpClient;


        public FacebookService()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(_Url)
            };

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<UserFacebook> GetPublicPerfil(string accessToken)
        {
            var response = await HttpClient.GetAsync($"me?access_token={accessToken}");

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    string ss = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

                    UserFacebook u = JsonConvert.DeserializeObject<UserFacebook>(ss);
                    u.UrlPicture = $"https://graph.facebook.com/{u.UID}/picture?type=large";
                    return u;
                }
            }

            return null;
        }


        public async Task<ImageSource> GetImageUser(string uri) =>
            await Task.Factory.StartNew(() => ImageSource.FromUri(new Uri(uri)));
    }
}
