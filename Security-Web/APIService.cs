namespace SecurityWeb;

public class APIService
{

    public readonly HttpClient client;

    public APIService(HttpClient client)
    {
        this.client = client;
    }

    public async Task LoginUser(string username, string password)
    {
        await client.PostAsync($"api/login/{username}/{password}", null);
    }
}
