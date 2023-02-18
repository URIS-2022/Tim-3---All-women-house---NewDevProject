using AutoMapper;

namespace URIS_Stages_it24.Profiles
{
    public class StageProfile : Profile
    {
        public StageProfile()
        {
            CreateMap<Models.Entities.Stage,Models.DTO.Stage>()
                .ReverseMap();
        }
    }
}
