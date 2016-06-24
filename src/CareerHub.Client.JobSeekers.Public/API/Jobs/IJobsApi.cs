using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Public.API.Jobs.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Public.API.Jobs {
    public interface IJobsApi {
        [OAuthJsonHeader]
        [Get("/api/public/v1/jobs")]
        Task<IEnumerable<JobModel>> GetJobsAsync();

        [OAuthJsonHeader]
        [Get("/api/public/v1/jobs/search")]
        Task<IEnumerable<JobModel>> SearchJobsAsync(string text, string location = null, int? take = null, int? skip = null);

        [OAuthJsonHeader]
        [Get("/api/public/v1/jobs/{id}")]
        Task<JobModel> GetJobAsync(int id);
    }
}
