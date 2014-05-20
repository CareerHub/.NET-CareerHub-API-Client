﻿using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Resources {
    internal sealed class ResourcesApi : IDisposable, CareerHub.Client.API.Students.Resources.IResourcesApi  {
        private const string ApiBase = "api/students/alpha/resources";
        private readonly OAuthHttpClient client = null;

        public ResourcesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<GetResult<IEnumerable<ResourceModel>>> GetBookmarkedResources(int? take = null, int? skip = null) {
            string resource = "bookmarks";

            resource = UrlUtility.AddPagingParams(resource, take, skip);

            return client.GetResource<IEnumerable<ResourceModel>>(resource);
        }

        public Task<GetResult<IEnumerable<ResourceModel>>> SearchResources(string text, int? take = null, int? skip = null) {
            string resource = "search?text=" + text;
            resource = UrlUtility.AddPagingParams(resource, take, skip);
            return client.GetResource<IEnumerable<ResourceModel>>(resource);
        }
        
        public void Dispose() {
            client.Dispose();
        }
	}
}