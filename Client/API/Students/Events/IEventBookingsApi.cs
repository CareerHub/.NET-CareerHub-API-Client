using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Events {
    public interface IEventBookingsApi {
        Task<EventBookingModel> BookEvent(int eventId);
        Task CancelBooking(int eventId);
        Task<IEnumerable<EventModel>> GetUpcomingEvents();
    }
}
