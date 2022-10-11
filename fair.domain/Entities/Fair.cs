using fair.domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace feira.domain.Entities
{
    public class Fair : IBaseEntity<int>
    {
        public Fair()
        {
            AreaP = string.Empty;
            District = string.Empty;
            SubCityHall = string.Empty;
            Region5 = string.Empty;
            Region8 = string.Empty;
            FairName = string.Empty;
            Register = string.Empty;
            Address = string.Empty;
            Neighborhood = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
            SetCens = string.Empty;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SetCens { get; set; }
        public string AreaP { get; set; }
        public int DistrictCode { get; set; }
        public string District { get; set; }
        public int SubCityHallCode { get; set; }
        public string SubCityHall { get; set; }
        public string Region5 { get; set; }
        public string Region8 { get; set; }
        public string FairName { get; set; }
        public string Register { get; set; }
        public string Address { get; set; }
        public string? Number { get; set; }
        public string Neighborhood { get; set; }
        public string? Reference { get; set; }
    }
}
