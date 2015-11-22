using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Public.API.Events.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Events {
    public interface IEventsApi {

        [OAuthJsonHeader]
        [Get("api/public/v1/events")]
        Task<IEnumerable<EventModel>> GetEvents();

        [OAuthJsonHeader]
        [Get("api/public/v1/events")]
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);

        [OAuthJsonHeader]
        [Get("api/public/v1/events/{id}")]
        Task<EventModel> GetEvent(int id);
    }
}
