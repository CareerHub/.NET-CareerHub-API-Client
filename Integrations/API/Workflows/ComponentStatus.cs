using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations.Workflows {
    public enum ComponentStatus {
		Uninitialised = 0,
		Prerequisites = 1,
		Incomplete = 2,
		Pending = 3,
		Completed = 4
    }
}
