using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Experiences {
    public interface IExperiencesApi {
        Task<GetResult<ExperienceModel>> GetExperience(int id);
        Task<GetResult<IEnumerable<ExperienceModel>>> GetExperiences();
        Task<PostResult<ExperienceModel>> CreateExperience(IExperienceSubmissionModel model);
        Task<PostResult<ExperienceModel>> UpdateExperience(int id, IExperienceSubmissionModel model);
    }
}
