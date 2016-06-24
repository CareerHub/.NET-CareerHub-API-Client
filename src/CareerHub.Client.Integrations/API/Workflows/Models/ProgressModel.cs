using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Workflows.Models {
    public class ProgressModel {
        public JobSeekerInfo JobSeeker { get; set; }

        public ComponentStatus Status { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
