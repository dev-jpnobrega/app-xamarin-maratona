using Newtonsoft.Json;

namespace MonkeyHubApp.Models
{
    public class UserFacebook
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string UID { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("urlPicture")]
        public string UrlPicture { get; set; }
    }
}
