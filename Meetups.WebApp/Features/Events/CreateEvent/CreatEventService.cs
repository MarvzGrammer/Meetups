namespace Meetups.WebApp.Features.Events.CreateEvent
{
    public class CreatEventService
    {
        public CreatEventService()
        {
            
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
