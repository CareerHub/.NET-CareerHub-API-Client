using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CareerHub.Client.Tests.Framework {
    public class GetResultFacts {

        [Fact]
        public void Default_To_Success() {
            var model = new ResultModel();
            var result = new GetResult<ResultModel>(model);
            Assert.True(result.Success);
        }

        [Fact]
        public void Content_Set_Correctly() {
            var model = new ResultModel();
            var result = new GetResult<ResultModel>(model);
            Assert.Equal(model, result.Content);
        }

        [Fact]
        public void Error_Result() {
            string msg = "error";
            var result = new GetResult<ResultModel>(msg);

            Assert.Equal(msg, result.Error);
        }

        [Fact]
        public void Error_Result_NotSuccessful() {
            string msg = "error";
            var result = new GetResult<ResultModel>(msg);

            Assert.False(result.Success);
        }
    }
}
