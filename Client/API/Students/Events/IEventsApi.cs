using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Events {
    public interface IEventsApi {
        Task<EventModel> GetEvent(int id);
        Task<IEnumerable<EventModel>> GetEvents();
        Task<IEnumerable<EventModel>> SearchEvents(string text, int? take = null, int? skip = null);
    }
}
