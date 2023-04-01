namespace AngleSharp.Css.Dom
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// A list of selectors, which is the basis for CompoundSelector and
    /// SelectorGroup.
    /// </summary>
    public abstract class Selectors : IEnumerable<ISelector>
    {
        #region Fields

        /// <summary>
        /// A list of all the selectors
        /// </summary>
        protected readonly List<ISelector> _selectors;

        #endregion

        #region ctor

        /// <summary>
        /// Constructs base selectors instance
        /// </summary>
        public Selectors()
        {
            _selectors = new List<ISelector>();
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
                var sum = new Priority();

                for (var i = 0; i < _selectors.Count; i++)
                {
                    sum += _selectors[i].Specificity;
                }

                return sum;
            }
        }

        /// <summary>
        /// Gets the string representation of the selector.
        /// </summary>
        public String Text => Stringify();

        /// <summary>
        /// Gets the number of elements in the selector list
        /// </summary>
        public Int32 Length => _selectors.Count;

        /// <summary>
        /// Gets the selector at the index position
        /// </summary>
        /// <param name="index">The position within the list</param>
        public ISelector this[Int32 index]
        {
            get => _selectors[index];
            set => _selectors[index] = value;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Stringify the selector
        /// </summary>
        /// <returns></returns>
        protected abstract String Stringify();

        internal void Add(ISelector selector) => _selectors.Add(selector);

        internal void Remove(ISelector selector) => _selectors.Remove(selector);

        #endregion

        #region IEnumerable implementation

        /// <summary>
        ///  Get an enumeration of the selectors
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ISelector> GetEnumerator() => _selectors.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
