using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Security_API.Controllers;

[Route("api/")]
public class UserController : Controller
{
    private readonly string connectionString;

    public UserController( string connectionString)
    {
        this.connectionString = connectionString;
    }

    [HttpPost("Login")]
    public Task Login([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
    {
        userLogin(username, password);
        return Task.CompletedTask;
    }

    private void userLogin(string username, string password)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string sqlQuery = $"SELECT * FROM client WHERE username = '{username}' AND password= '{password}'";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
  
