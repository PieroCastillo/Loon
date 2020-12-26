﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Loon.Interfaces;

namespace Loon.Views.Content.Write
{
    public class WriteView : UserControl, ISetFocus
    {
        public WriteView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void SetFocus()
        {
            var textBox = this.FindControl<TextBox>("WriteTextBox");
            textBox?.Focus();
        }
    }
}