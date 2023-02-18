using AutoMapper;

namespace IT64_2019_URIS_ExpertCommission.Profiles
{
    public class MembersProfile : Profile
    {
        public MembersProfile() 
        {
            CreateMap<Entities.Member, Models.MemberDto>().ReverseMap();

            CreateMap<Entities.ExpertCommission, Models.ExpertCommissionDto>().ReverseMap();

        }
    }
}
