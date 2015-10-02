using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Demo.Server.Query;

namespace Demo.Server.Icon
{
    public class IconQuery : IQuery<IEnumerable<IconResult>>
    {
        public string Guid { get; set; }
    }
}
