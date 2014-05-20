﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareerHub.Client.Framework.Results {
    public sealed class GetResult<T> : IApiResult {
        internal GetResult(T result) {
            this.Content = result;
        }

        internal GetResult(string error) {
            this.Error = error;
        }

        public T Content { get; private set; }

        public bool Success {
            get { return String.IsNullOrWhiteSpace(this.Error); }
        }

        public string Error { get; private set; }
    }
}