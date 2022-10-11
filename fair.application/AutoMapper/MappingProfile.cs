using AutoMapper;
using fair.application.DTO;
using fair.domain.Entities;

namespace fair.application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FairDTO, Fair>();
            CreateMap<Fair, FairDTO>();
        }
    }
}
