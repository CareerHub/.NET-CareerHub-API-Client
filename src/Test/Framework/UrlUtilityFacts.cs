using CareerHub.Client.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CareerHub.Client.Tests.Framework {
    public class UrlUtilityFacts {

        [Fact]
        public void Add_Param_To_Empty_Resource() {
            string expected = "blah?test=one";
            string actual = UrlUtility.AddParam("blah", "test", "one");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Param_To_Resource_With_Query() {
            string expected = "blah?one=1&two=2";
            string actual = UrlUtility.AddParam("blah?one=1", "two", "2");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Param_With_Int() {
            string expected = "blah?one=1&two=2";
            string actual = UrlUtility.AddParam("blah?one=1", "two", 2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Null_Param() {
            string expected = "blah?one=1";
            string actual = UrlUtility.AddParam("blah?one=1", "two", null);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Paging_Params() {
            string expected = "blah?take=1&skip=0";
            string actual = UrlUtility.AddPagingParams("blah", take: 1, skip: 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Paging_Params_No_Take() {
            string expected = "blah?skip=0";
            string actual = UrlUtility.AddPagingParams("blah", skip: 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_Paging_Params_No_Skip() {
            string expected = "blah?take=1";
            string actual = UrlUtility.AddPagingParams("blah", take: 1);
            Assert.Equal(expected, actual);
        }
    }
}
