using System.Text.Json;
using Geolocation;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("api/")]
public class HelloWorldController : ControllerBase
{
    private readonly ICSVService _csvService;
    private string path;
    private IEnumerable<MobileFoodFacility> mobileFoodFacilities;

    public HelloWorldController(ICSVService csvService)
    {
        _csvService = csvService;

        path = Environment.CurrentDirectory;

        mobileFoodFacilities = _csvService.ReadCSV<MobileFoodFacility>(path + "/Resources/Mobile_Food_Facility_Permit.csv");
    }

    // GET: /cvs/
    [HttpGet("facilities")]
    public IActionResult index()
    {
        return new JsonResult(mobileFoodFacilities, new JsonSerializerOptions { PropertyNamingPolicy = null });
    }

    // GET: /search/
    [HttpGet("facilities/search")]
    public IActionResult search(string item, double latitude, double longitude)
    {
        if (item.Length < 3)
        {
            return BadRequest();
        }

        Coordinate origin = new Coordinate(latitude, longitude);
        CoordinateBoundaries boundaries = new CoordinateBoundaries(origin, 25);

        double minLatitude = boundaries.MinLatitude;
        double maxLatitude = boundaries.MaxLatitude;
        double minLongitude = boundaries.MinLongitude;
        double maxLongitude = boundaries.MaxLongitude;

        string normalized = item.Trim();

        try
        {
            var results = mobileFoodFacilities
                .Where(x => x.Latitude >= minLatitude && x.Latitude <= maxLatitude)
                .Where(x => x.Longitude >= minLongitude && x.Longitude <= maxLongitude)
                .Where(x => x.FoodItems.Contains(normalized, StringComparison.OrdinalIgnoreCase))
                .Where(x => !x.FoodItems.Contains($"except for {normalized}", StringComparison.OrdinalIgnoreCase))     
                .Select(result => new 
                {
                    Name = result.Applicant,
                    Foods = result.FoodItems,
                    Distance = GeoCalculator.GetDistance(origin.Latitude, origin.Longitude, result.Latitude, result.Longitude, 1),
                    Direction = GeoCalculator.GetDirection(origin.Latitude, origin.Longitude, result.Latitude, result.Longitude)
                })
                .Where(x => x.Distance <= 1)
                .OrderBy(x => x.Distance);
        
            return new JsonResult(results, new JsonSerializerOptions { PropertyNamingPolicy = null });

        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
