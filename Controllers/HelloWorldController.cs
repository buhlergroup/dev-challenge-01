using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult search(string item)
    {
        string normalized = item.Trim();

        var results = mobileFoodFacilities
            .Where(x => x.FoodItems.Contains(normalized, StringComparison.OrdinalIgnoreCase))
            .Where(x => !x.FoodItems.Contains($"except for {normalized}", StringComparison.OrdinalIgnoreCase));
     
        return new JsonResult(results, new JsonSerializerOptions { PropertyNamingPolicy = null });
    }
}

internal class MobileFoodFacility
{
    public int locationid { get; set; }
    public string Applicant { get; set; }
    public string FacilityType { get; set; }
    public int cnn { get; set; }
    public string LocationDescription { get; set; }
    public string Address { get; set; }
    public string blocklot { get; set; }
    public string lot { get; set; }
    public string permit { get; set; }
    public string Status { get; set; }
    public string FoodItems { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
