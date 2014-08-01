using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Trusted.Experiences {
    internal sealed class ExperienceTypesApi : IDisposable, IExperienceTypesApi {

        private const string ApiBase = "api/trusted/v1/experiencetypes";
        private readonly OAuthHttpClient client = null;

        public ExperienceTypesApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<ExpereinceTypeModel>> GetExperienceTypes() {
            return client.GetResource<IEnumerable<ExpereinceTypeModel>>("");
        }
        
        public void Dispose() {
            client.Dispose();
        }
    }    
}