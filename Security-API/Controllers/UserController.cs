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
    public Task Login(string username, string password)
    {
        userLogin(username, password);
        return Task.CompletedTask;
    }

    private (string, string) userLogin(string username, string password)
    {
        var foundUser = "";
        var foundPassword = "";
        Console.WriteLine($"DB Connection: {connectionString}");
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string sqlQuery = $"SELECT * FROM client WHERE username = '{username}' AND password= '{password}'";

            using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
            {
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    foundUser = reader["username"].ToString();
                    foundUser = reader["password"].ToString();
                }
            }
        }

        return (foundUser, foundPassword);
    }
}

