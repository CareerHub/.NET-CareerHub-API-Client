using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Authorised.API.Jobs.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Jobs {
    public interface IJobsApi {
        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/jobs")]
        Task<IEnumerable<JobModel>> GetJobs();

        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/jobs/search")]
        Task<IEnumerable<JobModel>> SearchJobs(string text, string location = null, int? take = null, int? skip = null);

        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/jobs/{id}")]
        Task<JobModel> GetJob(int id);
    }
}
