// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Windows.UI.Xaml;

namespace ExpanderEx.Uwp
{
    /// <summary>
    /// Click event arguments of ExpanderEx.
    /// </summary>
    public class ExpanderExClickEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderExClickEventArgs"/> class.
        /// </summary>
        public ExpanderExClickEventArgs()
        {
        }

        internal ExpanderExClickEventArgs(bool isExpander, FrameworkElement source)
        {
            this.IsExpander = isExpander;
            this.SourceElement = source;
        }

        /// <summary>
        /// Whether the object which trigger the click event is <see cref="Microsoft.UI.Xaml.Controls.Expander"/>.
        /// </summary>
        public bool IsExpander { get; set; }

        /// <summary>
        /// The UI object that send the click event, which may be <see cref="Microsoft.UI.Xaml.Controls.Expander"/>
        /// or <see cref="ExpanderExQuadratePanel"/>.
        /// </summary>
        public FrameworkElement SourceElement { get; set; }
    }
}
