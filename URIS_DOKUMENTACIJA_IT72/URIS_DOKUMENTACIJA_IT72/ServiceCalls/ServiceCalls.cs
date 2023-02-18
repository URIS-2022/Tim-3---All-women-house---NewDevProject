using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace URIS_DOKUMENTACIJA_IT72.ServiceCalls
{ 
    public class ServiceCalls<T>: IServiceCalls<T>
    {
        public async Task<T?> SendGetRequestAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");

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
            catch (Exception )
            {
                return default;
            }
        }
    }
}
