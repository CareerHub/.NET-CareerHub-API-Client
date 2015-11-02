using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Events {
    public interface IEventsApi {
        Task<EventModel> GetEvent(int id);
        Task<IEnumerable<EventModel>> GetEvents();
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);
    }
}
