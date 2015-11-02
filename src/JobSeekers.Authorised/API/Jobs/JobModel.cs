using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Jobs {
    public class JobModel {
        public int ID { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public DateTime PublishedUtc { get; set; }
        public DateTime ExpireUtc { get; set; }

        public DateTime Publish { get; set; }
        public DateTime Expire { get; set; }

        public int EmployerID { get; set; }
        public string EmployerName { get; set; }
        public EmployerType EmployerType { get; set; }
    }
}
