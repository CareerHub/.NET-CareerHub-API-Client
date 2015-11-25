using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Authorization {
    public interface IAuthorizationApi : IDisposable {
        Task<AuthResult> SendClientCredentialsRequestAsync(string baseUrl, string consumerKey, string consumerSecret, IEnumerable<string> scopes, CancellationToken cs);
        Task ValidateTokenAsync(string baseUrl, string clientId, string accessToken, IEnumerable<string> scopes, CancellationToken cs);
    }
}