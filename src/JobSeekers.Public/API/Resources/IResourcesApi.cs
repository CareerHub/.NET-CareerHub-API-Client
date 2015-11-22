using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Public.API.Resources.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Resources {
    public interface IResourcesApi {
        [OAuthJsonHeader]
        [Get("api/public/v1/resources/bookmarks")]
        Task<IEnumerable<ResourceModel>> GetBookmarkedResources(int? take = null, int? skip = null);

        [OAuthJsonHeader]
        [Get("api/public/v1/resources/search")]
        Task<IEnumerable<ResourceModel>> SearchResources(string text, int? take = null, int? skip = null);
    }
}
