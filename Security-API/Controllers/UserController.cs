using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Security_API.Controllers;

[Route("api/")]
public class UserController : Controller
{

    [HttpPost("Login")]
    public Task Login([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
    {
        return Task.CompletedTask;
    }
}
