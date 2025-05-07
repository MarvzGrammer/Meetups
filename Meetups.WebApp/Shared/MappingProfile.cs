using AutoMapper;

namespace Meetups.WebApp.Shared
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Features.Events.CreateEvent.EventViewModel, Data.Entities.Event>();
            CreateMap<Data.Entities.Event, Features.Events.CreateEvent.EventViewModel>();

        }
    }
}
