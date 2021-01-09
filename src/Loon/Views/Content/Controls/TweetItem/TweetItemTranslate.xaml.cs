﻿using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Loon.Extensions;
using Loon.Services;
using Twitter.Models;

namespace Loon.Views.Content.Controls.TweetItem
{
    public class TweetItemTranslate : UserControl
    {
        public TweetItemTranslate()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void OnTranslateClick(object? _, RoutedEventArgs __)
        {
            if (DataContext is not null)
            {
                var tweet = (TwitterStatus)DataContext;
                var fromLang = tweet.Language ?? "und";
                var toLang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
                tweet.TranslatedText = App.GetString("translate-text-working");
                tweet.TranslatedText = await TranslateService.Translate(tweet.FullText, fromLang, toLang).ConfigureAwait(true);
            }
        }

        protected override void OnDataContextChanged(System.EventArgs e)
        {
            SetVisibility();
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            base.OnPropertyChanged(change);

            if (change.Property.Name.IsEqualTo(nameof(Tag)))
            {
                SetVisibility();
            }
        }

        private void SetVisibility()
        {
            IsVisible = DataContext is TwitterStatus status
               && status.Language.IsNotEqualToIgnoreCase(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName)
               && status.Language.IsNotEqualToIgnoreCase("und")
               && status.FullText.IsNotVacant()
               && Tag is bool hide
               && !hide;
        }
    }
}