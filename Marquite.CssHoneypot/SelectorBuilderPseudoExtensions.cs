namespace Marquite.CssHoneypot
{
    public static class SelectorBuilderPseudoExtensions
    {
        public static ISelectorBuilder Pseudo(this ISelectorBuilder b, PseudoClass pseudo)
        {
            return b.Pseudo(Lookups.Lookup(pseudo));
        }
        public static ISelectorBuilder Pseudo<TArg>(this ISelectorBuilder b, PseudoClass pseudo, TArg argument)
        {
            return b.Pseudo(Lookups.Lookup(pseudo), argument);
        }

        /// <summary>
        /// Select the element at index n within the matched set. 
        /// Equals to :eq()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="index">Zero-based index of the element to match. If less than zero then counting backwards from the last element.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Eq(this ISelectorBuilder b, int index)
        {
            return Pseudo(b, PseudoClass.Eq, index);
        }

        /// <summary>
        /// Select all elements at an index greater than index within the matched set. 
        /// Equals to :gt()
        /// <param name="b">Selector builder</param>
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="index">Zero-based index. If less than zero then counting backwards from the last element.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Gt(this ISelectorBuilder b, int index)
        {
            return Pseudo(b, PseudoClass.Gt, index);
        }

        /// <summary>
        /// Selects elements which contain at least one element that matches the specified selector. 
        /// Equals to :has()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">Any selector.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Has(this ISelectorBuilder b, ISelectorBuilder selector)
        {
            return Pseudo(b, PseudoClass.Has, selector);
        }

        /// <summary>
        /// Selects elements which contain at least one element that matches the specified selector. 
        /// Equals to :has()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">Any selector.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Has(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.Has, selector);
        }

        /// <summary>
        /// Selects all elements of the specified language. 
        /// Equals to :lang()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="lang">A language code.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Lang(this ISelectorBuilder b, string lang)
        {
            return Pseudo(b, PseudoClass.Lang, lang);
        }

        /// <summary>
        /// Select all elements at an index less than index within the matched set. 
        /// Equals to :lt()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="index">Zero-based index. If less than zero then counting backwards from the last element.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Lt(this ISelectorBuilder b, int index)
        {
            return Pseudo(b, PseudoClass.Lt, index);
        }

        /// <summary>
        /// Selects all elements that do not match the given selector.
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">A selector with which to filter by.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Not(this ISelectorBuilder b, ISelectorBuilder selector)
        {
            return Pseudo(b, PseudoClass.Not, selector);
        }

        /// <summary>
        /// Selects all elements that do not match the given selector.
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">A selector with which to filter by.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Not(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.Not, selector);
        }

        /// <summary>
        /// Selects all elements that are the nth-child of their parent. 
        /// Equals to :nth-child()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">The index of each child to match, starting with 1, the string even or odd, or an equation ( eg. :nth-child(even), :nth-child(4n) )</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder NthChild(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.NthChild, selector);
        }

        /// <summary>
        /// Selects all elements that are the nth-child of their parent, counting from the last element to the first. 
        /// Equals to :nth-last-child()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">The index of each child to match, starting with 1, the string even or odd, or an equation ( eg. :nth-child(even), :nth-child(4n) )</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder NthLastChild(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.NthLastChild, selector);
        }

        /// <summary>
        /// Selects all the elements that are the nth-child of their parent in relation to siblings with the same element name, counting from the last element to the first. 
        /// Equals to :nth-last-of-type()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">The index of each child to match, starting with 1, the string even or odd, or an equation ( eg. :nth-child(even), :nth-child(4n) )</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder NthLastOfType(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.NthLastOfType, selector);
        }

        /// <summary>
        /// Selects all elements that are the nth child of their parent in relation to siblings with the same element name. 
        /// Equals to :nth-of-type()
        /// </summary>
        /// <param name="b">Selector builder</param>
        /// <param name="selector">The index of each child to match, starting with 1, the string even or odd, or an equation ( eg. :nth-child(even), :nth-child(4n) )</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder NthOfType(this ISelectorBuilder b, string selector)
        {
            return Pseudo(b, PseudoClass.NthOfType, selector);
        }

        /// <summary>
        ///     Selects the active link
        /// </summary>
        /// <param name="b">Selector builder</param>
        public static ISelectorBuilder Active(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Active);
        }

        /// <summary>
        ///     Insert content after every &lt;p&gt; element
        /// </summary>
        /// <param name="b">Selector builder</param>
        public static ISelectorBuilder After(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.After);
        }

        /// <summary>
        ///     Insert content before the content of every &lt;p&gt; element
        /// </summary>
        /// <param name="b">Selector builder</param>
        public static ISelectorBuilder Before(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Before);
        }

        /// <summary>
        ///     Selects every checked &lt;input&gt; element
        /// </summary>
        public static ISelectorBuilder Checked(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Checked);
        }

        /// <summary>
        ///     Selects every disabled &lt;input&gt; element
        /// </summary>
        public static ISelectorBuilder Disabled(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Disabled);
        }

        /// <summary>
        ///     Selects every &lt;p&gt; element that has no children (including text nodes)
        /// </summary>
        public static ISelectorBuilder Empty(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Empty);
        }

        /// <summary>
        ///     Selects every enabled &lt;input&gt; element
        /// </summary>
        public static ISelectorBuilder Enabled(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Enabled);
        }

        /// <summary>
        ///     Selects every &lt;p&gt; element that is the first child of its parent
        /// </summary>
        public static ISelectorBuilder FirstChild(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.FirstChild);
        }

        /// <summary>
        ///     Selects the first letter of every &lt;p&gt; element
        /// </summary>
        public static ISelectorBuilder FirstLetter(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.FirstLetter);
        }

        /// <summary>
        ///     Selects the first line of every &lt;p&gt; element
        /// </summary>
        public static ISelectorBuilder FirstLine(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.FirstLine);
        }

        /// <summary>
        ///     Selects every &lt;p&gt; element that is the first &lt;p&gt; element of its parent
        /// </summary>
        public static ISelectorBuilder FirstOfType(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.FirstOfType);
        }

        /// <summary>
        ///     Selects the input element which has focus
        /// </summary>
        public static ISelectorBuilder Focus(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Focus);
        }

        /// <summary>
        ///     Selects links on mouse over
        /// </summary>
        public static ISelectorBuilder Hover(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Hover);
        }

        /// <summary>
        ///     Selects input elements with a value within a specified range
        /// </summary>
        public static ISelectorBuilder InRange(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.InRange);
        }

        /// <summary>
        ///     Selects all input elements with an invalid value
        /// </summary>
        public static ISelectorBuilder Invalid(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Invalid);
        }

        /// <summary>
        ///     Selects every &lt;p&gt; element that is the last child of its parent
        /// </summary>
        public static ISelectorBuilder LastChild(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.LastChild);
        }

        /// <summary>
        ///     Selects every &lt;p&gt; element that is the last &lt;p&gt; element of its parent
        /// </summary>
        public static ISelectorBuilder LastOfType(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.LastOfType);
        }

        /// <summary>
        ///     Selects all unvisited links
        /// </summary>
        public static ISelectorBuilder Link(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Link);
        }

        /// <summary>
        /// Selects all elements that have no siblings with the same element name. 
        /// Equals to :only-of-type
        /// </summary>
        public static ISelectorBuilder OnlyOfType(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.OnlyOfType);
        }

        /// <summary>
        /// Selects all elements that are the only child of their parent. 
        /// Equals to :only-child
        /// </summary>
        public static ISelectorBuilder OnlyChild(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.OnlyChild);
        }

        /// <summary>
        ///     "Selects input elements with no ""required"" attribute"
        /// </summary>
        public static ISelectorBuilder Optional(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Optional);
        }

        /// <summary>
        ///     Selects input elements with a value outside a specified range
        /// </summary>
        public static ISelectorBuilder OutOfRange(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.OutOfRange);
        }

        /// <summary>
        ///     "Selects input elements with the ""readonly"" attribute specified"
        /// </summary>
        public static ISelectorBuilder ReadOnly(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.ReadOnly);
        }

        /// <summary>
        ///     "Selects input elements with the ""readonly"" attribute NOT specified"
        /// </summary>
        public static ISelectorBuilder ReadWrite(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.ReadWrite);
        }

        /// <summary>
        ///     "Selects input elements with the ""required"" attribute specified"
        /// </summary>
        public static ISelectorBuilder Required(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Required);
        }

        /// <summary>
        /// Selects the element that is the root of the document. 
        /// Equals to :root
        /// </summary>
        public static ISelectorBuilder Root(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Root);
        }

        /// <summary>
        ///     Selects the portion of an element that is selected by a user
        /// </summary>
        public static ISelectorBuilder Selection(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Selection);
        }

        /// <summary>
        /// Selects the target element indicated by the fragment identifier of the document’s URI. 
        /// Equals to :target
        /// </summary>
        public static ISelectorBuilder Target(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Target);
        }

        /// <summary>
        ///     Selects all input elements with a valid value
        /// </summary>
        public static ISelectorBuilder Valid(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Valid);
        }

        /// <summary>
        ///     Selects all visited links
        /// </summary>
        public static ISelectorBuilder Visited(this ISelectorBuilder b)
        {
            return Pseudo(b,PseudoClass.Visited);
        }


    }
}
