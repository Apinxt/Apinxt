using Apinxt.Tests.Handlers.Fixtures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Tests.Handlers.VariableContextHandlerTests.Data
{
    public class ShouldSetCustomStringVariableWithComplexObjectData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {   
            new object[]{ "result_var", "complex_object.StringProperty", "John", "complex_object", new DummyClass{ StringProperty = "John"} },
            new object[]{ "another_var", "complex_object.SubClass.StringProperty", "John", "complex_object", new DummyClass { SubClass = new DummyClass.DummySubClass { StringProperty = "John" } } }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
