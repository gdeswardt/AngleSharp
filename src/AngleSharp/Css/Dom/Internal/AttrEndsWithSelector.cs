namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using AngleSharp.Text;
    using System;

    /// <summary>
    /// The attribute ends with selector
    /// </summary>
    public sealed class AttrEndsWithSelector : BaseAttrSelector, ISelector
    {
        private readonly String _value;
        private readonly StringComparison _comparison;

        /// <inheritdoc />
        public AttrEndsWithSelector(String name, String value, String? prefix = null, Boolean insensitive = false)
            : base(name, prefix)
        {
            _value = value;
            _comparison = insensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        }

        /// <inheritdoc />
        public String Text => String.Concat("[", Attribute, "$=", _value.CssString(), "]");

        /// <inheritdoc />
        public void Accept(ISelectorVisitor visitor) => visitor.Attribute(Attribute, "$=", _value);

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope)
        {
            if (!String.IsNullOrEmpty(_value))
            {
                var actual = element.GetAttribute(Name) ?? String.Empty;
                return actual.EndsWith(_value, _comparison);
            }

            return false;
        }
    }
}
