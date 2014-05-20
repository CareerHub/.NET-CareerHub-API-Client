using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Education {
    public interface IEducationApi {
        Task<GetResult<IEnumerable<EducationModel>>> GetEducation();
        Task<GetResult<EducationModel>> GetEducation(int id);
    }
}
