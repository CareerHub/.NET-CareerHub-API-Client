using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Appointments {
    internal sealed class AppointmentBookingsApi : IDisposable, IAppointmentBookingsApi {
        
		private const string AppointmentsApiBase = "api/students/alpha/appointments/bookings";
        private readonly OAuthHttpClient client = null;

		public AppointmentBookingsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, AppointmentsApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<AppointmentBookingModel>>> GetUpcomingAppointments() {
            return client.GetResource<IEnumerable<AppointmentBookingModel>>("upcoming");
		}

        public void Dispose() {
            client.Dispose();
        }
    }    
}