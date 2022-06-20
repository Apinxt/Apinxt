using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Tests.Fixtures
{
    public class DummyClass
    {
        public string StringProperty { get; set; } = "";
        public int IntProperty { get; set; }
        public bool BoolProperty { get; set; }
        public DummySubClass SubClass { get; set; } = new DummySubClass();

        public class DummySubClass
        {
            public string StringProperty { get; set; } = "";
            public int IntProperty { get; set; }
            public bool BoolProperty { get; set; }
        }
    }
}
