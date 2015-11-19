using CareerHub.Client.Framework;
using CareerHub.Client.JobSeekers.Authorised.API.Experiences.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Experiences {
    public interface IExperiencesApi {
        [Get("api/jobseeker/v1/experiences")]
        Task<IEnumerable<ExperienceModel>> GetExperiences();

        [Get("api/jobseeker/v1/experiences/{id}")]
        Task<ExperienceModel> GetExperience(int id);

        [Post("api/jobseeker/v1/experiences")]
        Task<ExperienceModel> CreateExperience([Body] IExperienceSubmissionModel model);

        [Put("api/jobseeker/v1/experiences")]
        Task<ExperienceModel> UpdateExperience(int id, [Body] IExperienceSubmissionModel model);
    }
}
