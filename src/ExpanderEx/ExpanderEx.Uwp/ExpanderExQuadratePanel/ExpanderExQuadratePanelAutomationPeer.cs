// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Windows.UI.Xaml.Automation.Peers;

namespace Richasy.ExpanderEx.Uwp
{
    /// <summary>
    /// Exposes <see cref="ExpanderExQuadratePanel"/> to Microsoft UI Automation.
    /// </summary>
    public class ExpanderExQuadratePanelAutomationPeer : FrameworkElementAutomationPeer
    {
        private readonly ExpanderExQuadratePanel owner;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderExQuadratePanelAutomationPeer"/> class.
        /// </summary>
        /// <param name="owner">The owner element to create for.</param>
        public ExpanderExQuadratePanelAutomationPeer(ExpanderExQuadratePanel owner)
            : base(owner) => this.owner = owner;

        /// <inheritdoc/>
        protected override AutomationControlType GetAutomationControlTypeCore() => AutomationControlType.Group;
    }
}
