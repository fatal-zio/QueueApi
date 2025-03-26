using AutoMapper;

namespace QueueApi.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Entities.Status, Models.StatusDto>();
            CreateMap<Models.StatusForCreationDto, Entities.Status>();
            CreateMap<Models.StatusForUpdateDto, Entities.Status>();
        }
    }
}
