using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Education {
    public interface IEducationApi {
        Task<IEnumerable<EducationModel>> GetEducation();
        Task<EducationModel> GetEducation(int id);
    }
}
