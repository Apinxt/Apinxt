using Jint.Native;

namespace Apinxt.Models
{
    public record VariableContext(string Name, JsValue Value, string ValueBinding);
}
