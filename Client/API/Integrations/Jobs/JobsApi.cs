using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Jobs {
    internal class JobsApi : IJobsApi {
        private const string ApiBase = "api/integrations/v1/jobs";
        private readonly OAuthHttpClient client = null;

        public JobsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<JobModel>> GetJobs() {
            return client.GetResource<IEnumerable<JobModel>>("");
        }

        public Task<JobModel> GetJob(int id) {
            return client.GetResource<JobModel>(id.ToString());
        }
    }
}
