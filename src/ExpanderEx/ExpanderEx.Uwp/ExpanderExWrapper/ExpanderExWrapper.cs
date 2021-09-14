// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Richasy.ExpanderEx.Uwp
{
    /// <summary>
    /// The container that display the dynamic wrap items.
    /// </summary>
    [TemplateVisualState(Name = WrapStateName)]
    [TemplateVisualState(Name = NormalStateName)]
    [TemplatePart(Name = RootGridName, Type = typeof(Grid))]
    public partial class ExpanderExWrapper : Control
    {
        private const string RootGridName = "RootGrid";
        private const string WrapStateName = "WrapState";
        private const string NormalStateName = "NormalState";

        private Grid _rootGrid;
        private FrameworkElement _parent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpanderExWrapper"/> class.
        /// </summary>
        public ExpanderExWrapper()
        {
            DefaultStyleKey = typeof(ExpanderExWrapper);
            Loaded += OnLoaded;
        }

        internal void CheckVisualState()
        {
            if (_parent.ActualWidth < WrapThreshold)
            {
                VisualStateManager.GoToState(this, WrapStateName, false);
                _rootGrid.RowSpacing = WrapRowSpacing;
                _rootGrid.ColumnSpacing = 0;
                _rootGrid.Margin = WrapMargin;
                _rootGrid.Padding = new Thickness(0);
            }
            else
            {
                VisualStateManager.GoToState(this, NormalStateName, false);
                _rootGrid.RowSpacing = 0;
                _rootGrid.ColumnSpacing = InlineColumnSpacing;
                _rootGrid.Margin = new Thickness(0);
                _rootGrid.Padding = _parent.ActualWidth < IntermediateThreshold ? InlineIntermediatePadding : InlineWidePadding;
            }
        }

        /// <inheritdoc/>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _rootGrid = (Grid)GetTemplateChild(RootGridName);
            _parent = this.FindAscendant(typeof(Microsoft.UI.Xaml.Controls.Expander), typeof(ExpanderEx)) as FrameworkElement;
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            CheckVisualState();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_parent != null)
            {
                CheckVisualState();
            }
        }
    }
}
