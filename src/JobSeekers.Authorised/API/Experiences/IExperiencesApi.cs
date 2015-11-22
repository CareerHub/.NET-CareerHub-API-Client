using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using CareerHub.Client.JobSeekers.Authorised.API.Experiences.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Experiences {
    public interface IExperiencesApi {
        [OAuthJsonHeader]
        [Get("api/jobseeker/v1/experiences")]
        Task<IEnumerable<ExperienceModel>> GetExperiences();

        [OAuthJsonHeader]
        [Get("api/jobseeker/v1/experiences/{id}")]
        Task<ExperienceModel> GetExperience(int id);

        [OAuthJsonHeader]
        [Post("api/jobseeker/v1/experiences")]
        Task<ExperienceModel> CreateExperience([Body] IExperienceSubmissionModel model);

        [OAuthJsonHeader]
        [Put("api/jobseeker/v1/experiences")]
        Task<ExperienceModel> UpdateExperience(int id, [Body] IExperienceSubmissionModel model);
    }
}
