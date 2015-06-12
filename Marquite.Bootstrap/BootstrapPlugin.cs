using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.ElementBuilders;

namespace Marquite.Bootstrap
{
    public class BootstrapPlugin : IMarquitePlugin
    {
        public Core.Marquite Marquite { get; set; }

        public void SubscribeEvents(MarquiteEventsManager eventsManager)
        {
            eventsManager.Subscribe<FormBuilder>(FormBuilderCreated, MarquiteEventsManager.EventType.TagCreated);
        }

        private void FormBuilderCreated(FormBuilder b)
        {
            IsCurrentFormHorizontal = false;
            IsCurrentFormInline = false;
        }

        internal bool IsCurrentFormHorizontal { get; set; }

        internal bool IsCurrentFormInline { get; set; }

        internal int CurrentFormLabelWidth { get; set; }

        internal int CurrentFormContentWidth { get; set; }
    }
}
