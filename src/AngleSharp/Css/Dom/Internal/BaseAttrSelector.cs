namespace AngleSharp.Css.Dom
{
    using System;

    /// <summary>
    /// The abstract base attribute selector
    /// </summary>
    public abstract class BaseAttrSelector
    {
        private readonly String _name;
        private readonly String? _prefix;
        private readonly String _attr;

        /// <summary>
        /// Constructs a new base attribute selector.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="prefix">The prefix, if any.</param>
        public BaseAttrSelector(String name, String? prefix)
        {
            _name = name;
            _prefix = prefix;

            if (!String.IsNullOrEmpty(prefix) && prefix is not "*")
            {
                _attr = String.Concat(prefix, ":", name);
            }
            else
            {
                _attr = name;
            }
        }

        /// <summary>
        /// Gets the specificity of the given selector.
        /// </summary>
        public Priority Specificity => Priority.OneClass;

        /// <summary>
        /// Gets the attribute of the given selector
        /// </summary>
        protected String Attribute => !String.IsNullOrEmpty(_prefix) ? String.Concat(CssUtilities.Escape(_prefix!), "|", CssUtilities.Escape(_name)) : CssUtilities.Escape(_name);

        /// <summary>
        /// Gets the name of the attribute of the given selector
        /// </summary>
        protected String Name => _attr;
    }
}
