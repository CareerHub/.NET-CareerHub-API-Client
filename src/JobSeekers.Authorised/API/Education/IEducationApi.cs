using CareerHub.Client.Framework;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Education.Models {
    public interface IEducationApi {
        [Get("api/jobseeker/v1/education")]
        Task<IEnumerable<EducationModel>> GetEducation();
        [Get("api/jobseeker/v1/education/{id}")]
        Task<EducationModel> GetEducation(int id);
    }
}
