using System;
using System.Collections.Generic;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class JobSeekerModel {
        public int EntityID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public bool IsProvisioned { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ExternalID { get; set; }
        public string CardID { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public AddressModel Address { get; set; }

        public EmailAddressModel PrimaryEmail { get; set; }
        public EmailAddressModel BackupEmail { get; set; }

        public IEnumerable<ExtendedProperty> ExtendedProperties { get; set; }

        public UserModel User { get; set; }

        public bool IsDeceased { get; set; }
    }
}