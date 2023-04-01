namespace AngleSharp.Css.Dom
{
    using System;
    using System.Linq;

    /// <summary>
    /// Base class for all nth-child (or related) selectors.
    /// </summary>
    public abstract class ChildSelector
    {
        #region Fields

        private readonly String _name;
        private readonly Int32 _step;
        private readonly Int32 _offset;
        private readonly ISelector _kind;

        #endregion

        #region ctor

        /// <summary>
        /// Constructs a child selector
        /// </summary>
        /// <param name="name">The name of the selector</param>
        /// <param name="step">The step of the selector</param>
        /// <param name="offset">The offset of the selector</param>
        /// <param name="kind">The kind of the selector</param>
        public ChildSelector(String name, Int32 step, Int32 offset, ISelector kind)
        {
            _name = name;
            _step = step;
            _offset = offset;
            _kind = kind;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the specificity of the given selector.
        /// </summary>
        public Priority Specificity
        {
            get
            {
                var specificity = Priority.OneClass;

                if (IncludeParameterInSpecificity)
                {
                    specificity += Kind is ListSelector list
                        ? list.Max(x => x.Specificity)
                        : Kind.Specificity;
                }

                return specificity;
            }
        }

        /// <summary>
        /// Include the parameter in specificity
        /// </summary>
        protected virtual Boolean IncludeParameterInSpecificity => false;

        /// <summary>
        /// Gets the string representation of the selector.
        /// </summary>
        public String Text
        {
            get
            {
                var a = _step.ToString();
                var b = String.Empty;
                var c = String.Empty;

                if (_offset > 0)
                {
                    b = "+";
                    c = (+_offset).ToString();
                }
                else if (_offset < 0)
                {
                    b = "-";
                    c = (-_offset).ToString();
                }

                return String.Format(":{0}({1}n{2}{3})", _name, a, b, c);
            }
        }

        /// <summary>
        /// Gets the name of the selector.
        /// </summary>
        public String Name => _name;

        /// <summary>
        /// Gets the step of the selector.
        /// </summary>
        public Int32 Step => _step;

        /// <summary>
        /// Gets the offset of the selector.
        /// </summary>
        public Int32 Offset => _offset;

        /// <summary>
        /// Gets the kind of the selector.
        /// </summary>
        public ISelector Kind => _kind;

        #endregion

        #region Methods

        /// <summary>
        /// Accepts a selector visitor to expose more information.
        /// </summary>
        /// <param name="visitor">The visitor for showing around.</param>
        public void Accept(ISelectorVisitor visitor)
        {
            visitor.Child(_name, _step, _offset, _kind);
        }

        #endregion
    }
}
