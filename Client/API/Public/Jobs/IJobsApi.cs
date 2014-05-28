using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Public.Jobs {
    public interface IJobsApi {
        Task<JobModel> GetJob(int id);
        Task<IEnumerable<JobModel>> GetJobs();
        Task<IEnumerable<JobModel>> SearchJobs(string text, string location = null, int? take = null, int? skip = null);
    }
}
