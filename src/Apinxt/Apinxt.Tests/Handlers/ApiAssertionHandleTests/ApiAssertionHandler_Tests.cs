using Apinxt.Handlers;
using Apinxt.Models;
using Apinxt.Tests.Handlers.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Apinxt.Tests.Handlers.ApiAssertionHandleTests
{
    public class ApiAssertionHandler_Tests : IClassFixture<JitEngineFixture>
    {
        private readonly JitEngineFixture jitEngineFixture;

        public ApiAssertionHandler_Tests(JitEngineFixture jitEngine)
        {
            jitEngineFixture = jitEngine;
        }


        [Theory]
        [InlineData("invalid-name", "1 == 1")]
        [InlineData("invalid name", "1 == 1")]
        [InlineData("4342334", "1 == 1")]
        public void ShouldReturnSuccessFalseAndErrorMessageWhenInvalidTestName(string name, string assertion)
        {
            var body = JsonConvert.DeserializeObject<dynamic>("{'teste': true}");

            var response = new Response(200, body);

            ApiAssertionHandler apiAssertionHandler = new ApiAssertionHandler(jitEngineFixture.JitEngine);
            apiAssertionHandler.SetResponseContext(response);

            var brokenTest = new ApiTestAssertion(name, assertion);

            var result = apiAssertionHandler.RunAssertions(new List<ApiTestAssertion>
            {
                brokenTest
            });

            result.Should().Contain(x => !x.Success);
            result.Should().Contain(x => !string.IsNullOrWhiteSpace(x.ErrorMessage));
        }


        [Theory]
        [InlineData("valid_name", "1 == 1")]
        [InlineData("ValidName", "1 == 1")]
        [InlineData("anotherValidName12232", "1 == 1")]
        public void ShouldReturnSuccessTrueAndEmptyErrorMessageWhenValidTestName(string name, string assertion)
        {
            var body = JsonConvert.DeserializeObject<dynamic>("{'teste': true}");

            var response = new Response(200, body);

            ApiAssertionHandler apiAssertionHandler = new ApiAssertionHandler(jitEngineFixture.JitEngine);
            apiAssertionHandler.SetResponseContext(response);

            var brokenTest = new ApiTestAssertion(name, assertion);

            var result = apiAssertionHandler.RunAssertions(new List<ApiTestAssertion>
            {
                brokenTest
            });

            result.Should().Contain(x => x.Success);
            result.Should().Contain(x => string.IsNullOrWhiteSpace(x.ErrorMessage));
        }

        [Theory]
        [InlineData("test1", "{'test': true}", "response.body.test === true")]
        [InlineData("test2", "{'name': 'John', 'last_name': 'Doe'}", "response.body.name === 'John' && response.body.last_name === 'Doe'")]
        public void ShouldReturnSuccessTrueWhenAssertionIsTrue(string testName, string bodyString, string assertion)
        {
            var body = JsonConvert.DeserializeObject<dynamic>(bodyString);

            var response = new Response(200, body);

            ApiAssertionHandler apiAssertionHandler = new ApiAssertionHandler(jitEngineFixture.JitEngine);
            apiAssertionHandler.SetResponseContext(response);

            var brokenTest = new ApiTestAssertion(testName, assertion);

            var result = apiAssertionHandler.RunAssertions(new List<ApiTestAssertion>
            {
                brokenTest
            });

            result.Should().Contain(x => x.Success);
            result.Should().Contain(x => string.IsNullOrWhiteSpace(x.ErrorMessage));
        }

        [Theory]
        [InlineData("test1", "{'test': true}", "response.body.test == false")]
        [InlineData("test2", "{'name': 'John', 'last_name': 'Doe'}", "response.body.name === 'john' || response.body.last_name === 'doe'")]
        public void ShouldReturnSuccessFalseWhenAssertionIsFalse(string testName, string bodyString, string assertion)
        {
            var body = JsonConvert.DeserializeObject<dynamic>(bodyString);

            var response = new Response(200, body);

            ApiAssertionHandler apiAssertionHandler = new ApiAssertionHandler(jitEngineFixture.JitEngine);
            apiAssertionHandler.SetResponseContext(response);

            var brokenTest = new ApiTestAssertion(testName, assertion);

            var result = apiAssertionHandler.RunAssertions(new List<ApiTestAssertion>
            {
                brokenTest
            });

            result.Should().Contain(x => !x.Success);
            result.Should().Contain(x => string.IsNullOrWhiteSpace(x.ErrorMessage));
        }

        [Theory]
        [InlineData("test1", "{'test': true}", "response.body.test = 'test'")]
        [InlineData("test2", "{'name': 'John', 'last_name': 'Doe'}", "dummy_var = 13;")]
        public void ShouldReturnSuccessFalseAndReasonFilledWhenInvalidAssertion(string testName, string bodyString, string assertion)
        {
            var body = JsonConvert.DeserializeObject<dynamic>(bodyString);

            var response = new Response(200, body);

            ApiAssertionHandler apiAssertionHandler = new ApiAssertionHandler(jitEngineFixture.JitEngine);
            apiAssertionHandler.SetResponseContext(response);

            var brokenTest = new ApiTestAssertion(testName, assertion);

            var result = apiAssertionHandler.RunAssertions(new List<ApiTestAssertion>
            {
                brokenTest
            });

            result.Should().Contain(x => !x.Success);
            result.Should().Contain(x => x.Reason == "The assertion expression doesn't return boolean");
        }

    }
}
