using Jint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Tests.Handlers.Fixtures
{
    public class JitEngineFixture 
    {
        private Engine _jitEngine;
        public JitEngineFixture()
        {
            _jitEngine = new Engine();
        }

        public Engine JitEngine { get { return _jitEngine; } }
    }
}
