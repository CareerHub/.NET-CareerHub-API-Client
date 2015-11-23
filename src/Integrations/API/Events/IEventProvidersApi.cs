using CareerHub.Client.API.Integrations.Events.Models;
using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Events {
    public interface IEventProvidersApi {
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/events/{eventid}/providers/organisations")]
        Task<IEnumerable<OrganisationProviderModel>> GetEvents(int eventid);
    }
}
