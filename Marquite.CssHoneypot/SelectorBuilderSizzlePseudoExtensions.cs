using System;

namespace Marquite.CssHoneypot
{
    public static class SelectorBuilderSizzlePseudoExtensions
    {
        public static ISelectorBuilder Pseudo(this ISelectorBuilder b, SizzlePseudo pseudo)
        {
            return b.Pseudo(Lookups.Lookup(pseudo));
        }

        public static ISelectorBuilder Pseudo<TArg>(this ISelectorBuilder b, SizzlePseudo pseudo, TArg arg)
        {
            return b.Pseudo(Lookups.Lookup(pseudo),arg);
        }

        /// <summary>
        /// Select all elements that contain the specified text.
        /// Equals to :contains()
        /// </summary>
        /// <param name="text">A string of text to look for. It's case sensitive.</param>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Contains(this ISelectorBuilder b,string text)
        {
            return Pseudo(b, SizzlePseudo.Contains, text);
        }
        /// <summary>
        /// Selects all elements of type checkbox. 
        /// Equals to :checkbox
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Checkbox(this ISelectorBuilder b)
        {
            return Pseudo(b,SizzlePseudo.Checkbox);
        }

        /// <summary>
        /// Select all elements that are in the progress of an animation at the time the selector is run. 
        /// Equals to ":animated"
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Animated(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Animated);
        }

        /// <summary>
        /// Selects all button elements and elements of type button. 
        /// Equals to :button
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Button(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Button);
        }

        /// <summary>
        /// Selects all input elements of type text. 
        /// Equals to :text
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Text(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Text);
        }

        /// <summary>
        /// Selects all elements of type submit. 
        /// equals to :submit
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Submit(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Submit);
        }

        /// <summary>
        /// Selects all elements that are selected. 
        /// Equals to :selected
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Selected(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Selected);
        }

        /// <summary>
        /// Selects all elements of type reset. 
        /// Equals to :reset
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Reset(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Reset);
        }

        /// <summary>
        /// Selects all elements of type radio. 
        /// Equals to :radio
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Radio(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Radio);
        }


        /// <summary>
        /// Selects all elements of type password. 
        /// Equals to :password
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Password(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Password);
        }

        /// <summary>
        /// Select all elements that have at least one child node (either an element or text). 
        /// Equals to :parent
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Parent(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Parent);
        }

        /// <summary>
        /// Selects odd elements, zero-indexed. See also even. 
        /// Equals to :odd
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Odd(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Odd);
        }

        /// <summary>
        /// Selects all input, textarea, select and button elements. 
        /// Equals to :input
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Input(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Input);
        }

        /// <summary>
        /// Selects all elements of type image. 
        /// Equals to :image
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Image(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Image);
        }


        /// <summary>
        /// Selects all elements that are hidden. 
        /// Equals to :hidden
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Hidden(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Hidden);
        }

        /// <summary>
        /// Selects all elements that are headers, like h1, h2, h3 and so on. 
        /// Equals to :header
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Header(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Header);
        }


        /// <summary>
        /// Selects the first matched element. 
        /// Equals to :first
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder First(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.First);
        }

        /// <summary>
        /// Selects even elements, zero-indexed. See also odd.
        /// Equals to :even
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder Even(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.Even);
        }

        /// <summary>
        /// Selects all elements of type file. 
        /// Equals to :file
        /// </summary>
        /// <returns>Selector builder chain</returns>
        public static ISelectorBuilder File(this ISelectorBuilder b)
        {
            return Pseudo(b, SizzlePseudo.File);
        }
    }
}