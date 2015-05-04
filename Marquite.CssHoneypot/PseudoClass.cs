using Marquite.Core;

namespace Marquite.CssHoneypot
{
    [LookupEnum]
    public enum PseudoClass
    {
        /// <summary>
        ///     Selects the active link
        /// </summary>
        [CssVersion(1)] [LookupString(":active")] Active,

        /// <summary>
        ///     Insert content after every <p> element
        /// </summary>
        [CssVersion(2)] [LookupString("::after")] After,

        /// <summary>
        ///     Insert content before the content of every <p> element
        /// </summary>
        [CssVersion(2)] [LookupString("::before")] Before,

        /// <summary>
        ///     Selects every checked <input> element
        /// </summary>
        [CssVersion(3)] [LookupString(":checked")] Checked,

        /// <summary>
        ///     Selects every disabled <input> element
        /// </summary>
        [CssVersion(3)] [LookupString(":disabled")] Disabled,

        /// <summary>
        ///     Selects every <p> element that has no children (including text nodes)
        /// </summary>
        [CssVersion(3)] [LookupString(":empty")] Empty,

        /// <summary>
        ///     Selects every enabled <input> element
        /// </summary>
        [CssVersion(3)] [LookupString(":enabled")] Enabled,

        /// <summary>
        ///     Selects every <p> element that is the first child of its parent
        /// </summary>
        [CssVersion(2)] [LookupString(":first-child")] FirstChild,

        /// <summary>
        ///     Selects the first letter of every <p> element
        /// </summary>
        [CssVersion(1)] [LookupString("::first-letter")] FirstLetter,

        /// <summary>
        ///     Selects the first line of every <p> element
        /// </summary>
        [CssVersion(1)] [LookupString("::first-line")] FirstLine,

        /// <summary>
        ///     Selects every <p> element that is the first <p> element of its parent
        /// </summary>
        [CssVersion(3)] [LookupString(":first-of-type")] FirstOfType,

        /// <summary>
        ///     Selects the input element which has focus
        /// </summary>
        [CssVersion(2)] [LookupString(":focus")] Focus,

        /// <summary>
        ///     Selects links on mouse over
        /// </summary>
        [CssVersion(1)] [LookupString(":hover")] Hover,

        /// <summary>
        ///     Selects input elements with a value within a specified range
        /// </summary>
        [CssVersion(3)] [LookupString(":in-range")] InRange,

        /// <summary>
        ///     Selects all input elements with an invalid value
        /// </summary>
        [CssVersion(3)] [LookupString(":invalid")] Invalid,

        /// <summary>
        ///     Selects every <p> element that is the last child of its parent
        /// </summary>
        [CssVersion(3)] [LookupString(":last-child")] LastChild,

        /// <summary>
        ///     Selects every <p> element that is the last <p> element of its parent
        /// </summary>
        [CssVersion(3)] [LookupString(":last-of-type")] LastOfType,

        /// <summary>
        ///     Selects all unvisited links
        /// </summary>
        [CssVersion(1)] [LookupString(":link")] Link,

        /// <summary>
        /// Selects all elements that have no siblings with the same element name. 
        /// Equals to :only-of-type
        /// </summary>
        [CssVersion(3)] [LookupString(":only-of-type")] OnlyOfType,

        /// <summary>
        /// Selects all elements that are the only child of their parent. 
        /// Equals to :only-child
        /// </summary>
        [CssVersion(3)] [LookupString(":only-child")] OnlyChild,

        /// <summary>
        ///     "Selects input elements with no ""required"" attribute"
        /// </summary>
        [CssVersion(3)] [LookupString(":optional")] Optional,

        /// <summary>
        ///     Selects input elements with a value outside a specified range
        /// </summary>
        [CssVersion(3)] [LookupString(":out-of-range")] OutOfRange,

        /// <summary>
        ///     "Selects input elements with the ""readonly"" attribute specified"
        /// </summary>
        [CssVersion(3)] [LookupString(":read-only")] ReadOnly,

        /// <summary>
        ///     "Selects input elements with the ""readonly"" attribute NOT specified"
        /// </summary>
        [CssVersion(3)] [LookupString(":read-write")] ReadWrite,

        /// <summary>
        ///     "Selects input elements with the ""required"" attribute specified"
        /// </summary>
        [CssVersion(3)] [LookupString(":required")] Required,

        /// <summary>
        /// Selects the element that is the root of the document. 
        /// Equals to :root
        /// </summary>
        [CssVersion(3)] [LookupString(":root")] Root,

        /// <summary>
        ///     Selects the portion of an element that is selected by a user
        /// </summary>
        [CssVersion] [LookupString("::selection")] Selection,

        /// <summary>
        /// Selects the target element indicated by the fragment identifier of the document’s URI. 
        /// Equals to :target
        /// </summary>
        [CssVersion(3)] [LookupString(":target")] Target,

        /// <summary>
        ///     Selects all input elements with a valid value
        /// </summary>
        [CssVersion(3)] [LookupString(":valid")] Valid,

        /// <summary>
        ///     Selects all visited links
        /// </summary>
        [CssVersion(1)] [LookupString(":visited")] Visited,


        [CssVersion(1)] [LookupString(":eq")] Eq,
        [CssVersion(1)] [LookupString(":gt")] Gt,
        [LookupString(":has")] Has,
        [LookupString(":lang")] Lang,
        [LookupString(":lt")] Lt,
        [LookupString(":not")]
        Not,
        [LookupString(":nth-child")]
        NthChild,
        [LookupString(":nth-last-child")]
        NthLastChild,
        [LookupString(":nth-last-of-type")]
        NthLastOfType,
        [LookupString(":nth-of-type")]
        NthOfType
    }
}