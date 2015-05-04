using System.Text;

namespace Marquite.CssHoneypot
{
    public class StringSelectorBuilder : ISelectorBuilder
    {
        private bool _isMutable = false;
        private readonly StringSelectorBuilder _parent;

        public ISelectorBuilder Immutable()
        {
            _isMutable = false;
            return this;
        }

        public ISelectorBuilder Copy()
        {
            return new StringSelectorBuilder(_sb);
        }

        private string _name;

        public ISelectorBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public string Name { get { return _name; } }

        private ISelectorBuilder CaseCopy()
        {
            if (_isMutable) return this;
            return new StringSelectorBuilder(this);
        }

        private StringSelectorBuilder(StringSelectorBuilder parent)
        {
            _parent = parent;
        }

        private StringSelectorBuilder(StringBuilder existing)
        {
            _sb.Append(existing);
        }

        public StringSelectorBuilder()
        {
            
        }

        private readonly StringBuilder _sb = new StringBuilder();

        public ISelectorBuilder Pseudo(string rawPseudo)
        {
            _sb.Append(rawPseudo);
            return CaseCopy();
        }

        public ISelectorBuilder Pseudo<TArgument>(string rawPseudo, TArgument argument)
        {
            _sb.AppendFormat("{0}({1})", rawPseudo, argument);
            return CaseCopy();
        }

        public ISelectorBuilder Child()
        {
            _sb.Append(" ");
            return CaseCopy();
        }

        public ISelectorBuilder All()
        {
            _sb.Append("*");
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrContainsPrefix(string name, string value)
        {
            _sb.AppendFormat("[{0}|=\"{1}\"]",name,value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrContains(string name, string value)
        {
            _sb.AppendFormat("[{0}*=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrContainsWord(string name, string value)
        {
            _sb.AppendFormat("[{0}~=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrEndsWith(string name, string value)
        {
            _sb.AppendFormat("[{0}$=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrEquals(string name, string value)
        {
            _sb.AppendFormat("[{0}=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrNotEquals(string name, string value)
        {
            _sb.AppendFormat("[{0}!=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder WhereAttrStartsWith(string name, string value)
        {
            _sb.AppendFormat("[{0}^=\"{1}\"]", name, value);
            return CaseCopy();
        }

        public ISelectorBuilder ImmediateChild()
        {
            _sb.Append(" > ");
            return CaseCopy();
        }

        public ISelectorBuilder ImmediateChild(string selector)
        {
            _sb.AppendFormat(" > {0}",selector);
            return CaseCopy();
        }

        public ISelectorBuilder ImmediateChild(ISelectorBuilder selector)
        {
            _sb.AppendFormat(" > {0}", selector);
            return CaseCopy();
        }

        public ISelectorBuilder WithClass(string className)
        {
            if (!className.StartsWith(".")) className = "." + className;
            _sb.Append(className);
            return CaseCopy();
        }

        public ISelectorBuilder Tag(string element)
        {
            _sb.Append(element);
            return CaseCopy();
        }

        public ISelectorBuilder HasAttribute(string attribute)
        {
            _sb.AppendFormat("[{0}]", attribute);
            return CaseCopy();
        }

        public ISelectorBuilder Id(string id)
        {
            if (!id.StartsWith("#")) id = "#" + id;
            _sb.Append(id);
            return CaseCopy();
        }

        public ISelectorBuilder Union()
        {
            _sb.Append(", ");
            return CaseCopy();
        }

        public ISelectorBuilder Union(ISelectorBuilder anotherSelector)
        {
            _sb.AppendFormat(", {0}", anotherSelector);
            return CaseCopy();
        }

        public ISelectorBuilder Union(string anotherSelector)
        {
            _sb.AppendFormat(", {0}", anotherSelector);
            return CaseCopy();
        }
       
        public ISelectorBuilder WithNextAdjacent()
        {
            _sb.Append(" + ");
            return CaseCopy();
        }

        public ISelectorBuilder WithNextAdjacent(string selector)
        {
            _sb.AppendFormat(" + {0}", selector);
            return CaseCopy();
        }

        public ISelectorBuilder WithNextAdjacent(ISelectorBuilder selector)
        {
            _sb.AppendFormat(" + {0}", selector);
            return CaseCopy();
        }

        public ISelectorBuilder WithNextSiblings()
        {
            _sb.Append(" ~ ");
            return CaseCopy();
        }

        public ISelectorBuilder WithNextSiblings(string selector)
        {
            _sb.AppendFormat(" ~ {0}", selector);
            return CaseCopy();
        }

        public ISelectorBuilder WithNextSiblings(ISelectorBuilder selector)
        {
            _sb.AppendFormat(" ~ {0}", selector);
            return CaseCopy();
        }

        public IEndOfBuilder After()
        {
            _sb.Append(":after");
            return CaseCopy();
        }

        public ISelectorBuilder Mutable()
        {
            _isMutable = true;
            return this;
        }

        public IEndOfBuilder Before()
        {
            _sb.Append(":before");
            return CaseCopy();
        }

        public string Build()
        {
            if (_parent == null)
            {
                return _sb.ToString();
            }
            return _parent.Build() + _sb;
        }

        public override string ToString()
        {
            return Build();
        }
    }
}
