using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marquite.Core;

namespace Marquite.CssHoneypot.Css.Values
{
    /// <summary>
    /// Item length
    /// </summary>
    [ValueReference("<length>")]
    [ValueReference("<percentage>")]
    public struct Length
    {
        public static Length Percents(int value)
        {
            return new Length(value, LengthUnit.Percentage);
        }

        public static Length Value(int value, LengthUnit units = LengthUnit.NoUnits)
        {
            return new Length(value,units);
        }

        public static Length Value(double value, LengthUnit units = LengthUnit.NoUnits)
        {
            return new Length(value, units);
        }

        private readonly double _value;
        private readonly LengthUnit _units;
        private readonly string _renderedValue;

        private Length(double value, LengthUnit units)
        {
            _value = value;
            _units = units;
            var lkup = units != LengthUnit.NoUnits ? Lookups.Lookup(units) : null;
            _renderedValue = String.Format("{0:0.0}{1}", value, lkup);
        }

        public double Number
        {
            get { return _value; }
        }

        public LengthUnit Units
        {
            get { return _units; }
        }

        public override string ToString()
        {
            return _renderedValue;
        }

        public bool Equals(Length other)
        {
            return _value.Equals(other._value) && _units == other._units;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Length && Equals((Length) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_value.GetHashCode()*397) ^ (int) _units;
            }
        }

        private sealed class ValueUnitsEqualityComparer : IEqualityComparer<Length>
        {
            public bool Equals(Length x, Length y)
            {
                return x._value.Equals(y._value) && x._units == y._units;
            }

            public int GetHashCode(Length obj)
            {
                unchecked
                {
                    return (obj._value.GetHashCode()*397) ^ (int) obj._units;
                }
            }
        }

        private static readonly IEqualityComparer<Length> ValueUnitsComparerInstance = new ValueUnitsEqualityComparer();

        public static IEqualityComparer<Length> ValueUnitsComparer
        {
            get { return ValueUnitsComparerInstance; }
        }


    }

    [LookupEnum]
    public enum LengthUnit
    {
        [LookupString("")]
        NoUnits,

        /// <summary>
        /// the 'font-size' of the relevant font
        /// </summary>
        [LookupString("em")]
        Em,

        /// <summary>
        /// the 'x-height' of the relevant font
        /// </summary>
        [LookupString("ex")]
        Ex,

        /// <summary>
        /// inches — 1in is equal to 2.54cm.
        /// </summary>
        [LookupString("in")]
        In,

        /// <summary>
        /// centimeters
        /// </summary>
        [LookupString("cm")]
        Cm,

        /// <summary>
        /// millimeters
        /// </summary>
        [LookupString("mm")]
        Mm,

        /// <summary>
        /// points 
        /// </summary>
        [LookupString("pt")]
        Pt,

        /// <summary>
        /// picas 
        /// </summary>
        [LookupString("pc")]
        Pc,

        /// <summary>
        /// pixel units — 1px is equal to 0.75pt
        /// </summary>
        [LookupString("px")]
        Px,

        /// <summary>
        /// Percentage
        /// </summary>
        [LookupString("%")]
        Percentage
    }
}
