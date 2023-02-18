using AutoMapper;

namespace IT64_2019_URIS_ExpertCommission.Profiles
{
    public class ExpertCommissionsProfile : Profile
    {
        public ExpertCommissionsProfile() 
        {
            CreateMap<Entities.ExpertCommission, Models.ExpertCommissionDto>().ReverseMap();
        }
    }
}
