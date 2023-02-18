using AutoMapper;

namespace Korisnik_projekat.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Models.User.User, Models.DTO.User>()
                .ReverseMap();
        }
    }
}
