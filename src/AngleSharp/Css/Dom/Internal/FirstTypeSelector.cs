namespace AngleSharp.Css.Dom
{
    using AngleSharp.Dom;
    using AngleSharp.Text;
    using System;

    /// <summary>
    /// The nth-of-type selector.
    /// </summary>
    public sealed class FirstTypeSelector : ChildSelector, ISelector
    {
        /// <inheritdoc />
        public FirstTypeSelector(Int32 step, Int32 offset, ISelector kind)
            : base(PseudoClassNames.NthOfType, step, offset, kind)
        {
        }

        /// <inheritdoc />
        public Boolean Match(IElement element, IElement? scope)
        {
            var parent = element.ParentElement;

            if (parent != null)
            {
                var n = Math.Sign(Step);
                var k = 0;

                for (var i = 0; i < parent.ChildNodes.Length; i++)
                {
                    if (parent.ChildNodes[i] is IElement child && child.NodeName.Is(element.NodeName))
                    {
                        k += 1;

                        if (child == element)
                        {
                            var diff = k - Offset;
                            return diff == 0 || (Math.Sign(diff) == n && diff % Step == 0);
                        }
                    }
                }
            }

            return false;
        }
    }
}
