using AutoMapper;

namespace URIS_DOKUMENTACIJA_IT72.Profiles
{
    public class DocumentationListProfile : Profile
    {
        public DocumentationListProfile()
        {
            CreateMap<Models.Domain.DocumentationList, Models.DTO.DocumentationList>()
                .ReverseMap();
        }
    }
}
