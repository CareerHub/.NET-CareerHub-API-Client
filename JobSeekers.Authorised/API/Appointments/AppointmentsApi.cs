using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Appointments {
    internal sealed class AppointmentBookingsApi : IDisposable, IAppointmentBookingsApi {
        
		private const string ApiBase = "api/jobseeker/v1/appointments/bookings";
        private readonly OAuthHttpClient client = null;

		public AppointmentBookingsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<AppointmentBookingModel>> GetUpcomingAppointments() {
            return client.GetResource<IEnumerable<AppointmentBookingModel>>("upcoming");
		}

        public void Dispose() {
            client.Dispose();
        }
    }    
}