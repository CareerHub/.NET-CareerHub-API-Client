using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Client.Framework.Http {
    public class OAuthJsonHeader : HeadersAttribute {
        public OAuthJsonHeader() 
            : base ("Authorization: Bearer", "Accept: application/json") {
        }
    }
}
