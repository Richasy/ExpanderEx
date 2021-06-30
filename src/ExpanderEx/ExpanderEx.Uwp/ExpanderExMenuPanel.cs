// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ExpanderEx.Uwp
{
    /// <summary>
    /// The container is used to display a set of <see cref="ExpanderWrapper"/>.
    /// </summary>
    public class ExpanderExMenuPanel : StackPanel
    {
        /// <summary>
        /// Gets the dependency property for <see cref="MenuItemInlineIntermediatePadding"/>.
        /// </summary>
        public static readonly DependencyProperty MenuItemInlineWidePaddingProperty =
            DependencyProperty.Register(nameof(MenuItemInlineWidePadding), typeof(Thickness), typeof(ExpanderExMenuPanel), new PropertyMetadata(new Thickness(48, 8, 60, 8), new PropertyChangedCallback(OnItemPropertyChanged)));

        /// <summary>
        /// Gets the dependency property for <see cref="MenuItemInlineIntermediatePadding"/>.
        /// </summary>
        public static readonly DependencyProperty MenuItemInlineIntermediatePaddingProperty =
            DependencyProperty.Register(nameof(MenuItemInlineIntermediatePadding), typeof(Thickness), typeof(ExpanderExMenuPanel), new PropertyMetadata(new Thickness(16, 8, 16, 8), new PropertyChangedCallback(OnItemPropertyChanged)));

        /// <summary>
        /// Gets the dependency property for <see cref="MenuItemWrapRowSpacing"/>.
        /// </summary>
        public static readonly DependencyProperty MenuItemWrapRowSpacingProperty =
            DependencyProperty.Register(nameof(MenuItemWrapRowSpacing), typeof(double), typeof(ExpanderExMenuPanel), new PropertyMetadata(8d, new PropertyChangedCallback(OnItemPropertyChanged)));

        /// <summary>
        /// Gets the dependency property for <see cref="MenuItemWrapMargin"/>.
        /// </summary>
        public static readonly DependencyProperty MenuItemWrapMarginProperty =
            DependencyProperty.Register(nameof(MenuItemWrapMargin), typeof(Thickness), typeof(ExpanderExMenuPanel), new PropertyMetadata(new Thickness(16, 8, 16, 8), new PropertyChangedCallback(OnItemPropertyChanged)));

        /// <summary>
        /// Gets or sets the inner <see cref="ExpanderExWrapper"/> padding of the container when the elements are on the same line and in wide state.
        /// </summary>
        public Thickness MenuItemInlineWidePadding
        {
            get { return (Thickness)GetValue(MenuItemInlineWidePaddingProperty); }
            set { SetValue(MenuItemInlineWidePaddingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the inner <see cref="ExpanderExWrapper"/> padding of the container when the elements are on the same line and in intermediate state.
        /// </summary>
        public Thickness MenuItemInlineIntermediatePadding
        {
            get { return (Thickness)this.GetValue(MenuItemInlineIntermediatePaddingProperty); }
            set { this.SetValue(MenuItemInlineIntermediatePaddingProperty, value); }
        }

        /// <summary>
        /// Gets or sets row spacing when inner <see cref="ExpanderExWrapper"/> displaying different rows.
        /// </summary>
        public double MenuItemWrapRowSpacing
        {
            get { return (double)GetValue(MenuItemWrapRowSpacingProperty); }
            set { SetValue(MenuItemWrapRowSpacingProperty, value); }
        }

        /// <summary>
        /// Gets or sets when the flow, the margin of the inner <see cref="ExpanderExWrapper"/> container.
        /// </summary>
        public Thickness MenuItemWrapMargin
        {
            get { return (Thickness)GetValue(MenuItemWrapMarginProperty); }
            set { SetValue(MenuItemWrapMarginProperty, value); }
        }

        /// <inheritdoc/>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (this.Children.Count == 0)
            {
                return new Size(0, 0);
            }
            else
            {
                foreach (var child in Children)
                {
                    if (child is ExpanderExWrapper wrapper)
                    {
                        wrapper.WrapMargin = this.MenuItemWrapMargin;
                        wrapper.WrapRowSpacing = this.MenuItemWrapRowSpacing;
                        wrapper.InlineWidePadding = this.MenuItemInlineWidePadding;
                        wrapper.InlineIntermediatePadding = this.MenuItemInlineIntermediatePadding;
                        wrapper.Measure(availableSize);
                    }
                }
            }

            return base.MeasureOverride(availableSize);
        }

        /// <inheritdoc/>
        protected override Size ArrangeOverride(Size finalSize) => base.ArrangeOverride(finalSize);

        private static void OnItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as ExpanderExMenuPanel).InvalidateMeasure();
    }
}
