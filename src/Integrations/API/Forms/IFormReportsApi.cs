using CareerHub.Client.Framework.Http;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Integrations.API.Forms {
    public interface IFormReportsApi {
        [OAuthJsonHeader]
        [Get("api/integrations/v1/forms/{formid}/reports/{id}")]
        Task<IEnumerable<IReadOnlyDictionary<string, string>>> GetAsync(int formid, int id);
    }
}
