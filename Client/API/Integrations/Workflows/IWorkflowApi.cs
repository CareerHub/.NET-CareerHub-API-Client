using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    public interface IWorkflowApi {
        Task<WorkflowModel> GetWorkflow(int id);
        Task<IEnumerable<WorkflowModel>> GetWorkflows();
    }
}
