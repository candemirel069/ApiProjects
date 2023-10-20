using Location.SampleConsoleApp.Models;
using System;
using System.Net.Http.Json;

namespace Location.SampleConsoleApp;

class ApiClient1
{
    public async Task<List<Sehir>> GetSehirListesiAsync()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://localhost:5555/api/");
            var result = await client.GetAsync($"sehirler");

            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadFromJsonAsync<Sehir[]>();
                return data.ToList();
            }
            return null;
        }
    }
}

class Program
{
    static async Task  Main(string[] args)
    {
        var apiClient = new ApiClient1();

        var sehirListesi =await apiClient.GetSehirListesiAsync();
        foreach (var item in sehirListesi)
        {
            Console.WriteLine(item.Adi);
        }
    }
}
