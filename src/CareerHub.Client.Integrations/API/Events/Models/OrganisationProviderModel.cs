using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Events.Models {
    public class OrganisationProviderModel {
        public int ID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public string Name { get; set; }
        public string Division { get; set; }
        public string Acronym { get; set; }

        public string BusinessID { get; set; }

        public string Description { get; set; }

        public string Website { get; set; }

        public bool HideFromStudents { get; set; }

        public string Scope { get; set; }
        public string Size { get; set; }
        public string Industries { get; set; }
    }
}
