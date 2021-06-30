// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ExpanderEx.Uwp
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
            this.DefaultStyleKey = typeof(ExpanderExWrapper);
        }

        /// <inheritdoc/>
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._rootGrid = (Grid)this.GetTemplateChild(RootGridName);
            this._parent = this.FindAscendant(typeof(Microsoft.UI.Xaml.Controls.Expander), typeof(ExpanderEx)) as FrameworkElement;
            this.SizeChanged += this.OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this._parent.ActualWidth < this.WrapThreshold)
            {
                VisualStateManager.GoToState(this, WrapStateName, false);
                this._rootGrid.RowSpacing = this.WrapRowSpacing;
                this._rootGrid.ColumnSpacing = 0;
                this._rootGrid.Margin = this.WrapMargin;
                this._rootGrid.Padding = new Thickness(0);
            }
            else
            {
                VisualStateManager.GoToState(this, NormalStateName, false);
                this._rootGrid.RowSpacing = 0;
                this._rootGrid.ColumnSpacing = this.InlineColumnSpacing;
                this._rootGrid.Margin = new Thickness(0);

                if (this._parent.ActualWidth < this.IntermediateThreshold)
                {
                    this._rootGrid.Padding = this.InlineIntermediatePadding;
                }
                else
                {
                    this._rootGrid.Padding = this.InlineWidePadding;
                }
            }
        }
    }
}
