using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    //{"response":[{"id":180009,"first_name":"Олег","last_name":"Тарусов"}]}
    public class VkViewModel
    {
        [JsonProperty("response")]
        public List<PersonData> Response { get; set; }
    }

    public class PersonData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
