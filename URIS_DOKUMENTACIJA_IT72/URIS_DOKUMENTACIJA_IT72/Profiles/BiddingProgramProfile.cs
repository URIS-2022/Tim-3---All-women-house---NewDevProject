using AutoMapper;

namespace URIS_DOKUMENTACIJA_IT72.Profiles
{
    public class BiddingProgramProfile : Profile
    {

        public BiddingProgramProfile()
        {
            CreateMap<Models.Domain.BiddingProgram, Models.DTO.BiddingProgram>()
                .ReverseMap();
        }
    }
}
