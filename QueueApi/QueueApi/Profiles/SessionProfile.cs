using AutoMapper;

namespace QueueApi.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Entities.Session, Models.SessionDto>();
            CreateMap<Models.SessionForCreationDto, Entities.Session>();
            CreateMap<Models.SessionForUpdateDto, Entities.Session>();
            CreateMap<Entities.Session, Models.SessionWithoutEntriesDto>();
        }
    }
}
