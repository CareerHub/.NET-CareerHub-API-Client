using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Public.API.Events.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Events {
    public interface IEventsApi {
        [Get("api/public/v1/events")]
        Task<IEnumerable<EventModel>> GetEvents();
        [Get("api/public/v1/events")]
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);
        [Get("api/public/v1/events/{id}")]
        Task<EventModel> GetEvent(int id);
    }
}
