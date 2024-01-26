using System.Net.Http.Json;

namespace SecurityWeb;

public class APIService
{

    public readonly HttpClient client;

    public APIService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<(string, string)> LoginUser(string username, string password)
    {
        var response = await client.PostAsJsonAsync<(string, string)>($"api/login/{username}/{password}", null);
        if (response != null)
        {
            return response;
        }
        else
        {
            return ("nothing", "nothing");
        }
    }
}
