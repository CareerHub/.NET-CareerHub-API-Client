using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    internal class WorkflowApi : IWorkflowApi {
        private const string ApiBase = "api/integrations/v1/workflows";
        private readonly OAuthHttpClient client = null;

        public WorkflowApi(string baseUrl, string accessToken) {
            client = new OAuthHttpClient(baseUrl, ApiBase, accessToken);
		}

        public Task<IEnumerable<WorkflowModel>> GetWorkflows() {
            return client.GetResource<IEnumerable<WorkflowModel>>("");
        }

        public Task<WorkflowModel> GetWorkflow(int id) {
            return client.GetResource<WorkflowModel>(id.ToString());
        }
    }
}
