// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.ObjectModel;
using Richasy.ExpanderEx.Uwp;
using Windows.UI.Xaml.Controls;

namespace SampleApp
{
    /// <summary>
    /// The page is used for default loading.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            for (var i = 0; i < 4; i++)
            {
                GenerateCollection.Add($"Wrapper {i + 1}");
            }
        }

        /// <summary>
        /// Data source used for testing.
        /// </summary>
        public ObservableCollection<string> GenerateCollection { get; } = new ObservableCollection<string>();

        private async void OnExpanderExClickAsync(object sender, ExpanderExClickEventArgs e)
        {
            var dialog = new ContentDialog();
            dialog.Content = $"You clicked: {(sender as ExpanderEx).Name}";
            dialog.CloseButtonText = "Cancel";
            dialog.Title = "Hi!";
            await dialog.ShowAsync();
        }
    }
}
