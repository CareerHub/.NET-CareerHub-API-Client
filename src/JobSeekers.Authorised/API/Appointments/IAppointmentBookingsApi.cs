using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Appointments {
    public interface IAppointmentBookingsApi {
        Task<IEnumerable<AppointmentBookingModel>> GetUpcomingAppointments();
    }
}
