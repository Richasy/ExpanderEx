// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace ExpanderEx.Uwp
{
    /// <summary>
    /// Simulates the UI of Expander,
    /// but does not provide expand/collapse functions,
    /// and is used as a display container when <see cref="ExpanderEx.Content"/> is empty.
    /// </summary>
    public partial class ExpanderExQuadratePanel : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderExQuadratePanel"/> class.
        /// </summary>
        public ExpanderExQuadratePanel()
        {
            this.DefaultStyleKey = typeof(ExpanderExQuadratePanel);
        }

        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer() => new ExpanderExQuadratePanelAutomationPeer(this);
    }
}
