using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class JobSeekersResponse {
        public ApiPagingInfo Paging { get; set; }

        public IEnumerable<JobSeekerModel> JobSeekers { get; set; }
    }
}
