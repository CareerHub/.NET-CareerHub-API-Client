using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Experiences {
    public interface IExperiencesApi {
        Task<ExperienceModel> GetExperience(int id);
        Task<IEnumerable<ExperienceModel>> GetExperiences();
        Task<ExperienceModel> CreateExperience(IExperienceSubmissionModel model);
        Task<ExperienceModel> UpdateExperience(int id, IExperienceSubmissionModel model);
    }
}
