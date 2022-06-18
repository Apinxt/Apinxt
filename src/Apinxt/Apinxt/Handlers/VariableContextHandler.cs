using Apinxt.Models;
using Jint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Handlers
{
    public class VariableContextHandler
    {
        private readonly Engine _jintEngine;        
        private List<VariableContext> _variables = new List<VariableContext>();

        public IReadOnlyList<VariableContext> Variables { get { return _variables.AsReadOnly(); } }

        public VariableContextHandler(Engine jintEngine) => _jintEngine = jintEngine;

        public void SetContextVariableBinding(string name, string valueBinding)
        {   
            _jintEngine.Execute($"var {name} = {valueBinding}");
            var value = _jintEngine.GetValue(name);
            _variables.Add(new VariableContext(name, value, valueBinding));
        }

        public void SetContextVariable(string name, object value)
        {
            _jintEngine.SetValue(name, value);
            var jsValue = _jintEngine.GetValue(name);
            _variables.Add(new VariableContext(name, jsValue, ""));
        }
    }
}
