using Syncfusion.Maui.DataGrid;

namespace MAUIsland.Gallery.Syncfusion;
class SfDataGridControlInfo : IGalleryCardInfo
{
    public string ControlName => nameof(SfDataGrid);
    public string ControlRoute => typeof(SfDataGridPage).FullName;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_table_24_regular
    };
    public string ControlDetail => "The .NET MAUI DataGrid control is used to display and manipulate data in a tabular view. It was built from the ground up to achieve the best possible performance, even when loading large amounts of data.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Syncfusion/Controls/{ControlName}";
    public string DocumentUrl => $"https://help.syncfusion.com/maui/datagrid/overview";
    public string GroupName => ControlGroupInfo.SyncfusionControls;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => throw new NotImplementedException();
    public DateTime LastUpdate => throw new NotImplementedException();
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}