using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    internal sealed class EventBookingsApi : IDisposable, IEventBookingsApi {

        private const string ApiBase = "/api/jobseeker/v1/events";
        private readonly OAuthHttpClient client = null;

        public EventBookingsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}
		
		public Task<IEnumerable<EventModel>> GetUpcomingEvents() {
            return client.GetResource<IEnumerable<EventModel>>("bookings/upcoming");
		}

        public Task<EventBookingModel> BookEvent(int eventId) {
            return client.PostResource<EventBookingModel>(eventId + "/bookings");
        }

        public Task CancelBooking(int eventId) {
            return client.DeleteResource(eventId + "/bookings");
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}