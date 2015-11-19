using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Authorised.API.Events.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public interface IEventsApi {
        [Get("api/jobseeker/v1/events")]
        Task<IEnumerable<EventModel>> GetEvents();
        [Get("api/jobseeker/v1/events/{id}")]
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);
        [Get("api/jobseeker/v1/events")]
        Task<EventModel> GetEvent(int id);
    }
}
