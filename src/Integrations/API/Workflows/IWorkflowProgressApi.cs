using CareerHub.Client.API.Integrations.Workflows.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    public interface IWorkflowProgressApi {
        [Get("api/integrations/v1/workflows/{workflowid}/progress")]
        Task<IEnumerable<ProgressModel>> Get(int workflowid);
    }
}
