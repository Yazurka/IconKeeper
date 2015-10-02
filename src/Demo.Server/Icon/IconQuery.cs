using System.Collections.Generic;

using Demo.Server.Query;

namespace Demo.Server.Icon
{
    public class IconQuery : IQuery<IEnumerable<IconResult>>
    {
        public string Guid { get; set; }
    }
}
