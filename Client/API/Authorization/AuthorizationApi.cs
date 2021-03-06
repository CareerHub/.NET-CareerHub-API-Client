﻿using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Exceptions;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

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
                    Scope = auth.Scope,
                    AccessToken = auth.AccessToken,
                    AccessTokenExpirationUtc = auth.AccessTokenExpirationUtc,                    
                    RefreshToken = auth.RefreshToken
                };
            }
		}

        public FinishedAuthorizedModel CareerHubLoginAuthorize(string username, string password, IEnumerable<string> scopes = null) {
            var auth = oauthClient.ExchangeUserCredentialForToken(username, password, scopes);
            
            return new FinishedAuthorizedModel {
                User = username,
                Scope = auth.Scope,
                AccessToken = auth.AccessToken,
                AccessTokenExpirationUtc = auth.AccessTokenExpirationUtc,
                RefreshToken = auth.RefreshToken
            };
        }

        public FinishedAuthorizedModel GetApiClientAccessToken(IEnumerable<string> scopes = null) {
            var auth = oauthClient.GetClientAccessToken(scopes);

            return new FinishedAuthorizedModel {
                Scope = auth.Scope,
                AccessToken = auth.AccessToken,
                AccessTokenExpirationUtc = auth.AccessTokenExpirationUtc,
                RefreshToken = auth.RefreshToken
            };
        }

        public FinishedAuthorizedModel GetRefreshedTokens(string refreshToken) {
            var auth = new AuthorizationState {
                RefreshToken = refreshToken
            };

            if (oauthClient.RefreshAuthorization(auth)) {
                return new FinishedAuthorizedModel {
                    Scope = auth.Scope,
                    AccessToken = auth.AccessToken,
                    AccessTokenExpirationUtc = auth.AccessTokenExpirationUtc,
                    RefreshToken = auth.RefreshToken
                };
            }
            
            return null;
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

        private TokenInfoModel ValidateToken(TokenInfoModel tokenInfo, string expectedAudience) {
			if (String.IsNullOrEmpty(tokenInfo.Audience) || tokenInfo.Audience != expectedAudience) {
                throw new CareerHubApiException("Token with unexpected audience: " + tokenInfo.Audience);
			}

            return tokenInfo;
		}
	}
}