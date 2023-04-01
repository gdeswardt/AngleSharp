namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The pseudo element selector
    /// </summary>
    public sealed class PseudoElementSelector : ISelector
    {
        private readonly Predicate<IElement> _action;
        private readonly String _pseudoElement;

        /// <summary>
        /// Constructs a pseudo element
        /// </summary>
        /// <param name="action"></param>
        /// <param name="pseudoElement"></param>
        public PseudoElementSelector(Predicate<IElement> action, String pseudoElement)
        {
            _action = action;
            _pseudoElement = pseudoElement;
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.OneTag;

        /// <inheritdoc />
        public String Text => PseudoElementNames.Separator + CssUtilities.Escape(_pseudoElement);

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.PseudoElement(_pseudoElement);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => _action.Invoke(element);
    }
}
