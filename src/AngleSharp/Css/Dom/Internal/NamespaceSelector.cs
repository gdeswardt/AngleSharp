namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The namespace selector
    /// </summary>
    public sealed class NamespaceSelector : ISelector
    {
        private readonly String _prefix;

        /// <summary>
        /// </summary>
        /// <param name="prefix">The escaped prefix text</param>
        public NamespaceSelector(String prefix)
        {
            _prefix = prefix;
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.Zero;

        /// <inheritdoc />
        public String Text => CssUtilities.Escape(_prefix);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => element.MatchesCssNamespace(_prefix);

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Type(_prefix);
    }
}
