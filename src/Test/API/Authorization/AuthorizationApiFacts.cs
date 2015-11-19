using CareerHub.Client.API.Authorization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CareerHub.Client.Tests.API.Authorization {
    
    public class AuthorizationApiFacts {
        private const string BaseUrl = "http://localhost";
        private const string ConsumerKey = "ConsumerKey";
        private const string ConsumerSecret = "ConsumerSecret";

        private readonly Mock<HttpClient> mockHttpClient;
        private readonly AuthorizationApi authApi;

        public AuthorizationApiFacts() {
            this.mockHttpClient = new Mock<HttpClient>();
            this.authApi = new AuthorizationApi(BaseUrl, ConsumerKey, ConsumerSecret, mockHttpClient.Object);
        }

        [Fact]
        public async Task Validate_Token_Null_Scopes() {
            SetupTokenValidation();

            await this.authApi.ValidateTokenAsync("token", null, CancellationToken.None);
        }

        [Fact]
        public async Task Send_Client_Credentials_Request() {
            SetupTokenValidation();
            SetupAccessTokenRequest();

            await this.authApi.SendClientCredentialsRequestAsync(null, CancellationToken.None);
        }

        private void SetupAccessTokenRequest() {
            var content = new StringContent("{\"access_token\":\"token\",\"expires_in\":\"600\"}");
            mockHttpClient
                .Setup(m => m.SendAsync(It.Is<HttpRequestMessage>((r) => r.Method == HttpMethod.Post && r.RequestUri.ToString() == "http://localhost/oauth/token"), It.IsAny<CancellationToken>()))
                .Returns(
                    Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                        Content = content
                    })
                )
                .Verifiable("Failed to request access token");
        }

        private void SetupTokenValidation() {
            var content = new StringContent("{\"audience\":\"" + ConsumerKey + "\"}");
            mockHttpClient
                .Setup(m => m.SendAsync(It.Is<HttpRequestMessage>((r) => r.Method == HttpMethod.Get && r.RequestUri.ToString() == "http://localhost/oauth/tokeninfo"), It.IsAny<CancellationToken>()))
                .Returns(
                    Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) {
                        Content = content
                    })
                )
                .Verifiable("Failed to request token info");
        }
    }
}
