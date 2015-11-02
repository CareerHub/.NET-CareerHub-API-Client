using CareerHub.Client.Framework;
using CareerHub.Client.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CareerHub.Client.API.Authorization {
	public sealed class AuthorizationApi {
		private readonly string baseUrl;

		private readonly string consumerKey;
		private readonly string consumerSecret;

		public AuthorizationApi(string baseUrl, string consumerKey, string consumerSecret) {
			this.baseUrl = baseUrl;

			this.consumerKey = consumerKey;
			this.consumerSecret = consumerSecret;

			var authEndpoint = new UriBuilder(baseUrl);
			authEndpoint.Path += "/oauth/auth";

			var tokenEndpoint = new UriBuilder(baseUrl);
			tokenEndpoint.Path += "/oauth/token";
		}

		public AuthResult RequestResourceOwnerAuth(string username, string password, IEnumerable<string> scopes = null) {
			throw new NotImplementedException ();
		}

		public AuthResult RequestClientCredentialsAuth(IEnumerable<string> scopes = null) {
			throw new NotImplementedException ();
		}

		public AuthResult GetRefreshedTokens(string refreshToken) {
			throw new NotImplementedException ();
		}


// 		Look at this, use to validate token after it is retrieved?
		public static string GetTokenInfoUrl(string accessToken, string[] scopes) {
			if (String.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException("accessToken");
			if (scopes == null) throw new ArgumentNullException("scopes");

			string url = "tokeninfo?access_token=" + accessToken;

			foreach (var scope in scopes) {
				url += "&scopes=" + scope;
			}

			return url;
		}

//		private object ValidateToken(object tokenInfo, string expectedAudience) {
//			if (String.IsNullOrEmpty(tokenInfo.Audience) || tokenInfo.Audience != expectedAudience) {
//				throw new CareerHubApiException("Token with unexpected audience: " + tokenInfo.Audience);
//			}
//
//			return tokenInfo;
//		}
	}
}