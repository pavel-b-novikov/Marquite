using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core.BuilderMechanics;

namespace Marquite.Core.ElementBuilders
{
    public interface IInputField : IHtmlBuilder
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

    public static class MarquiteInputTypeExtensions
    {
        public static bool IsCheckable(this MarquiteInputType type)
        {
            return type == MarquiteInputType.Radio || type == MarquiteInputType.CheckBox;
        }

        public static bool Is(this MarquiteInputType type,MarquiteInputType expected)
        {
            return type == expected;
        }

        public static bool IsTextual(this MarquiteInputType type)
        {
            return type == MarquiteInputType.Text 
                || type == MarquiteInputType.Password
                || type == MarquiteInputType.Date
                || type == MarquiteInputType.Datetime
                || type == MarquiteInputType.DatetimeLocal
                || type == MarquiteInputType.Email
                || type == MarquiteInputType.Month
                || type == MarquiteInputType.Number
                || type == MarquiteInputType.Range
                || type == MarquiteInputType.Search
                || type == MarquiteInputType.Tel
                || type == MarquiteInputType.Time
                || type == MarquiteInputType.Url
                || type == MarquiteInputType.Week
                || type == MarquiteInputType.Textarea
                ;
        }
    }
}
