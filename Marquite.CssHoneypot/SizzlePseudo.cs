using Marquite.Core;

namespace Marquite.CssHoneypot
{
    [LookupEnum]
    public enum SizzlePseudo
    {
        /// <summary>
        ///     Selects all elements that are visible.
        /// </summary>
        [LookupString(":visible")] Visible,

        /// <summary>
        ///     Selects all input elements of type text.
        ///     Equals to :text
        /// </summary>
        [LookupString(":text")] Text,

        /// <summary>
        ///     Selects all elements of type submit.
        ///     Equals to :submit
        /// </summary>
        [LookupString(":submit")] Submit,

        /// <summary>
        ///     Selects all elements that are selected.
        ///     Equals to :selected
        /// </summary>
        [CssVersion] [LookupString(":selected")] Selected,

        /// <summary>
        ///     Selects all elements of type reset.
        ///     Equals to :reset
        /// </summary>
        [LookupString(":reset")] Reset,

        /// <summary>
        ///     Selects all elements of type radio.
        ///     Equals to :radio
        /// </summary>
        [LookupString(":radio")] Radio,
        [LookupString(":contains")] Contains,
        [LookupString(":checkbox")] Checkbox,
        [LookupString(":animated")] Animated,
        [LookupString(":button")] Button,
        [LookupString(":password")] Password,
        [LookupString(":parent")] Parent,
        [LookupString(":odd")] Odd,
        [LookupString(":input")] Input,
        [LookupString(":image")] Image,
        [LookupString(":hidden")] Hidden,
        [LookupString(":header")] Header,
        [LookupString(":first")] First,
        [LookupString(":even")] Even,
        [LookupString(":file")] File
    }
}