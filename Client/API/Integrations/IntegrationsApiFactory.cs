﻿using CareerHub.Client.API.Integrations.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.API.Integrations {
    public sealed class IntegrationsApiFactory {
        private readonly APIInfo info = null;
        private readonly string accessToken = null;

        public IntegrationsApiFactory(APIInfo info, string accessToken) {
            this.info = info;
            this.accessToken = accessToken;
        }

        public IWorkflowProgressApi GetWorkflowProgressApi() {
            return new WorkflowProgressApi(info.BaseUrl, accessToken);
        }
        
        private void RequireComponent(string name) {
            if (!info.SupportedComponents.Contains(name, StringComparer.OrdinalIgnoreCase)) {
                throw new NotSupportedException("The component " + name + " is not supported by " + info.BaseUrl);
            }
        }
    }
}
