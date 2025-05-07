using AutoMapper;
using Meetups.WebApp.Data;
using Meetups.WebApp.Data.Entities;
using Meetups.WebApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class CreatEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;
        private readonly IMapper mapper;

        public CreatEventService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task CreateEventAsync(EventViewModel eventViewModel)
        {
            using var context = contextFactory.CreateDbContext();

            var eventEntity = mapper.Map<Event>(eventViewModel);
            context.Events?.Add(eventEntity);
            await context.SaveChangesAsync();
        }

        public string? ValidateEvent(EventViewModel eventViewModel)
        {
            if (eventViewModel == null)
            {
                return "Event is null.";
            }

            string? errorMessage = string.Empty;

            errorMessage = eventViewModel.ValidateDates();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = eventViewModel.ValidateLocation();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }

            errorMessage = eventViewModel.ValidateMeetupLink();
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                return errorMessage;
            }


            return string.Empty;
        }
    }
}
