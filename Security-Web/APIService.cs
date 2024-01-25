namespace SecurityWeb;

public class APIService
{

    public readonly HttpClient client;

    public APIService(HttpClient client)
    {
        this.client = client;
    }

    public void LoginUser(string username, string password)
    {

    }
}
