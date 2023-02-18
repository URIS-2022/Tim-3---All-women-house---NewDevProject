using AutoMapper;

namespace URIS_DOKUMENTACIJA_IT72.Profiles
{
    public class DecisionsProfile: Profile
    {

        public DecisionsProfile()
        {
            CreateMap<Models.Domain.Decision, Models.DTO.Decision>()
                .ReverseMap();
           
        }
    }
}
