using Octokit;

namespace MAUIsland.Gallery.Community;
class LiveCharts2ControlInfo : IGithubGalleryCardInfo
{
    private readonly Repository repository;

    public LiveCharts2ControlInfo()
    {
        var owner = "beto-rodriguez";
        var repo = "LiveCharts2";

        var github = new GitHubClient(new ProductHeaderValue("LiveCharts2"));
        repository = github.Repository.Get(owner, repo).Result;
    }
    public string ControlName => repository.Name;
    public string ControlRoute => typeof(LiveCharts2Page).FullName;
    public string ControlDetail => "LiveCharts2 is a library developed by beto-rodriguez. It’s a simple, flexible, interactive, and powerful tool for creating charts, maps, and gauges in .Net1. It’s designed to run on multiple platforms including Maui, Uno Platform, Blazor-wasm, WPF, WinForms, Xamarin, Avalonia, WinUI, and UWP1. The library is designed to be highly flexible and can be easily moved to any other drawing engine1. It also supports high-performance data visualization2.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Controls/{ControlName}";
    public string DocumentUrl => "https://livecharts.dev/docs/maui/2.0.0-rc2/gallery";
    public string RepositoryName => repository.Name;
    public string AuthorName => repository.Owner.Name;
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => GalleryCardStatus.Completed;
    public DateTime LastUpdate => repository.UpdatedAt.DateTime;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
    };
}