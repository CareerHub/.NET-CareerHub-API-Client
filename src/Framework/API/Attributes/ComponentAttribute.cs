using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.API.Attributes {
    public class ComponentAttribute {

        public ComponentAttribute(string componentName) {
            this.ComponentName = componentName;
        }

        public string ComponentName { get; private set; }
    }
}
