using CareerHub.Client.API.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CareerHub.Client.Tests.API.Authorization {
    public class AuthorizationApiFacts {

        [Fact]
        public void Get_TokenInfo_Url() {
            string accessToken = "adsfasdfasdf";
            string scope1 = "Test.Scope.1";
            string scope2 = "Test.Scope.2";

            string expected = String.Format("tokeninfo?access_token={0}&scopes={1}&scopes={2}", accessToken, scope1, scope2);
            string actual = AuthorizationApi.GetTokenInfoUrl(accessToken, new string[] { scope1, scope2 });

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_TokenInfo_Url_Throws_Null_Access_Token() {
            Assert.Throws<ArgumentNullException>(() => {
                AuthorizationApi.GetTokenInfoUrl(null, new string[] { });
            });
        }

        [Fact]
        public void Get_TokenInfo_Url_Throws_Null_Scopes() {
            Assert.Throws<ArgumentNullException>(() => {
                AuthorizationApi.GetTokenInfoUrl("test", null);
            });
        }
    }
}
