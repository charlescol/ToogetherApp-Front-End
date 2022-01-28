using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class LoginService
    {
        static HttpClient _client = new HttpClient();
        public struct Profile
        {
            public string email;
            public string first_name;
            public string last_name;
            public string gender;
            public string birthday;
        }
        public static async Task<Profile> GetfacebookProfileAsync(string userID, string acess_token)
        {
            var response = await _client.GetAsync("https://graph.facebook.com/v12.0/" + userID + "/?access_token=" + acess_token + "&fields=email,first_name,last_name,gender,birthday");
            return JsonConvert.DeserializeObject<Profile>(await response.Content.ReadAsStringAsync());
        }
    }
}
