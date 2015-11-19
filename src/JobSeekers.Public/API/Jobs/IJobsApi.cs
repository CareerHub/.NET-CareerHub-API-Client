using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Public.API.Jobs.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Jobs {
    public interface IJobsApi {
        [Get("api/public/v1/jobs")]
        Task<IEnumerable<JobModel>> GetJobsAsync();
        [Get("api/public/v1/jobs/search")]
        Task<IEnumerable<JobModel>> SearchJobsAsync(string text, string location = null, int? take = null, int? skip = null);
        [Get("api/public/v1/jobs/{id}")]
        Task<JobModel> GetJobAsync(int id);
    }
}
