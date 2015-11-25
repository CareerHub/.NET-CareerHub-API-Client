using CareerHub.Client.API.Authorization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CareerHub.Client.Tests.API.Authorization {
    
    public class AuthorizationApiFacts {
        private const string BaseUrl = "http://localhost";
        private const string ClientId = "ClientId";
        private const string ClientSecret = "ClientSecret";

        private readonly Mock<HttpClient> mockHttpClient;
        private readonly AuthorizationApi authApi;

        public AuthorizationApiFacts() {
            this.mockHttpClient = new Mock<HttpClient>();
            this.authApi = new AuthorizationApi( mockHttpClient.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Scope1 Scope2")]
        public async Task Validate_Token_Null_Scopes(string scopeString) {
            string[] scopes = GetScopes(scopeString);
            SetupTokenValidation(scopes);

            await this.authApi.ValidateTokenAsync(BaseUrl, ClientId, "token", scopes, CancellationToken.None);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Scope1 Scope2")]
        public async Task Send_Client_Credentials_Request(string scopeString) {
            string[] scopes = GetScopes(scopeString);

            SetupTokenValidation(scopes);
            SetupAccessTokenRequest(scopes);

            await this.authApi.SendClientCredentialsRequestAsync(BaseUrl, ClientId, ClientSecret, scopes, CancellationToken.None);
        }

        private static string[] GetScopes(string scopeString) {
            return String.IsNullOrWhiteSpace(scopeString) ? null : scopeString.Split(' ');
        }

        private void SetupAccessTokenRequest(IEnumerable<string> scopes) {
            var content = new StringContent("{\"access_token\":\"token\",\"expires_in\":\"600\"}");
            
            mockHttpClient
                .Setup(m => m.SendAsync(It.Is<HttpRequestMessage>(r => IsAccessTokenRequestValid(r, scopes)), It.IsAny<CancellationToken>()))
                .Returns(
                    Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                        Content = content
                    })
                )
                .Verifiable("Failed to request access token");
        }

        private static bool IsAccessTokenRequestValid(HttpRequestMessage r, IEnumerable<string> scopes) {
            if (r.Method != HttpMethod.Post) return false;
            if (r.RequestUri.ToString() != "http://localhost/oauth/token") return false;

            var formContent = r.Content as FormUrlEncodedContent;
            var content = formContent.ReadAsStringAsync().Result;
            
            string scopeString = scopes == null ? "" : String.Join("+", scopes);
            string expectedContent = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope={2}", ClientId, ClientSecret, scopeString);

            Assert.Equal(content, expectedContent);
            return true;
        }

        private void SetupTokenValidation(IEnumerable<string> scopes) {
            var content = new StringContent("{\"audience\":\"" + ClientId + "\"}");
            mockHttpClient
                .Setup(m => m.SendAsync(It.Is<HttpRequestMessage>((r) => IsTokenInfoRequestValid(r, scopes)), It.IsAny<CancellationToken>()))
                .Returns(
                    Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                        Content = content
                    })
                )
                .Verifiable("Failed to request token info");
        }

        private static bool IsTokenInfoRequestValid(HttpRequestMessage r, IEnumerable<string> scopes) {
            if (r.Method != HttpMethod.Get) return false;

            string url = "http://localhost/oauth/tokeninfo";

            if (scopes != null && scopes.Any()) {
                url += "?scopes=" + String.Join("&scopes=", scopes);
            }

            if (r.RequestUri.ToString() != url) return false;
            
            return true;
        }
    }
}
