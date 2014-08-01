using CareerHub.Client.API.Trusted.Experiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Trusted {
    public sealed class TrustedApiFactory {
        private readonly APIInfo info = null;
        private readonly string accessToken = null;

        public TrustedApiFactory(APIInfo info, string accessToken) {
            this.info = info;
            this.accessToken = accessToken;
        }

        public IExperienceTypesApi GetExperienceTypesApi() {
            return new ExperienceTypesApi(info.BaseUrl, accessToken);
        }

        public IExperiencesApi GetExperiencesApi() {
            return new ExperiencesApi(info.BaseUrl, accessToken);
        }
        
        private void RequireComponent(string name) {
            if (!info.SupportedComponents.Contains(name, StringComparer.OrdinalIgnoreCase)) {
                throw new NotSupportedException("The component " + name + " is not supported by " + info.BaseUrl);
            }
        }
    }
}
