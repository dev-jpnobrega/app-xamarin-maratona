using Newtonsoft.Json;

namespace MonkeyHubApp.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

    }
}
