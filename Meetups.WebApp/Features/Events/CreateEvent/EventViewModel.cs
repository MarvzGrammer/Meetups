using System.ComponentModel.DataAnnotations;

namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class EventViewModel
    {
        public int EventId { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string? Title { get; set; }

        
        [StringLength(maximumLength: 500)]
        public string? Description { get; set; }

        [Required]
        public DateOnly BeginDate { get; set; }

        [Required]
        public TimeOnly BeginTime { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }
        public string? Location { get; set; }
        public string? MeetupLink { get; set; }

        [Required]
        public string? Category { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public int OrganizerId { get; set; }

        public EventViewModel()
        {
            BeginDate = DateOnly.FromDateTime(DateTime.Now);
            EndDate = DateOnly.FromDateTime(DateTime.Now);
            BeginTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);

            Category = MeetupCategoriesEnum.InPerson.ToString();
        }
        public string? ValidateDates()
        {
            if (BeginDate > EndDate)
            {
                return "Begin Date should be earlier than End Date.";
            }
            if (BeginDate == EndDate && BeginTime >= EndTime)
            {
                return "Begin Time should be earlier than End Time.";
            }

            DateTime combinedBeginDateTime = new DateTime(BeginDate.Year, BeginDate.Month, BeginDate.Day, BeginTime.Hour, BeginTime.Minute, 0);
            DateTime combinedEndDateTime = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTime.Hour, EndTime.Minute, 0);

            if (combinedBeginDateTime < DateTime.Now)
            {
                return "Begin Date and Time should be in the future.";
            }

            if (combinedEndDateTime <= combinedBeginDateTime)
            {
                return "End Date and Time should be later than Begin Date and Time.";
            }

            if (combinedEndDateTime - combinedBeginDateTime > TimeSpan.FromDays(1))
            {
                return "The event duration should not exceed 24 hours.";
            }

            return string.Empty;
        }
        public string? ValidateLocation()
        {
            if (Category == MeetupCategoriesEnum.InPerson.ToString() && string.IsNullOrWhiteSpace(Location))
            {
                return "Location is required for In-Person Meetup.";
            }
            return string.Empty;
        }

        public string? ValidateMeetupLink()
        {
            if (Category == MeetupCategoriesEnum.Online.ToString() && string.IsNullOrWhiteSpace(MeetupLink))
            {
                return "The Meetup Link is required for Online Meetups.";
            }
            return string.Empty;
        }
    }
}
