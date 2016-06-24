using CareerHub.Client.API.Integrations.Workflows.Models;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    public interface IWorkflowApi {
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/workflows/{id}")]
        Task<WorkflowModel> GetWorkflow(int id);

        [OAuthJsonHeader]
        [Get("/api/integrations/v1/workflows")]
        Task<IEnumerable<WorkflowModel>> GetWorkflows();
    }
}
