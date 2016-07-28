﻿using CareerHub.Client.API.Integrations.Jobs.Models;
using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.Jobs {
    public interface IJobsApi {
        [OAuthJsonHeader]
        [Get("/api/integrations/v1/jobs")]
        Task<IEnumerable<JobModel>> GetJobs();

        [OAuthJsonHeader]
        [Get("/api/integrations/v1/jobs/{id}")]
        Task<JobModel> GetJob(int id);
    }
}