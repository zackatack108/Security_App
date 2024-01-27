using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Security_API.Controllers;

[Route("api/")]
public class UserController : Controller
{
    private readonly string connectionString = "host=security-postgres:5432; Database=security_db; User Id=admin; Password=password";
    //private readonly string connectionString = "host=localhost:5432; Database=testdb; User Id=admin; Password=adminpwd";

    //public UserController(string connectionString)
    //{
    //    this.connectionString = connectionString;
    //}
    [HttpPost("Login/{username}/{password}")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var response = await userLogin(username, password);
        return response;
    }

    private async Task<IActionResult> userLogin(string username, string password)
    {
        List<User> users = new();
        Console.WriteLine($"DB Connection: {connectionString}");

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync(); // Use OpenAsync for asynchronous connection opening
            string sqlQuery = $"SELECT * FROM client WHERE username = '{username}' AND password= '{password}'";

            using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
            {
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    User user = new()
                    {
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString()
                    };

                    users.Add(user);
                    
                }
            }
        }

        return Ok(users);
    }

}

