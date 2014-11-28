using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    internal class WorkflowProgressApi : IWorkflowProgressApi {

        private const string ApiBase = "api/integrations/v1/workflows/progress";
        private readonly OAuthHttpClient client = null;

        public WorkflowProgressApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<ProgressModel>> Get(int id) {
            return client.GetResource<IEnumerable<ProgressModel>>(id.ToString());
        }
    }
}
