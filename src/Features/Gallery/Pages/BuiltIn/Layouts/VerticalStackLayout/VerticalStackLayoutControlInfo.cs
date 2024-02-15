namespace MAUIsland;
class VerticalStackLayoutControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(VerticalStackLayout);
    public string ControlRoute => typeof(VerticalStackLayoutPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_align_space_evenly_vertical_20_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) VerticalStackLayout organizes child views in a one-dimensional vertical stack, and is a more performant alternative to a StackLayout. In addition, a VerticalStackLayout can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/verticalstacklayout?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}