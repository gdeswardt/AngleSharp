namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using AngleSharp.Text;
    using System;

    /// <summary>
    /// The id selector
    /// </summary>
    public sealed class IdSelector : ISelector
    {
        private readonly String _id;

        /// <summary>
        /// Constructs an id selector
        /// </summary>
        /// <param name="id"></param>
        public IdSelector(String id)
        {
            _id = id;
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.OneId;

        /// <inheritdoc />
        public String Text => "#" + CssUtilities.Escape(_id);

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Id(_id);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => element.Id.Is(_id);
    }
}
