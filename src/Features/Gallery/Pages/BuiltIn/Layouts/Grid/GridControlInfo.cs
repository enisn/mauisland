namespace MAUIsland;
class GridControlInfo : IBuiltInGalleryCardInfo
{
    public string ControlName => nameof(Grid);
    public string ControlRoute => typeof(GridPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_glance_default_12_regular
    };
    public string ControlDetail => "The .NET Multi-platform App UI (.NET MAUI) Grid, is a layout that organizes its children into rows and columns, which can have proportional or absolute sizes. By default, a Grid contains one row and one column. In addition, a Grid can be used as a parent layout that contains other child layouts.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/BuiltIn/Layouts/{ControlName}";
    public string DocumentUrl => $"https://learn.microsoft.com/en-us/dotnet/maui/user-interface/layouts/grid?view=net-maui-7.0";
    public string GroupName => ControlGroupInfo.BuiltInControls;
    public BuiltInGalleryCardStatus Status => BuiltInGalleryCardStatus.Stable;
    public GalleryCardType CardType => GalleryCardType.Layout;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}