using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Workflows {
    public interface IWorkflowProgressApi {
        Task<IEnumerable<ProgressModel>> Get(int id);
    }
}
