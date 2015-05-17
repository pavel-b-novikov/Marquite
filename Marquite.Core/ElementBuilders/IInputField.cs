using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.Core.ElementBuilders
{
    public interface IInputField
    {
        string FieldId { get; }
        string FieldName { get; }

        MarquiteInputType FieldType { get; }
    }

    public enum MarquiteInputType
    {
        Text,
        Password,
        Radio,
        CheckBox,
        Button,
        Color,
        Date,
        Datetime,
        DatetimeLocal,
        Email,
        Month,
        Number,
        Range,
        Search,
        Tel,
        Time,
        Url,
        Week,
        Hidden,
        Select,
        Textarea
    }
}
