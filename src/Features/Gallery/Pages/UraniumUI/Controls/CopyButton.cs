﻿using UraniumUI.Icons.SegoeFluent;
using UraniumUI.Resources;
using UraniumUI.Views;

namespace MAUIsland;
public class CopyButton : StatefulContentView
{
    public CopyButton()
    {
        HorizontalOptions = LayoutOptions.End;
        VerticalOptions = LayoutOptions.End;
        Margin = 20;
        var copyImageSource = new FontImageSource
        {
            Glyph = Fluent.Copy,
            FontFamily = "Fluent",
        };
        copyImageSource.SetAppThemeColor(
            FontImageSource.ColorProperty,
            ColorResource.GetColor("OnBackground"),
            ColorResource.GetColor("OnBackgroundDark"));

        var img = new Image
        {
            Source = copyImageSource,
            HeightRequest = 20
        };

        Content = img;

        TappedCommand = new Command(async () =>
        {
            await Clipboard.Default.SetTextAsync(TextToCopy);

            img.Source = new FontImageSource
            {
                Glyph = Fluent.Accept,
                FontFamily = "Fluent",
                Color = Color.FromArgb("#8BC34A")
            }; ;

            await Task.Delay(1000);

            img.Source = copyImageSource;
        });
    }

    public string TextToCopy { get => (string)GetValue(TextToCopyProperty); set => SetValue(TextToCopyProperty, value); }

    public static readonly BindableProperty TextToCopyProperty = BindableProperty.Create(
        nameof(TextToCopy),
        typeof(string),
        typeof(CopyButton));
}
