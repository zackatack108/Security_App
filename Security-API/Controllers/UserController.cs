using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace Security_API.Controllers;

[Route("api/")]
public class UserController : Controller
{
    SecurityContext context;
    public UserController(SecurityContext context)
    {
        this.context = context;
    }

    [HttpPost("Login")]
    public Task Login([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
    {
        return Task.CompletedTask;
    }
}
