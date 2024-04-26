using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

[ApiController]
[Route("api/")]
public class HelloWorldController: ControllerBase
{
    private readonly MobileFoodFacilityRepository _repo;

    public HelloWorldController(IRepository<MobileFoodFacility> repo)
    {
        _repo = (MobileFoodFacilityRepository?)repo;
    }

    // GET: /cvs/
    [HttpGet("facilities")]
    public IActionResult Index()
    {
        return new JsonResult(_repo.GetAll(), new JsonSerializerOptions { PropertyNamingPolicy = null });
    }

    // GET: /search/
    [HttpGet("facilities/search")]
    public IActionResult Search(string item, double latitude, double longitude)
    {
        if (item.Length < 3)
        {
            return BadRequest();
        }

        string normalized = item.Trim();

        try
        {
            var result = _repo.FindByCoordinates(normalized, latitude, longitude);

            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
