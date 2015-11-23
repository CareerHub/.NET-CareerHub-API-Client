using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Education.Models {
    public interface IEducationApi {
        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/education")]
        Task<IEnumerable<EducationModel>> GetEducation();

        [OAuthJsonHeader]
        [Get("/api/jobseeker/v1/education/{id}")]
        Task<EducationModel> GetEducation(int id);
    }
}
