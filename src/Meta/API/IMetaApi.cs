using Refit;
using System.Threading.Tasks;

namespace CareerHub.Client.Meta.API.Models {
    public interface IMetaApi {
        [Get("api/meta")]
        Task<RemoteAPIInfo> GetAPIInfo();
    }
}