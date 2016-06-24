using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Authorization {
    public sealed class AuthorizationApi : IDisposable, IAuthorizationApi {
        
        private readonly string consumerSecret;
        private readonly string authEndpoint;
        private readonly string tokenEndpoint;

        private readonly bool ownsHttpClient;
        private readonly HttpClient httpClient;

        public AuthorizationApi(HttpClient client = null, bool? disposeClient = null) {
            this.ownsHttpClient = disposeClient.HasValue ? disposeClient.Value : client == null;
            this.httpClient = client ?? new HttpClient();
        }

        public async Task<AuthResult> SendClientCredentialsRequestAsync(string baseUrl, string clientId, string clientSecret, IEnumerable<string> scopes, CancellationToken cs) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            baseUrl = FixBaseUrl(baseUrl);

            string tokenEndpoint = BuildUrl(baseUrl, "oauth/token");
            string scopeString = scopes == null ? "" : String.Join(" ", scopes);

            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
            tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                    { "grant_type", "client_credentials" },
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "scope", scopeString }
                });

            var tokenResponse = await httpClient.SendAsync(tokenRequest, cs);

            tokenResponse.EnsureSuccessStatusCode();

            string tokenContent = await tokenResponse.Content.ReadAsStringAsync();

            var tokenPayload = JObject.Parse(tokenContent);
            var accessToken = tokenPayload.Value<string>("access_token");
            var expiresIn = tokenPayload.Value<string>("expires_in");
            int expiresInSeconds = int.Parse(expiresIn);
            var expires = DateTime.UtcNow.AddSeconds(expiresInSeconds);

            await ValidateTokenAsync(baseUrl, clientId, accessToken, scopes, cs);

            return new AuthResult {
                AccessToken = accessToken,
                ExpiresUtc = expires
            };
        }

        private static string FixBaseUrl(string baseUrl) {
            if (baseUrl.EndsWith("/")) {
                baseUrl = baseUrl.TrimEnd('/');
            }

            return baseUrl;
        }

        public async Task ValidateTokenAsync(string baseUrl, string clientId, string accessToken, IEnumerable<string> scopes, CancellationToken cs) {
            if (String.IsNullOrWhiteSpace(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            baseUrl = FixBaseUrl(baseUrl);

            var validationUrl = GetTokenInfoUrl(baseUrl, scopes);
            var validationRequest = new HttpRequestMessage(HttpMethod.Get, validationUrl);
            validationRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var validationResponse = await httpClient.SendAsync(validationRequest, cs);

            validationResponse.EnsureSuccessStatusCode();
            string validationContent = await validationResponse.Content.ReadAsStringAsync();

            var validationPayload = JObject.Parse(validationContent);
            var audience = validationPayload.Value<string>("audience");

            if (clientId != audience) {
                throw new SecurityException("Client ID does not match access token audience");
            }
        }

        private string GetTokenInfoUrl(string baseUrl, IEnumerable<string> scopes) {
            string url = BuildUrl(baseUrl, "oauth/tokeninfo");

            if (scopes != null && scopes.Any()) {
                url += "?scopes=" + String.Join("&scopes=", scopes);
            }

            return url;
        }

        private static string BuildUrl(string baseUrl, string path) {
            var authEndpointBuilder = new UriBuilder(baseUrl);
            authEndpointBuilder.Path += path;
            return authEndpointBuilder.ToString();
        }

        public void Dispose() {
            if (ownsHttpClient) {
                httpClient.Dispose();
            }
        }
    }
}