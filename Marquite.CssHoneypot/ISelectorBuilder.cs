using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Marquite.CssHoneypot
{
    public interface ISelectorBuilder : IEndOfBuilder
    {
        /// <summary>
        /// Applies undefined in enums pseudo class
        /// </summary>
        /// <param name="rawPseudo">Raw pseudoclass name, containing leading ":"</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Pseudo(string rawPseudo);

        /// <summary>
        /// Applies undefined in enums pseudo class
        /// </summary>
        /// <param name="rawPseudo">Raw pseudoclass name, containing leading ":"</param>
        /// <param name="argument">Pseudo selector argument</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Pseudo<TArgument>(string rawPseudo, TArgument argument);
       
        /// <summary>
        /// Selects all elements that are descendants of a given ancestor. 
        /// Equals to (“ancestor descendant”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Child();

        /// <summary>
        /// Selects all elements. 
        /// Equals to "*"
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder All();

        /// <summary>
        /// Selects elements that have the specified attribute with a value either equal to a given string or starting with that string followed by a hyphen (-). 
        /// Equals to [name|="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrContainsPrefix(string name, string value);

        /// <summary>
        /// Selects elements that have the specified attribute with a value containing a given substring. 
        /// Equals to [name*="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrContains(string name, string value);

        /// <summary>
        /// Selects elements that have the specified attribute with a value containing a given word, delimited by spaces.
        /// Equals to [name~="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrContainsWord(string name, string value);

        /// <summary>
        /// Selects elements that have the specified attribute with a value ending exactly with a given string. The comparison is case sensitive. 
        /// Equals to [name$="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrEndsWith(string name, string value);

        /// <summary>
        /// Selects elements that have the specified attribute with a value exactly equal to a certain value.
        /// Equals to [name="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrEquals(string name, string value);

        /// <summary>
        /// Select elements that either don’t have the specified attribute, or do have the specified attribute but not with a certain value.
        /// Equals to [name!="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrNotEquals(string name, string value);

        /// <summary>
        /// Selects elements that have the specified attribute with a value beginning exactly with a given string.
        /// Equals to [name^="value"]
        /// </summary>
        /// <param name="name">An attribute name</param>
        /// <param name="value">An attribute value. Can be either an unquoted single word or a quoted string</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WhereAttrStartsWith(string name, string value);

        /// <summary>
        /// Selects all direct child elements specified by “child” of elements specified by “parent”.
        /// Equals to (“parent > child”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder ImmediateChild();

        /// <summary>
        /// Selects all direct child elements specified by “child” of elements specified by “parent”.
        /// Equals to (“parent > child”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder ImmediateChild(string selector);

        /// <summary>
        /// Selects all direct child elements specified by “child” of elements specified by “parent”.
        /// Equals to (“parent > child”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder ImmediateChild(ISelectorBuilder selector);

        /// <summary>
        /// Selects all elements with the given class. 
        /// Equals to ".class"
        /// </summary>
        /// <param name="className">A class to search for. An element can have multiple classes; only one of them must match.</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithClass(string className);

        /// <summary>
        /// Selects all elements with the given tag name. 
        /// Equals to "element"
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Tag(string element);

        /// <summary>
        /// Selects elements that have the specified attribute, with any value. 
        /// Equals to [name]
        /// </summary>
        /// <param name="attribute">An attribute name.</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder HasAttribute(string attribute);

        /// <summary>
        /// Selects a single element with the given id attribute. 
        /// Equals to "#id"
        /// </summary>
        /// <param name="id">An ID to search for, specified via the id attribute of an element.</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Id(string id);


        /// <summary>
        /// Selects the combined results of all the specified selectors.
        /// Equals to (“thisSelector1, anotherSelector”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Union();

        /// <summary>
        /// Selects the combined results of all the specified selectors.
        /// Equals to (“thisSelector1, anotherSelector”)
        /// </summary>
        /// <param name="anotherSelector">Any valid selector.</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Union(ISelectorBuilder anotherSelector);

        /// <summary>
        /// Selects the combined results of all the specified selectors.
        /// Equals to (“thisSelector1, anotherSelector”)
        /// </summary>
        /// <param name="anotherSelector">Any valid selector.</param>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder Union(string anotherSelector);

        /// <summary>
        /// Selects all next elements matching next selector that are immediately preceded by this sibling. 
        /// Equals to (“prev + next”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextAdjacent();

        /// <summary>
        /// Selects all next elements matching next selector that are immediately preceded by this sibling. 
        /// Equals to (“prev + next”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextAdjacent(string selector);

        /// <summary>
        /// Selects all next elements matching next selector that are immediately preceded by this sibling. 
        /// Equals to (“prev + next”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextAdjacent(ISelectorBuilder selector);

        /// <summary>
        /// Selects all sibling elements that follow after the “prev” element, have the same parent, and match the filtering “siblings” selector. 
        /// Equals to (“prev ~ siblings”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextSiblings();

        /// <summary>
        /// Selects all sibling elements that follow after the “prev” element, have the same parent, and match the filtering “siblings” selector. 
        /// Equals to (“prev ~ siblings”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextSiblings(string selector);

        /// <summary>
        /// Selects all sibling elements that follow after the “prev” element, have the same parent, and match the filtering “siblings” selector. 
        /// Equals to (“prev ~ siblings”)
        /// </summary>
        /// <returns>Selector builder chain</returns>
        ISelectorBuilder WithNextSiblings(ISelectorBuilder selector);

        /// <summary>
        /// Selects all elements that are visible.
        /// </summary>
        /// <returns>Selector builder chain</returns>
        IEndOfBuilder Before();

        /// <summary>
        /// Selects all elements that are visible.
        /// </summary>
        /// <returns>Selector builder chain</returns>
        IEndOfBuilder After();

        /// <summary>
        /// turns current selector builder to mutable.
        /// Warning! It's unsafe construction
        /// </summary>
        /// <returns></returns>
        ISelectorBuilder Mutable();

        /// <summary>
        /// turns current selector builder to immutable.
        /// </summary>
        /// <returns></returns>
        ISelectorBuilder Immutable();


        /// <summary>
        /// Produces a copy of current selector
        /// </summary>
        /// <returns></returns>
        ISelectorBuilder Copy();

        /// <summary>
        /// Names the selector
        /// </summary>
        /// <param name="name">Selector name</param>
        /// <returns></returns>
        ISelectorBuilder Named(string name);

        string Name { get; }

    }
}
