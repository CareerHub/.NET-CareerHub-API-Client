using CareerHub.Client.API.Integrations.Workflows.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    public interface IWorkflowApi {
        [Get("api/integrations/v1/workflows/{id}")]
        Task<WorkflowModel> GetWorkflow(int id);

        [Get("api/integrations/v1/workflows")]
        Task<IEnumerable<WorkflowModel>> GetWorkflows();
    }
}
