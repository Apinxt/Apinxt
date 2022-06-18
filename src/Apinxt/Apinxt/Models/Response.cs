using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Models
{
    public record Response(int StatusCode, dynamic Body);
}
