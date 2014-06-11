using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Students.Experiences {
    public class ExperienceSubmissionModel : IExperienceSubmissionModel {
        public string Title { get; set; }
        public string Organisation { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
