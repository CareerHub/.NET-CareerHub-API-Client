using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Appointments {
    public interface IAppointmentBookingsApi {
        Task<GetResult<IEnumerable<AppointmentBookingModel>>> GetUpcomingAppointments();
    }
}
