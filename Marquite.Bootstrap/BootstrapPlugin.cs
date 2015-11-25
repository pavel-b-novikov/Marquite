using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;
using Marquite.Core.BuilderMechanics;
using Marquite.Core.Elements;

namespace Marquite.Bootstrap
{
    public class BootstrapPlugin : IMarquitePlugin
    {
        public Core.IMarquite Marquite { get; set; }

        public void SubscribeEvents(MarquiteEventsManager eventsManager)
        {
            eventsManager.Subscribe<FormBuilder>(FormBuilderCreated, MarquiteEventsManager.EventType.TagCreated);
        }

        private void FormBuilderCreated(FormBuilder b)
        {
            IsCurrentFormHorizontal = false;
            IsCurrentFormInline = false;
        }

        public bool IsCurrentFormHorizontal { get; set; }

        public bool IsCurrentFormInline { get; set; }

        public int CurrentFormLabelWidth { get; set; }

        public int CurrentFormContentWidth { get; set; }

        public string CurrentActiveTab { get; set; }
    }
}
