using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.JobSeekers.Authorised.API.Appointments {
    public sealed class AppointmentBookingModel {
        public int ID { get; set; }
        public string TypeName { get; set; }

        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Consultant { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool? Attended { get; set; }
        public string Skype { get; set; }
    }
}
