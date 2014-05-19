using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Events {
    public interface IEventBookingsApi {
        Task<PostResult<EventBookingModel>> BookEvent(int eventId);
        Task<DeleteResult> CancelBooking(int eventId);
        Task<GetResult<IEnumerable<EventModel>>> GetUpcomingEvents();
    }
}
