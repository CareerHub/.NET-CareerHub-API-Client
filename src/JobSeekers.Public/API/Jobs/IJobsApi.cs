using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Public.API.Jobs.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Jobs {
    public interface IJobsApi {
        [Get("api/public/v1/jobs")]
        Task<IEnumerable<JobModel>> GetJobs();
        [Get("api/public/v1/jobs/search")]
        Task<IEnumerable<JobModel>> SearchJobs(string text, string location = null, int? take = null, int? skip = null);
        [Get("api/public/v1/jobs/{id}")]
        Task<JobModel> GetJob(int id);
    }
}
