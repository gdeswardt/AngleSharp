namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The class selector
    /// </summary>
    public sealed class ClassSelector : ISelector
    {
        private readonly String _cls;

        /// <summary>
        /// Constructs a class selector
        /// </summary>
        /// <param name="cls">The name of the class </param>
        public ClassSelector(String cls)
        {
            _cls = cls;
        }

        /// <inheritdoc />
        public Priority Specificity => Priority.OneClass;

        /// <inheritdoc />
        public String Text => "." + CssUtilities.Escape(_cls);


        /// <summary>
        /// Gets the name of the class of the given selector
        /// </summary>
        public String ClassName => _cls;

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Class(_cls);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => element.ClassList.Contains(_cls);
    }
}
