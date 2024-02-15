using UraniumUI.Icons.SegoeFluent;
using UraniumUI.Material.Controls;

namespace MAUIsland;

public class TextFieldCardInfo : IGalleryCardInfo
{
    public ImageSource ControlIcon { get; } = new FontImageSource
    {
        FontFamily = nameof(Fluent),
        Glyph = Fluent.Rename,
        Size = 100
    };
    public string ControlName { get; } = nameof(TextField);
    public string ControlDetail { get; } = "The .NET MAUI TextField control provides an input control that accepts text input from a user.";
    public string ControlRoute { get; } = typeof(TextFieldPage).FullName;
    public string GitHubUrl { get; } = "https://github.com/Strypper/mauisland/tree/main/src/Features/Gallery/Pages/UraniumUI/";
    public string DocumentUrl { get; } = "https://enisn-projects.io/docs/en/uranium/latest/themes/material/components/TextField";
    public string GroupName => ControlGroupInfo.UraniumUIComponent;
    public GalleryCardType CardType { get; } = GalleryCardType.Control;
    public GalleryCardStatus CardStatus { get; } = GalleryCardStatus.Completed;
    public DateTime LastUpdate { get; } = new DateTime(2024, 02, 02);
    public List<string> DoList { get; } = new();
    public List<string> DontList { get; } = new();
}
