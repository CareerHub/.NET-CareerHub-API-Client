using System;

namespace CareerHub.Client.API.Authorization {
	public class AuthResult {
		public string AccessToken { get; internal set; }
        public DateTime ExpiresUtc { get; internal set; }
    }
}

