using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    /// <summary>
    /// Context for event binding 
    /// </summary>
    /// <typeparam name="TModel">Your ViewModel</typeparam>
    public class NgEventContext<TModel>
    {
        /// <summary>
        /// Event object exposed as $event
        /// </summary>
        [OverrideName("$event")]
        public IEvent Event { get; set; }

        /// <summary>
        /// ViewModel. All properties will be routed to current scope
        /// </summary>
        [IsModel]
        public TModel Model { get; set; }

        /// <summary>
        /// Denotes variable of specified type from specified name. 
        /// This method is used only while parsering expressions. Dont call it ever.
        /// </summary>
        /// <param name="varName">Variable name</param>
        /// <returns>Mock.</returns>
        [CustomMethodCallTranslation(typeof(Translations), "TranslateVar")]
        public T Var<T>(string varName)
        {
            throw new Exception("This method is used only while parsering expressions. Dont call it ever.");
        }
    }
}
