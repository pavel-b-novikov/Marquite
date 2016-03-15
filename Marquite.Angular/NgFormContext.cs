using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public interface INgFormContext : INgContext
    {
        
    }

    public class NgFormContext<TModel> : NgContext<NgFormContextWrapper<TModel>>, INgFormContext
    {
        public NgFormContext(string formName)
            : base("FormController", formName)
        {

        }

        public NgFormContext(string controllerName, string controllerAs = null) : base(controllerName, controllerAs)
        {
        }
    }

    public enum BuiltInValidatorToken
    {
        Email,
        Max,
        Maxlength,
        Min,
        Minlength,
        Number,
        Pattern,
        Required,
        Url,
        Date,
        DatetimeLocal,
        Time,
        Week,
        Month
    }
}
