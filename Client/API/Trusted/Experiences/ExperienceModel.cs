using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Trusted.Experiences {
    public class ExperienceModel {
        public int ID { get; set; }
        public bool CanDelete { get; set; }

        public JobSeekerInfo JobSeeker { get; set; }

        public string Title { get; set; }
        public string Organisation { get; set; }
        public string Description { get; set; }

        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public DateTime StartUtc { get; set; }
        public DateTime? EndUtc { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public int? TypeID { get; set; }
        public string Type { get; set; }

        public int? HoursID { get; set; }
        public string Hours { get; set; }
    }
}
