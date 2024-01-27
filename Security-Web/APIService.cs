using Security_Web;
using System.Net.Http.Json;

namespace SecurityWeb;

public class APIService
{

    public readonly HttpClient client;

    public APIService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<User>> LoginUser(string username, string password)
    {
        var response = await client.PostAsJsonAsync<string>($"api/login/{username}/{password}", null);
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<List<User>>();
            return data;
        }
        else
        {
            return new List<User>();
        }
    }
}
