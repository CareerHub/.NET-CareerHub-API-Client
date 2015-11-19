using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Public.API.Resources.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Resources {
    public interface IResourcesApi {
        [Get("api/public/v1/resources/bookmarks")]
        Task<IEnumerable<ResourceModel>> GetBookmarkedResources(int? take = null, int? skip = null);
        [Get("api/public/v1/resources/search")]
        Task<IEnumerable<ResourceModel>> SearchResources(string text, int? take = null, int? skip = null);
    }
}
