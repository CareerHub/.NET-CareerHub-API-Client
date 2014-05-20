using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Events {
    public interface IEventsApi {
        Task<GetResult<EventModel>> GetEvent(int id);
        Task<GetResult<IEnumerable<EventModel>>> GetEvents();
        Task<GetResult<IEnumerable<EventModel>>> SearchEvents(string text, int? take = null, int? skip = null);
    }
}
