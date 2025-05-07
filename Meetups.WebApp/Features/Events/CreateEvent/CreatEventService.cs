using Meetups.WebApp.Data;
using Meetups.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class CreatEventService
    {
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;

        public CreatEventService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task CreateEventAsync(EventViewModel eventViewModel)
        {
            using var context = contextFactory.CreateDbContext();
            context.Events?.Add(new Event
            {
                Title = eventViewModel.Title,
                Description = eventViewModel.Description,
                BeginTime = eventViewModel.BeginTime,
                BeginDate = eventViewModel.BeginDate,
                EndTime = eventViewModel.EndTime,
                EndDate = eventViewModel.EndDate,
                Location = eventViewModel.Location,
                MeetupLink = eventViewModel.MeetupLink,
                Category = eventViewModel.Category,
                Capacity = eventViewModel.Capacity,
                OrganizerId = eventViewModel.OrganizerId
            });
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
