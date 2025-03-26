using AutoMapper;

namespace QueueApi.Profiles
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<Entities.Entry, Models.EntryDto>();
            CreateMap<Models.EntryForCreationDto, Entities.Entry>();
            CreateMap<Models.EntryForUpdateDto, Entities.Entry>();
        }
    }
}
