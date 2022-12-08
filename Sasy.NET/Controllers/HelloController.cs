using Microsoft.AspNetCore.Mvc;
namespace DotnetSvelteApp.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
            return "Hello World!";
    }
}