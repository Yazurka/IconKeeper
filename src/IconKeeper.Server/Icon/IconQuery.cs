using System.Collections.Generic;
using IconKeeper.Server.Query;

namespace IconKeeper.Server.Icon
{
    public class IconQuery : IQuery<IEnumerable<IconResult>>
    {
        public string GuidString { get; set; }
    }
}
