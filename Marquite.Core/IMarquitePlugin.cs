using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core
{
    public interface IMarquitePlugin
    {
        IMarquite Marquite { get; set; }

        void SubscribeEvents(MarquiteEventsManager eventsManager);
    }
}
