using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Events {
    internal sealed class EventsApi : IDisposable, IEventsApi {
        private const string EventsApiBase = "api/students/alpha/events";
        private readonly OAuthHttpClient client = null;

        public EventsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, EventsApiBase, accessToken);
		}
		
		public Task<GetResult<IEnumerable<EventModel>>> GetEvents() {
            return client.GetResource<IEnumerable<EventModel>>("");
		}

        public Task<GetResult<IEnumerable<EventModel>>> SearchEvents(string text) {
            return client.GetResource<IEnumerable<EventModel>>("search?text=" + text);
        }

        public Task<GetResult<EventModel>> GetEvent(int id) {
            return client.GetResource<EventModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}