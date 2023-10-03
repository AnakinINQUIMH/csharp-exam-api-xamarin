using Newtonsoft.Json;


namespace AppCRUD.Models
{
    public class GeneralResponseModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
