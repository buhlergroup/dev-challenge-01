using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DirectionType
    {
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }

    public class MobileFoodFacilityResponse {
        public string Name { get; set; }
        public string Foods { get; set; }
        public double Distance { get; set; }
        [Required, EnumDataType(typeof(DirectionType))] 
        public string Direction { get; set; }
    }
}
