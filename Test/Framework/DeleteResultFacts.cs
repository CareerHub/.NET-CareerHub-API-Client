using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CareerHub.Client.Tests.Framework {
    public class DeleteResultFacts {

        [Fact]
        public void Default_To_Success() {
            var result = new DeleteResult();
            Assert.True(result.Success);
        }
        
        [Fact]
        public void Error_Result() {
            string msg = "error";
            var result = new DeleteResult(msg);

            Assert.Equal(msg, result.Error);
        }

        [Fact]
        public void Error_Result_NotSuccessful() {
            string msg = "error";
            var result = new DeleteResult(msg);

            Assert.False(result.Success);
        }
    }
}
