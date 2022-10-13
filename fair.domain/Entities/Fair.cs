using fair.domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace fair.domain.Entities
{
    public class Fair : IBaseEntity<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public string SetCens { get; set; } = null!;
        public string AreaP { get; set; } = null!;
        public int DistrictCode { get; set; }
        public string District { get; set; } = null!;
        public int SubCityHallCode { get; set; }
        public string SubCityHall { get; set; } = null!;
        public string Region5 { get; set; } = null!;
        public string Region8 { get; set; } = null!;
        public string FairName { get; set; } = null!;
        public string Register { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Number { get; set; }
        public string Neighborhood { get; set; } = null!;
        public string? Reference { get; set; }
    }
}
