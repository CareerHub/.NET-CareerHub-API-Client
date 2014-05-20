using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CareerHub.Client.API.Students.Jobs {
    internal sealed class JobsApi : IDisposable, IJobsApi {
        private const string ApiBase = "api/students/alpha/jobs";
        private readonly OAuthHttpClient client = null;

        public JobsApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<JobModel>> GetJobs() {
            return client.GetResource<IEnumerable<JobModel>>("");
		}

        public Task<IEnumerable<JobModel>> SearchJobs(string text, string location = null, int? take = null, int? skip = null) {
            if (String.IsNullOrWhiteSpace(text)) throw new ArgumentNullException("text");

            string resource = "search?text=" + text;

            if (!String.IsNullOrWhiteSpace(location)) {
                resource += "&location=" + location;
            }

            resource = UrlUtility.AddPagingParams(resource, take, skip);

            return client.GetResource<IEnumerable<JobModel>>(resource);
        }

        public Task<JobModel> GetJob(int id) {
            return client.GetResource<JobModel>(id.ToString());
        }

        public void Dispose() {
            client.Dispose();
        }
	}
}