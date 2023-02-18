using AutoMapper;

namespace URIS_DOKUMENTACIJA_IT72.Profiles
{
    public class DocumentsProfile: Profile
    { 
        public DocumentsProfile()
    {
            CreateMap<Models.Domain.Document, Models.DTO.Document>()
                .ReverseMap();
    }
    
    }
}
