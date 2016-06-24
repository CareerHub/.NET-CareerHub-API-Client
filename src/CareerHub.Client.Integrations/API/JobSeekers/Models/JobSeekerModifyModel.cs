using System.Collections.Generic;

namespace CareerHub.Client.API.Integrations.JobSeekers.Models {
    public class JobSeekerModifyModel {
        public string Type { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ExternalID { get; set; }
        public string CardID { get; set; }

        public bool IsDeceased { get; set; }

        public AddressModel Address { get; set; }

        public string Phone { get; set; }
        public string Mobile { get; set; }

        public EmailAddressModifyModel PrimaryEmail { get; set; }
        public EmailAddressModifyModel BackupEmail { get; set; }

        public UserModifyModel User { get; set; }

        public List<ExtendedProperty> Properties { get; set; }
    }
}