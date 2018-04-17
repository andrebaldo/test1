using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarWarsTestKneat.DataModel;

namespace StarWarsTestKneat.API
{
    public class StarWarsApiWrapper : IStarWarsApiWrapper
    {

        public async Task<StarshipsResult> getStarShipPage(string url)
        {
            var response = await fechServerData(url);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var tmp = JsonConvert.DeserializeObject<StarshipsResult>(body);
                return tmp;
            }
            return null;
        }

        private Task<HttpResponseMessage> fechServerData(string path)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(path);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client.GetAsync(path);
        }
    }
}
