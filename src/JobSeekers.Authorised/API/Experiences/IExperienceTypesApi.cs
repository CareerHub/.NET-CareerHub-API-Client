using CareerHub.Client.JobSeekers.Authorised.API.Experiences.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.JobSeekers.Authorised.API.Experiences {
    public interface IExperienceTypesApi {
        [Get("api/jobseeker/v1/experiencetypes")]
        Task<IEnumerable<ExpereinceTypeModel>> GetExperienceTypes();
    }
}
