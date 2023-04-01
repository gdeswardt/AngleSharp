namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The scope pseudo class selector
    /// </summary>
    public sealed class ScopePseudoClassSelector : ISelector
    {
        /// <summary>
        /// An instance of the ScopePseudoClassSelector.
        /// </summary>
        public static readonly ISelector Instance = new ScopePseudoClassSelector();

        private ScopePseudoClassSelector()
        {
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.OneClass;

        /// <inheritdoc />
        public String Text => PseudoClassNames.Separator + PseudoClassNames.Scope;

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.PseudoClass(PseudoClassNames.Scope);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope)
        {
            var realScope = scope ?? element.Owner!.DocumentElement;
            return Object.ReferenceEquals(element, realScope);
        }
    }
}
