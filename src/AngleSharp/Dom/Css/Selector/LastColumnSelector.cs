﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using AngleSharp.Dom.Html;
    using System;

    /// <summary>
    /// The nth-last-column selector.
    /// </summary>
    sealed class LastColumnSelector : ChildSelector
    {
        public LastColumnSelector(Int32 step, Int32 offset, ISelector kind)
            : base(PseudoClassNames.NthLastColumn, step, offset, kind)
        {
        }

        public override bool Match(IElement element, IElement scope)
        {
            var parent = element.ParentElement;

            if (parent != null)
            {
                var n = Math.Sign(Step);
                var k = 0;

                for (var i = parent.ChildNodes.Length - 1; i >= 0; i--)
                {
                    var child = parent.ChildNodes[i] as IHtmlTableCellElement;

                    if (child != null)
                    {
                        var span = child.ColumnSpan;
                        k += span;

                        if (child == element)
                        {
                            var diff = k - Offset;

                            for (var index = 0; index < span; index++, diff--)
                            {
                                if (diff == 0 || (Math.Sign(diff) == n && diff % Step == 0))
                                {
                                    return true;
                                }
                            }

                            return false;
                        }
                    }
                }
            }

            return false;
        }
    }
}
