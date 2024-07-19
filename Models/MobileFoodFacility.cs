using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusType
    {
        REQUESTED,
        ISSUED,
        APPROVED,
        SUSPEND,
        EXPIRED
    }

    public class MobileFoodFacility
    {
        public int locationid { get; set; }
        public string Applicant { get; set; }
        public int cnn { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string blocklot { get; set; }
        public string lot { get; set; }
        public string permit { get; set; }
        [Required, EnumDataType(typeof(StatusType))] 
        public StatusType Status { get; set; }
        public string FoodItems { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        [Required, Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public double Latitude { get; set; }
        [Required, Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public double Longitude { get; set; }
    }
}
