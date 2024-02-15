using Octokit;

namespace MAUIsland;
class AcrylicViewControlInfo : IGithubGalleryCardInfo
{
    private readonly Repository repository;

    public AcrylicViewControlInfo()
    {
        var owner = "sswi";
        var repo = "AcrylicView.MAUI";

        var github = new GitHubClient(new ProductHeaderValue("AcrylicView.MAUI"));
        repository = github.Repository.Get(owner, repo).Result;
    }

    public string ControlName => repository.Name;
    public string ControlRoute => typeof(AcrylicViewPage).FullName;
    public string RepositoryName => repository.Name;
    public string AuthorName => repository.Owner.Name;
    public ImageSource ControlIcon => new FontImageSource()
    {
        FontFamily = FontNames.FluentSystemIconsRegular,
        Size = 100,
        Glyph = FluentUIIcon.Ic_fluent_tab_in_private_24_regular
    };
    public string ControlDetail => "Acrylic is a type of Brush that creates a translucent texture. It can be applied to app surfaces to add depth and help establish a visual hierarchy. It is based on a Fluent Design System component that adds physical texture (material) and depth to your app. Acrylic’s most noticeable characteristic is its transparency. There are two acrylic blend types that change what’s visible through the material: Background acrylic reveals the desktop wallpaper and other windows that are behind the currently active app, adding depth between application windows while celebrating the user’s personalization preferences. In-app acrylic adds a sense of depth within the app frame, providing both focus and hierarchy.";
    public string GitHubUrl => $"https://github.com/Strypper/mauisland/blob/main/src/Features/Gallery/Pages/Community/Controls/AcrylicView";
    public string DocumentUrl => repository.SvnUrl;
    public string GroupName => ControlGroupInfo.GitHubCommunity;
    public GalleryCardType CardType => GalleryCardType.Control;
    public GalleryCardStatus CardStatus => GalleryCardStatus.NotCompleted;
    public DateTime LastUpdate => repository.UpdatedAt.DateTime;
    public List<string> DoList => throw new NotImplementedException();
    public List<string> DontList => throw new NotImplementedException();
}