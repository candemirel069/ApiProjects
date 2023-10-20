using Newtonsoft.Json;

namespace Location.SampleApp.Code;

public class LocationApiClient
{
    public HttpClient CreateClient() => new HttpClient() { BaseAddress = new Uri("https://localhost:5555/api/") };

    public async Task<T?> GetAsync<T>(string url, int id) where T : class
    {
        using (var client = CreateClient())
        {
            var result = await client.GetAsync($"{url}/{id}");

            if (result.IsSuccessStatusCode)
            {
                string json = new StreamReader(await result.Content.ReadAsStreamAsync()).ReadToEnd();
                var data = JsonConvert.DeserializeObject<T>(json);

                //var data = await result.Content.ReadFromJsonAsync<T>();
                return data;
            }
            return null;
        }
    }
    public async Task<T[]?> GetAsync<T>(string url)
    {
        using (var client = CreateClient())
        {
            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadFromJsonAsync<T[]>();
                return data;
            }
            return null;
        }
    }
}