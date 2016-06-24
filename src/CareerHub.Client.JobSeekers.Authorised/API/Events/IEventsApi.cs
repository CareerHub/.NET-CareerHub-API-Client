using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Authorised.API.Events.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public interface IEventsApi {
        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/events")]
        Task<IEnumerable<EventModel>> GetEvents();

        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/events/search")]
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);

        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/events/{id}")]
        Task<EventModel> GetEvent(int id);
    }
}
