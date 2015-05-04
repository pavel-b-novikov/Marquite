using Marquite.Core;

namespace Marquite.CssHoneypot.Css.Values.Fonts
{
    public class Font
    {
    }

    /// <summary>
    ///     The ‘font-style’ property allows italic or oblique faces to be selected. Italic forms are generally cursive in
    ///     nature while oblique faces are typically sloped versions of the regular face. Oblique faces can be simulated by
    ///     artificially sloping the glyphs of the regular face.
    /// </summary>
    [LookupEnum]
    public enum FontStyle
    {
        /// <summary>
        ///     selects a face that is classified as a normal face, one that is neither italic or obliqued
        /// </summary>
        [LookupString("normal")] Normal,

        /// <summary>
        ///     selects a font that is labeled as an italic face, or an oblique face if one is not
        /// </summary>
        [LookupString("italic")] Italic,

        /// <summary>
        ///     selects a font that is labeled as an oblique face, or an italic face if one is not
        /// </summary>
        [LookupString("oblique")] Oblique
    }

    [LookupEnum]
    public enum FontVariant
    {
        [LookupString("normal")] Normal,
        [LookupString("small-caps")] SmallCaps
    }

    /// <summary>
    ///     The ‘font-weight’ property specifies the weight of glyphs in the font, their degree of blackness or stroke
    ///     thickness.
    /// </summary>
    [LookupEnum]
    public enum FontWeight
    {
        /// <summary>
        ///     Same as ‘400’
        /// </summary>
        [LookupString("normal")] Normal,

        /// <summary>
        ///     Same as ‘700’.
        /// </summary>
        [LookupString("bold")] Bold,

        /// <summary>
        ///     Specifies a bolder weight than the inherited value.
        /// </summary>
        [LookupString("bolder")] Bolder,

        /// <summary>
        ///     Specifies a lighter weight than the inherited value.
        /// </summary>
        [LookupString("lighter")] Lighter,

        /// <summary>
        ///     Thin
        /// </summary>
        [LookupString("100")] _100,

        /// <summary>
        ///     Extra Light (Ultra Light)
        /// </summary>
        [LookupString("200")] _200,

        /// <summary>
        ///     Light
        /// </summary>
        [LookupString("300")] _300,

        /// <summary>
        ///     Normal
        /// </summary>
        [LookupString("400")] _400,

        /// <summary>
        ///     Medium
        /// </summary>
        [LookupString("500")] _500,

        /// <summary>
        ///     Semi Bold (Demi Bold)
        /// </summary>
        [LookupString("600")] _600,

        /// <summary>
        ///     Bold
        /// </summary>
        [LookupString("700")] _700,

        /// <summary>
        ///     Extra Bold (Ultra Bold)
        /// </summary>
        [LookupString("800")] _800,

        /// <summary>
        ///     Black (Heavy)
        /// </summary>
        [LookupString("900")] _900
    }
}