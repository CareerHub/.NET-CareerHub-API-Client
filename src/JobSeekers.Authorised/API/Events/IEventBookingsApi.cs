using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Authorised.API.Events.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public interface IEventBookingsApi {
        [Get("api/jobseeker/v1/events/{eventId}/bookings/upcoming")]
        Task<IEnumerable<EventModel>> GetUpcomingEvents();

        [Post("api/jobseeker/v1/events/{eventId}/bookings")]
        Task<EventBookingModel> BookEvent(int eventId);

        [Delete("api/jobseeker/v1/events/{eventId}/bookings")]
        Task CancelBooking(int eventId);
    }
}
