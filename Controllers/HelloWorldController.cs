using System.Globalization;
using System.Text.Json;
using CsvHelper;
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

    // GET: /cvs/
    [HttpGet("csv")]
    public IActionResult csv()
    {
        string path = Environment.CurrentDirectory;
        var reader = new StreamReader(path + "/Resources/Mobile_Food_Facility_Permit.csv");
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        return new JsonResult(csv.GetRecords<MobileFoodFacility>(), new JsonSerializerOptions { PropertyNamingPolicy = null });
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
