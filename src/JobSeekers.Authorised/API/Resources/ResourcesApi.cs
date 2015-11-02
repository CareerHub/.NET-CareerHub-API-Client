using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Resources {
    internal sealed class ResourcesApi : IDisposable, IResourcesApi  {

        private const string ApiBase = "api/jobseeker/v1/resources";
        private readonly OAuthHttpClient client = null;

        public ResourcesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<ResourceModel>> GetBookmarkedResources(int? take = null, int? skip = null) {
            string resource = "bookmarks";

            resource = UrlUtility.AddPagingParams(resource, take, skip);

            return client.GetResource<IEnumerable<ResourceModel>>(resource);
        }

        public Task<IEnumerable<ResourceModel>> SearchResources(string text, int? take = null, int? skip = null) {
            string resource = "search?text=" + text;
            resource = UrlUtility.AddPagingParams(resource, take, skip);
            return client.GetResource<IEnumerable<ResourceModel>>(resource);
        }
        
        public void Dispose() {
            client.Dispose();
        }
	}
}