using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Trusted.Experiences {
    public interface IExperienceTypesApi {
        Task<IEnumerable<ExpereinceTypeModel>> GetExperienceTypes();
    }
}
