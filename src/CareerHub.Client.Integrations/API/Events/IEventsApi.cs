using CareerHub.Client.API.Integrations.Events.Models;
using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Events {
    public interface IEventsApi {
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/events")]
        Task<IEnumerable<EventModel>> GetEvents();
        
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/events/{id}")]
        Task<EventModel> GetEvent(int id);

        [OAuthJsonHeader]
        [Get("/api/integrations/v1/events/current")]
        Task<IEnumerable<EventModel>> GetCurrentEvents();

        [OAuthJsonHeader]
        [Get("/api/integrations/v1/events/published")]
        Task<IEnumerable<EventModel>> GetPublishedEvents();
    }
}
