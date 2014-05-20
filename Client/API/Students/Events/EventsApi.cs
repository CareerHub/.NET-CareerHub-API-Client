﻿using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
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

        public Task<GetResult<IEnumerable<EventModel>>> SearchEvents(string text, int? take = null, int? skip = null) {
            string resource = "search?text=" + text;            
            resource = UrlUtility.AddPagingParams(resource, take, skip);

            return client.GetResource<IEnumerable<EventModel>>(resource);
        }

        public Task<GetResult<EventModel>> GetEvent(int id) {
            return client.GetResource<EventModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}