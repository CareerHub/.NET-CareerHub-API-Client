using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Jobs {
    public interface IJobsApi {
        Task<JobModel> GetJob(int id);
        Task<IEnumerable<JobModel>> GetJobs();
    }
}
