using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    /// <summary>
    /// Options to apply to the current model
    /// </summary>
    public class NgModelOptions
    {
        public NgModelOptions()
        {
            Debounces = new Dictionary<string, int>();
        }

        /// <summary>
        /// String specifying which event should the input be bound to. 
        /// You can set several events using an space delimited list. 
        /// There is a special event called default that matches the default events belonging of the control.
        /// </summary>
        public string UpdateOn { get; set; }

        /// <summary>
        /// Integer value which contains the debounce model update value in milliseconds. 
        /// A value of 0 triggers an immediate update. 
        /// If an object is supplied instead, you can specify a custom value for each event.
        /// </summary>
        public int Debounce { get; set; }

        /// <summary>
        /// The same as Debounce but supports specifying debounce for several events.
        /// If there are any debounces in this dictionary then Debounce int value will be ignored.
        /// </summary>
        public Dictionary<string, int> Debounces { get; set; }

        /// <summary>
        /// Boolean value which indicates that the model can be set with 
        /// values that did not validate correctly instead of the default 
        /// behavior of setting the model to undefined.
        /// </summary>
        public bool AllowInvalid { get; set; }

        /// <summary>
        /// Boolean value which determines whether or not to treat functions bound to ngModel as getters/setters.
        /// </summary>
        public bool GetterSetter { get; set; }

        /// <summary>
        /// Defines the timezone to be used to read/write the Date instance in the model for 
        /// &lt;input type="date"&gt;, &lt;input type="time"&gt;, ... . 
        /// It understands UTC/GMT and the continental US time zone abbreviations, 
        /// but for general use, use a time zone offset, for example, '+0430' 
        /// (4 hours, 30 minutes east of the Greenwich meridian) 
        /// If not specified, the timezone of the browser will be used.
        /// </summary>
        public string Timezone { get; set; }

        public override string ToString()
        {
            List<string> attributes = new List<string>();
            if (!string.IsNullOrEmpty(UpdateOn)) attributes.Add(String.Format("updateOn: {0}", UpdateOn.QuoteSafe()));
            if (Debounces.Count > 0)
            {
                var debounces = Debounces.Select(c => string.Format("{0}:{1}", c.Key.QuoteSafe(), c.Value)).ToArray();
                string debouncesStr = String.Join(", ", debounces);
                attributes.Add(String.Format("debounce: {{ {0} }}", debouncesStr));
            }
            else
            {
                if (Debounce > 0) attributes.Add(String.Format("debounce: {0}", Debounce));
            }

            if (AllowInvalid) attributes.Add("allowInvalid: true");
            if (GetterSetter) attributes.Add("getterSetter: true");
            if (!string.IsNullOrEmpty(Timezone)) attributes.Add(String.Format("timezone: {0}", Timezone.QuoteSafe()));

            var attributesConcat = string.Join(", ", attributes);
            return String.Format("{{ {0} }}", attributesConcat);
        }
    }
}
