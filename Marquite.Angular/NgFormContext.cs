using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Angular
{
    public class NgFormContext<TModel> : NgContext<NgFormContextWrapper<TModel>>
    {
        public NgFormContext(string formName)
        {
            ModelName = formName;
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
