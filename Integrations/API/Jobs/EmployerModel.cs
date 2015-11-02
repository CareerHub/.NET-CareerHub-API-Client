using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Jobs {
    public class EmployerModel {
        public int ID { get; set; }
        public string Name { get; set; }
        public EmployerType Type { get; set; }

        public string Description { get; set; }
    }
}
