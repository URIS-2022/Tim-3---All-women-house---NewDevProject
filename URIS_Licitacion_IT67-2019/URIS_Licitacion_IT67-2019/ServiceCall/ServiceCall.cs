using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace URIS_Licitacion_IT67_2019.CallServices
{
    public class ServiceCall<T> : IServiceCall<T>
    {

        private readonly IConfiguration configuration;

        public ServiceCall(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

      
        public async Task<T> SendGetRequest(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return default;
                    }

                    return JsonConvert.DeserializeObject<T>(content);
                }
                return default;
            }
            catch (Exception e)
            {
                return default;
            }
        }

    }
}
