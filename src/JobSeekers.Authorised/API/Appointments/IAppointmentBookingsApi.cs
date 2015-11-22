using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Authorised.API.Appointments.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Appointments {
    public interface IAppointmentBookingsApi {
        [OAuthJsonHeader]
        [Get("api/jobseeker/v1/appointments/bookings/upcoming")]
        Task<IEnumerable<AppointmentBookingModel>> GetUpcomingAppointments();
    }
}
