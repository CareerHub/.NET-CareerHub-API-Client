using CareerHub.Client.API.Integrations.JobSeekers.Models;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.JobSeekers {
    public interface IJobSeekersApi {
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/jobseekers")]
        Task<JobSeekersResponse> GetJobSeekers(string token, int? skip, int? take);
        
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/jobseekers/{id}")]
        Task<JobSeekersResponse> GetJobSeeker(int id);


        [OAuthJsonHeader]
        [Post("/api/integrations/v1/jobseekers/{id}")]
        Task<JobSeekersResponse> CreateJobSeeker(int id, [Body] JobSeekerModifyOperation operation);

        [OAuthJsonHeader]
        [Put("/api/integrations/v1/jobseekers/{id}")]
        Task<JobSeekersResponse> UpdateJobSeeker(int id, [Body] JobSeekerModifyOperation operation);

        [OAuthJsonHeader]
        [Delete("/api/integrations/v1/jobseekers/{id}")]
        Task<JobSeekersResponse> DeleteJobSeeker(int id);
    }
}
