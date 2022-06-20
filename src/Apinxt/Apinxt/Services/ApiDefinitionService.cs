using Apinxt.Config;
using Apinxt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apinxt.Services
{
    public class ApiDefinitionService : FileBaseService<IList<ApiDefinition>>
    {
        public ApiDefinitionService(FileConfiguration config) : base(config, nameof(ApiDefinition))
        {
        }
    }
}
