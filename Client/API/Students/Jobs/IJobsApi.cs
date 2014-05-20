using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Jobs {
    public interface IJobsApi {
        Task<GetResult<JobModel>> GetJob(int id);
        Task<GetResult<IEnumerable<JobModel>>> GetJobs();
        Task<GetResult<IEnumerable<JobModel>>> SearchJobs(string text, string location = null, int? take = null, int? skip = null);
    }
}
