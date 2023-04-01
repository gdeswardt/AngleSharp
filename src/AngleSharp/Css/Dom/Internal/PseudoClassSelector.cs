namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The pseudo class selector
    /// </summary>
    public sealed class PseudoClassSelector : ISelector
    {
        private readonly Predicate<IElement> _action;
        private readonly String _pseudoClass;

        /// <summary>
        /// Constructs a pseudo class selector
        /// </summary>
        /// <param name="action">The action for the selector</param>
        /// <param name="pseudoClass">The pseudo class for the selector</param>
        public PseudoClassSelector(Predicate<IElement> action, String pseudoClass)
        {
            _action = action;
            _pseudoClass = pseudoClass;
            Specificity = Priority.OneClass;
        }

        /// <summary>
        /// Constructs a pseudo class selector
        /// </summary>
        /// <param name="action">The action for the selector</param>
        /// <param name="pseudoClass">The pseudo class for the selector</param>
        /// <param name="specificity">The specificity for the selector</param>
        public PseudoClassSelector(Predicate<IElement> action, String pseudoClass, Priority specificity)
        {
            _action = action;
            _pseudoClass = pseudoClass;
            Specificity = specificity;
        }

        /// <inheritdoc />
        public Priority Specificity { get; }

        /// <inheritdoc />
        public String Text => PseudoClassNames.Separator + CssUtilities.Escape(_pseudoClass);

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.PseudoClass(_pseudoClass);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => _action.Invoke(element);
    }
}
