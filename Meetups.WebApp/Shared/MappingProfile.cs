using AutoMapper;
using Meetups.WebApp.Shared.ViewModels;

namespace Meetups.WebApp.Shared
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<EventViewModel, Data.Entities.Event>();
            CreateMap<Data.Entities.Event, EventViewModel>();

        }
    }
}
