using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class HelloWorldController : ControllerBase
{
    // 
    // GET: /
    [HttpGet("index")]
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /Welcome/
    [HttpGet("welcome")]
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}
