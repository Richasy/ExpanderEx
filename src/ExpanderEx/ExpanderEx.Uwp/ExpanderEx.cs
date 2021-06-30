// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.UI.Xaml.Controls;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace ExpanderEx.Uwp
{
    /// <summary>
    /// To encapsulate the Expander in Microsoft.UI.Xaml, customize the icon, content and expand content.
    /// </summary>
    [TemplatePart(Name = InternalExpanderName, Type = typeof(Microsoft.UI.Xaml.Controls.Expander))]
    [TemplatePart(Name = InternalQuadrateName, Type = typeof(ExpanderExQuadratePanel))]
    public partial class ExpanderEx : Control
    {
        private const string InternalExpanderName = "InternalExpander";
        private const string InternalQuadrateName = "InternalQuadratePanel";

        private Expander _expander;
        private ExpanderExQuadratePanel _quadratePanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderEx"/> class.
        /// </summary>
        public ExpanderEx()
        {
            this.DefaultStyleKey = typeof(ExpanderEx);
        }

        /// <summary>
        /// Occurs when the internal <see cref="Expander.Collapsed"/> event is triggered.
        /// </summary>
        public event TypedEventHandler<Expander, ExpanderCollapsedEventArgs> Collapsed;

        /// <summary>
        /// Occurs when the internal <see cref="Expander.Expanding"/> event is triggered.
        /// </summary>
        public event TypedEventHandler<Expander, ExpanderExpandingEventArgs> Expanding;

        /// <summary>
        /// Occurs when the header of ExpanderEx is clicked.
        /// </summary>
        public event RoutedEventHandler Click;

        /// <inheritdoc/>
        protected override void OnApplyTemplate()
        {
            _expander = GetTemplateChild(InternalExpanderName) as Expander;
            _quadratePanel = GetTemplateChild(InternalQuadrateName) as ExpanderExQuadratePanel;

            if (_expander != null)
            {
                _expander.Expanding += (s, e) => Expanding?.Invoke(s, e);
                _expander.Collapsed += (s, e) => Collapsed?.Invoke(s, e);
                if (_expander.FindDescendantByName("ExpanderHeader") is ToggleButton expanderHeader)
                {
                    expanderHeader.Click += (s, e) => Click?.Invoke(this, e);
                }
                else
                {
                    _expander.Tapped += (s, e) =>
                    {
                        e.Handled = true;
                        Click?.Invoke(this, new RoutedEventArgs());
                    };
                }
            }

            if (_quadratePanel != null && _quadratePanel is Button headerButton)
            {
                headerButton.Click += (s, e) => Click?.Invoke(this, e);
            }

            CheckPartVisibility();
            base.OnApplyTemplate();
        }

        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as ExpanderEx;
            instance.CheckPartVisibility();
        }

        private void CheckPartVisibility()
        {
            var hasContent = Content != null;
            if (_quadratePanel != null)
            {
                _quadratePanel.Visibility = hasContent || ForceUseExpander ? Visibility.Collapsed : Visibility.Visible;
            }

            if (_expander != null)
            {
                _expander.Visibility = hasContent || ForceUseExpander ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
