namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The all selector
    /// </summary>
    public sealed class AllSelector : ISelector
    {

        /// <summary>
        /// An instance of the AllSelector.
        /// </summary>
        public static readonly ISelector Instance = new AllSelector();

        private AllSelector()
        {
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.Zero;

        /// <inheritdoc />
        public String Text => "*";

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Type(Text);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => true;
    }
}
