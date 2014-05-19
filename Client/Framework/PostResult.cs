using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub.Client.Framework {
    public sealed class PostResult<T> : IApiResult {
        internal PostResult(T result) {
            this.Content = result;
        }

        internal PostResult(string error) {
            this.Error = error;
        }

        public T Content { get; private set; }

        public bool Success {
            get { return String.IsNullOrWhiteSpace(this.Error); }
        }

        public string Error { get; private set; }
    }
}