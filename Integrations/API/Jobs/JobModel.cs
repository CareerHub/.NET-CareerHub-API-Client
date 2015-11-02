using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Jobs {
    public class JobModel {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public DateTime Added { get; set; }
        public DateTime Publish { get; set; }
        public DateTime? Expire { get; set; }

        public string EmploymentType { get; set; }
        public ContractType? ContractType { get; set; }
        public ContractHours? ContractHours { get; set; }
        public string CommencementDate { get; set; }
        public string Remuneration { get; set; }
        public string NumPositions { get; set; }
        public string ExternalCode { get; set; }

        public string URL { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string ResidencyRequirements { get; set; }

        public string ApplicationProcedures { get; set; }
        public DisplayContactModel DisplayContact { get; set; }

        public EmployerModel Employer { get; set; }
    }
}
