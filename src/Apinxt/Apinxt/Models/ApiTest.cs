using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Models
{
    public record ApiTest(string Name, string Assertion);

    public record ApiTestVariable(string Name, string Expression)
    {
        public Guid UniqueId = Guid.NewGuid();
    }
}
