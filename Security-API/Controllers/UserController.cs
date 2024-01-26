using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Data.SqlClient;
using System.Security;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    private void userLogin(string username, string password)
    {
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
                    Console.WriteLine(reader["username"].ToString());
                    Console.WriteLine(reader["password"].ToString());
                }
            }
        }
    }
}
  
