using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FizzBuzzAPI.Models
{
    public class FizzBuzzResponse
    {
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Result { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Operation { get; set; }
    }
}
