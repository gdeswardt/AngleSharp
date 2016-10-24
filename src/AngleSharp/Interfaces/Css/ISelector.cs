﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using System;

    /// <summary>
    /// Represents a CSS selector for matching elements.
    /// More information: http://dev.w3.org/csswg/selectors4/
    /// </summary>
    public interface ISelector : IStyleFormattable
    {
        /// <summary>
        /// Gets the specifity of the given selector.
        /// </summary>
        Priority Specifity { get; }

        /// <summary>
        /// Determines if the given object is matched by this selector.
        /// </summary>
        /// <param name="element">The element to be matched.</param>
        /// <param name="scope">The selector scope.</param>
        /// <returns>
        /// True if the selector matches the given element, otherwise false.
        /// </returns>
        bool Match(IElement element, IElement scope);

        /// <summary>
        /// Gets the string representation of the selector.
        /// </summary>
        String Text { get; }
    }
}
