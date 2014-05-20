using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Students.Resources {
    public interface IResourcesApi {
        Task<GetResult<IEnumerable<ResourceModel>>> SearchResources(string text, int? take = null, int? skip = null);
    }
}
