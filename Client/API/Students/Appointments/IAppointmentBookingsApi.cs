using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Appointments {
    public interface IAppointmentBookingsApi {
        Task<GetResult<IEnumerable<AppoinmentBookingModel>>> GetUpcomingAppointments();
    }
}
