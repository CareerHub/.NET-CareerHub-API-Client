using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class JobSeekerModifyOperation {
        public bool DryRun { get; set; }
        public bool SendNotifications { get; set; }

        public JobSeekerModifyModel JobSeeker { get; set; }
    }
}
