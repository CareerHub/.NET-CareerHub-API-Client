using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerHub.Client.Framework {
    internal class UrlUtility {

        public static string AddPagingParams(string url, int? take = null, int? skip = null) {
            url = AddParam(url, "take", take);
            url = AddParam(url, "skip", skip);
            
            return url;
        }

        public static string AddParam(string url, string name, object param) {
            if (param == null) {
                return url;
            }
            
            string separator = "&";

            if (!url.Contains("?")) {
                separator = "?";
            }

            return String.Format("{0}{1}{2}={3}", url, separator, name, param);
        }


    }
}
