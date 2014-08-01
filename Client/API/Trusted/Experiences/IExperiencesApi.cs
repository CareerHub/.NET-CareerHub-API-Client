﻿using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Trusted.Experiences {
    public interface IExperiencesApi {
        Task<IEnumerable<ExpereinceTypeModel>> GetExperienceTypes();

        Task<ExperienceModel> GetExperience(string studentid, int id);
        Task<IEnumerable<ExperienceModel>> GetExperiences(string studentid);
        Task<ExperienceModel> CreateExperience(string studentid, IExperienceSubmissionModel model);
        Task<ExperienceModel> UpdateExperience(string studentid, int id, IExperienceSubmissionModel model);
    }
}
