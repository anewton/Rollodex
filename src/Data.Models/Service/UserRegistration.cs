using Newtonsoft.Json;

namespace Data.Models.Service
{
    public class UserRegistration
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}