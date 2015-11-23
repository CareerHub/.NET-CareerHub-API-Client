using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Events.Models {
    public class ProvidersModel {
        public IEnumerable<EventOrganisationProviderModel> Organisations { get; set; }
        public IEnumerable<AdminProvider> Administrators { get; set; }
    }
}
