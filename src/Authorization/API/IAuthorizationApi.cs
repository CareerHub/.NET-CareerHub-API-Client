using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Authorization {
    public interface IAuthorizationApi : IDisposable {
        Task<AuthResult> SendClientCredentialsRequestAsync(IEnumerable<string> scopes, CancellationToken cs);
        Task ValidateTokenAsync(string accessToken, IEnumerable<string> scopes, CancellationToken cs);
    }
}