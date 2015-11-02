using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Education {
    public class EducationModel {
        public int ID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Major { get; set; }
        public string Institution { get; set; }

        public bool IsCurrent { get; set; }
        public double? PercentComplete { get; set; }

        public IEnumerable<string> Disciplines { get; set; }
        public IEnumerable<string> Awards { get; set; }

        public string Year { get; set; }
        public string Load { get; set; }
        public string Status { get; set; }

        public DateTime? StartUtc { get; set; }
        public DateTime? EndUtc { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
