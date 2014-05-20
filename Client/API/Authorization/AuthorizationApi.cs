using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using DotNetOpenAuth.OAuth2;
using DotNetOpenAuth.Messaging;
using System.Threading.Tasks;
using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Results;

namespace CareerHub.Client.API.Authorization {
    public sealed class AuthorizationApi {
        private readonly string BaseUrl;

		private readonly AuthorizationServerDescription ServerDescription;
		private readonly string ConsumerKey;
		private readonly string ConsumerSecret;
        private readonly WebServerClient oauthClient = null;

		public AuthorizationApi(string baseUrl, string consumerKey, string consumerSecret) {
            this.BaseUrl = baseUrl;
			
			ConsumerKey = consumerKey;
			ConsumerSecret = consumerSecret;

			var authEndpoint = new UriBuilder(BaseUrl);
			authEndpoint.Path += "/oauth/auth";
			
			var tokenEndpoint = new UriBuilder(BaseUrl);
            tokenEndpoint.Path += "/oauth/token";

			ServerDescription = new AuthorizationServerDescription {
				AuthorizationEndpoint = authEndpoint.Uri,
				TokenEndpoint = tokenEndpoint.Uri,
				ProtocolVersion = ProtocolVersion.V20
            };

            oauthClient = new WebServerClient(ServerDescription, ConsumerKey, ConsumerSecret);
		}

		public OutgoingWebResponse StartOAuth(string callback, string[] scopes) {
			var state = new AuthorizationState(scopes);
			state.Callback = new Uri(callback);

            return oauthClient.PrepareRequestUserAuthorization(state);
		}
		
		public async Task<FinishedAuthorizedModel> FinishOAuth(HttpRequestBase request, string[] scopes) {
			//Finish processing oauth
			var auth = oauthClient.ProcessUserAuthorization(request);

            var url = GetTokenInfoUrl(auth.AccessToken, scopes);

            using (var client = new OAuthHttpClient(BaseUrl, "oauth", auth.AccessToken)) {
                //Validate token is correct
                var result = await client.GetResource<TokenInfoModel>(url);

                var tokenInfo = ValidateToken(result, ConsumerKey);

                return new FinishedAuthorizedModel {
                    Audience = tokenInfo.Audience,
                    User = tokenInfo.User,
                    AccessToken = auth.AccessToken
                };
            }
		}

        internal static string GetTokenInfoUrl(string accessToken, string[] scopes) {
            if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException("accessToken");
            if (scopes == null) throw new ArgumentNullException("scopes");

            string url = "tokeninfo?access_token=" + accessToken;

            foreach (var scope in scopes) {
                url += "&scopes=" + scope;
            }

            return url;
        }
        
        private TokenInfoModel ValidateToken(GetResult<TokenInfoModel> result, string expectedAudience) {
            if (!result.Success) {
                throw new HttpException("Could not finish authorisation: " + result.Error);
            }

            var tokenInfo = result.Content;

			if (String.IsNullOrEmpty(tokenInfo.Audience) || tokenInfo.Audience != expectedAudience) {
				throw new HttpException("token with unexpected audience: " + tokenInfo.Audience);
			}

            return tokenInfo;
		}
	}
}