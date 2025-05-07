using AutoMapper;
using Meetups.WebApp.Data;
using Meetups.WebApp.Data.Entities;
using Meetups.WebApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Meetups.WebApp.Features.Events.ViewCreatedEvents
{
    public class ViewCreatedEventsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;
        private readonly IMapper mapper;

        public ViewCreatedEventsService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
        }

        public async Task<List<EventViewModel>> GetEventsAsync()
        {
            using var context = contextFactory.CreateDbContext();
            var events = await (context.Events?.ToListAsync()??Task.FromResult(new List<Event>()));

            return mapper.Map<List<EventViewModel>>(events);
        }
    }
}
