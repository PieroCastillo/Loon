﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Loon.Views.Content.AppSettings
{
    public class SettingsInfo : UserControl
    {
        public SettingsInfo()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}