using System;

namespace Marquite.Core
{
    public class LookupStringAttribute : Attribute
    {
        public string ClassName { get; set; }

        public LookupStringAttribute(string className)
        {
            ClassName = className;
        }
    }


    public class LookupEnumAttribute : Attribute
    {
    }
}
