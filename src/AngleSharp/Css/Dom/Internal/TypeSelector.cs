namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using AngleSharp.Text;
    using System;

    /// <summary>
    /// The type selector
    /// </summary>
    public sealed class TypeSelector : ISelector
    {
        private readonly String _type;

        /// <summary>
        /// Constructs a type selector
        /// </summary>
        /// <param name="type">The type for the selector</param>
        public TypeSelector(String type)
        {
            _type = type;
        }

        /// <summary>
        /// Gets the raw type name value
        /// </summary>
        internal String TypeName => _type;

        /// <inheritdoc />
        public Priority Specificity => Priority.OneTag;

        /// <inheritdoc />
        public String Text => CssUtilities.Escape(_type);

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Type(_type);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => _type.Isi(element.LocalName);
    }
}
