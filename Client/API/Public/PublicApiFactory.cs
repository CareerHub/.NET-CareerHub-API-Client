using CareerHub.Client.API.Public.Events;
using CareerHub.Client.API.Public.Jobs;
using CareerHub.Client.API.Public.News;
using CareerHub.Client.API.Public.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Public {
    public sealed class PublicApiFactory {
        private readonly APIInfo info = null;
        private readonly string accessToken = null;

        public PublicApiFactory(APIInfo info, string accessToken) {
            this.info = info;
            this.accessToken = accessToken;
        }
                
        public IEventsApi GetEventsApi() {
            return new EventsApi(info.BaseUrl, accessToken);
        }
        
        public IJobsApi GetJobsApi() {
            return new JobsApi(info.BaseUrl, accessToken);
        }

        public INewsApi GetNewsApi() {
            return new NewsApi(info.BaseUrl, accessToken);
        }

        public IResourcesApi GetResourcesApi() {
            return new ResourcesApi(info.BaseUrl, accessToken);
        }

        private void RequireComponent(string name) {
            if (!info.SupportedComponents.Contains(name, StringComparer.OrdinalIgnoreCase)) {
                throw new NotSupportedException("The component " + name + " is not supported by " + info.BaseUrl);
            }
        }
    }
}
