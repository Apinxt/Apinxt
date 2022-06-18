using Apinxt.Handlers;
using Apinxt.Models;
using Apinxt.Tests.Handlers.Fixtures;
using Apinxt.Tests.Handlers.VariableContextHandlerTests.Data;
using FluentAssertions;
using Newtonsoft.Json;
using Jint;

namespace Apinxt.Tests.Handlers.VariableContextHandlerTests
{
    public class VariableContextHandler_Tests : IClassFixture<JitEngineFixture>
    {
        private readonly JitEngineFixture jitEngineFixture;

        public VariableContextHandler_Tests(JitEngineFixture jitEngine)
        {
            jitEngineFixture = jitEngine;
        }

        [Theory]
        [InlineData("custom_var", "'custom_value'", "custom_value" )]
        [InlineData("another_var", "'custom_value' + 1", "custom_value1")]
        [InlineData("another_bool", "'custom_value' + true", "custom_valuetrue")]
        public void ShouldSetCustomStringVariable(string variableName, string variableBinding, string expectedValue)
        {
            VariableContextHandler handler = new VariableContextHandler(jitEngineFixture.JitEngine);

            handler.SetContextVariableBinding(variableName, variableBinding);

            handler.Variables.Should().Contain(x => x.Value.IsString());
            handler.Variables.Should().Contain(x => x.Value.AsString() == expectedValue);
        }

        [Theory]
        [ClassData(typeof(ShouldSetCustomStringVariableWithComplexObjectData))]
        public void ShouldSetCustomStringVariableWithComplexObject(string variableName, string variableBinding, string expectedValue, string customObjectName, object customObject)
        {
            VariableContextHandler handler = new VariableContextHandler(jitEngineFixture.JitEngine);

            handler.SetContextVariable(customObjectName, customObject);

            handler.SetContextVariableBinding(variableName, variableBinding);

            handler.Variables.Should().Contain(x => x.Name == variableName);
            handler.Variables.Should().Contain(x => x.Name == variableName && x.Value.AsString() == expectedValue);
        }
    }
}
