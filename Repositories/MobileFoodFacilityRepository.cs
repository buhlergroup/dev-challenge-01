using Models;
using Geolocation;

namespace Repositories {
    public class MobileFoodFacilityRepository: IRepository<MobileFoodFacility> {
        private readonly ICSVService _csvService;
        private string path;
        private IEnumerable<MobileFoodFacility> mobileFoodFacilities;

        public MobileFoodFacilityRepository(ICSVService csvService)
        {
            _csvService = csvService;
            path = Environment.CurrentDirectory;
            mobileFoodFacilities = _csvService.ReadCSV<MobileFoodFacility>(path + "/Resources/Mobile_Food_Facility_Permit.csv");
        }

        public IEnumerable<MobileFoodFacility> GetAll()
        {
            return mobileFoodFacilities;
        }

        public IEnumerable<MobileFoodFacilityResponse> FindByCoordinates(string item, double latitude, double longitude) {
            Coordinate origin = new Coordinate(latitude, longitude);
            CoordinateBoundaries boundaries = new CoordinateBoundaries(origin, 25);

            double minLatitude = boundaries.MinLatitude;
            double maxLatitude = boundaries.MaxLatitude;
            double minLongitude = boundaries.MinLongitude;
            double maxLongitude = boundaries.MaxLongitude;

            var result = mobileFoodFacilities
                .Where(x => x.Latitude >= minLatitude && x.Latitude <= maxLatitude)
                .Where(x => x.Longitude >= minLongitude && x.Longitude <= maxLongitude)
                .Where(x => x.FoodItems.Contains(item, StringComparison.OrdinalIgnoreCase))
                .Where(x => !x.FoodItems.Contains($"except for {item}", StringComparison.OrdinalIgnoreCase))
                .Select(result => new MobileFoodFacilityResponse()
                {
                    Name = result.Applicant,
                    Foods = result.FoodItems,
                    Distance = GeoCalculator.GetDistance(origin.Latitude, origin.Longitude, result.Latitude, result.Longitude, 1),
                    Direction = GeoCalculator.GetDirection(origin.Latitude, origin.Longitude, result.Latitude, result.Longitude)
                })
                .Where(x => x.Distance <= 1)
                .OrderBy(x => x.Distance);

            return result;
        }
    }
}
