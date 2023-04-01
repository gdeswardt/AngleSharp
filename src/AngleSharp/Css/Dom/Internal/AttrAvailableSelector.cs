namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using System;

    /// <summary>
    /// The attribute available selector
    /// </summary>
    public sealed class AttrAvailableSelector : BaseAttrSelector, ISelector
    {
        /// <inheritdoc />
        public AttrAvailableSelector(String name, String? prefix)
            : base(name, prefix)
        {
        }

        /// <inheritdoc />
        public String Text => String.Concat("[", Attribute, "]");

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Attribute(Attribute, String.Empty, null);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope) => element.HasAttribute(Name);
    }
}
