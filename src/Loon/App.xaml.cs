﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Loon.Commands;
using Loon.Services;
using Loon.Views;

namespace Loon
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Need to check so designer works
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
            {
                app.MainWindow = BootStrapper.GetService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }

        public static AppCommands Commands { get; } = BootStrapper.GetService<AppCommands>();
        public static Window MainWindow => ((IClassicDesktopStyleApplicationLifetime)Current.ApplicationLifetime).MainWindow;

        public static string GetString(string name) => Current.TryFindResource(name, out var value) && value is string val ? val : $"string resource not found: {name}";
    }
}