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
    public sealed class AuthorizationApi {
        private readonly string baseUrl;

        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly string authEndpoint;
        private readonly string tokenEndpoint;

        public AuthorizationApi(string baseUrl, string consumerKey, string consumerSecret) {
            this.baseUrl = baseUrl;

            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;

            this.authEndpoint = BuildUrl(baseUrl, "/oauth/auth");
            this.tokenEndpoint = BuildUrl(baseUrl, "/oauth/token");
        }

        public async Task<AuthResult> SendClientCredentialsRequestAsync(IEnumerable<string> scopes, CancellationToken cs) {
            using (var client = new HttpClient()) {
                var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
                tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                    { "client_id", consumerKey },
                    { "client_secret", consumerSecret },
                    { "grant_type", "client_credentials" }
                });

                var tokenResponse = await client.SendAsync(tokenRequest, cs);

                tokenResponse.EnsureSuccessStatusCode();

                string tokenContent = await tokenResponse.Content.ReadAsStringAsync();

                var tokenPayload = JObject.Parse(tokenContent);
                var accessToken = tokenPayload.Value<string>("access_token");
                var expiresIn = tokenPayload.Value<string>("expires_in");
                int expiresInSeconds = int.Parse(expiresIn);
                var expires = DateTime.UtcNow.AddSeconds(expiresInSeconds);

                await ValidateTokenAsync(client, accessToken, scopes, cs);

                return new AuthResult {
                    AccessToken = accessToken,
                    ExpiresUtc = expires
                };
            }
        }

        public async Task ValidateTokenAsync(string accessToken, IEnumerable<string> scopes, CancellationToken cs) {
            using (var client = new HttpClient()) {
                await ValidateTokenAsync(client, accessToken, scopes, cs);
            }
        }

        private async Task ValidateTokenAsync(HttpClient client, string accessToken, IEnumerable<string> scopes, CancellationToken cs) {
            var validationUrl = GetTokenInfoUrl(scopes);
            var validationRequest = new HttpRequestMessage(HttpMethod.Get, validationUrl);
            validationRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var validationResponse = await client.SendAsync(validationRequest, cs);

            validationResponse.EnsureSuccessStatusCode();
            string validationContent = await validationResponse.Content.ReadAsStringAsync();

            var validationPayload = JObject.Parse(validationContent);
            var audience = validationPayload.Value<string>("audience");

            if (consumerKey != audience) {
                throw new SecurityException("Client ID does not match access token audience");
            }
        }

        private static string GetTokenInfoUrl(IEnumerable<string> scopes) {
            if (scopes == null) throw new ArgumentNullException("scopes");

            string url = "tokeninfo";

            if (scopes.Any()) {
                url += "?scopes=" + String.Join("&scopes=", scopes);
            }

            return url;
        }

        private static string BuildUrl(string baseUrl, string path) {
            var authEndpointBuilder = new UriBuilder(baseUrl);
            authEndpointBuilder.Path += path;
            return authEndpointBuilder.ToString();
        }
    }
}