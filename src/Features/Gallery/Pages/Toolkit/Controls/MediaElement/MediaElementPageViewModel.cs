using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;

namespace MAUIsland;
public partial class MediaElementPageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public MediaElementPageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {
    }
    #endregion

    #region [ Properties ]
    [ObservableProperty]
    double volume;

    [ObservableProperty]
    MediaElementState currentState;

    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string setupDescription = 
        "In order to use the toolkit in XAML the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace = 
        "xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"";

    [ObservableProperty]
    string fullNamepaceExampleBefore =
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string fullNamepaceExampleAfter = 
        "<ContentPage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\">\r\n" +
        "</ContentPage>";

    [ObservableProperty]
    string iOSBypassing = "To bypass the Hardware Silent Switch on iOS, add the following lines of code to MauiProgram.cs. This ensures that MediaElement's playback audio will always be audible to the user regardless of their device's Hardware Silent Switch.";

    [ObservableProperty]
    string iOSBypassingSetup =
        "public static class MauiProgram\r\n" +
        "{\r\n" +
        "    public static MauiApp CreateMauiApp()\r\n\t" +
        "    {\r\n" +
        "#if IOS\r\n" +
        "        AVAudioSession.SharedInstance().SetActive(true);\r\n" +
        "        AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);\r\n" +
        "#endif\r\n" +
        "    }\r\n" +
        "}";

    [ObservableProperty]
    string xamlSimpleRemoteMediaElement =
        "<toolkit:MediaElement MinimumHeightRequest=\"200\"\r\n" +
        "                      houldShowPlaybackControls=\"True\"\r\n" +
        "                      Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\" />";


    [ObservableProperty]
    string xamlSimpleLocalMediaElement =
        "<toolkit:MediaElement Source = \"embed://MyFile.mp4\"\r\n" +
        "                      ShouldShowPlaybackControls=\"True\" />";
    [ObservableProperty]
    string mediaSourceStaticMethodsExample =
        "// FromFile\r\n" +
        "var mediaSource = MediaSource.FromFile(\"localfile.mp4\");\r\n" +
        "mediaElement.Source = mediaSource;\r\n\r\n " +
        "// FromUri\r\n " +
        "var mediaSource = MediaSource.FromUri(new Uri(\"https://website.com/media.mp4\"));\r\n" +
        "mediaElement.Source = mediaSource;\r\n\r\n" +
        "// FromResource\r\n" +
        "var mediaSource = MediaSource.FromResource(\"YourAppName.Resources.media.mp4\");\r\n" +
        "mediaElement.Source = mediaSource;";

    [ObservableProperty]
    string mediaSourceExample =
        "// UriMediaSource\r\n" +
        "var uriMediaSource = new UriMediaSource { Uri = new Uri(\"https://website.com/media.mp4\") };\r\n" +
        "mediaElement.Source = uriMediaSource;\r\n\r\n" +
        "// FileMediaSource\r\n" +
        "var fileMediaSource = new FileMediaSource { File = \"media.mp4\" };\r\n" +
        "mediaElement.Source = fileMediaSource;\r\n\r\n" +
        "// ResourceMediaSource\r\n" +
        "var resourceMediaSource = new ResourceMediaSource { Resource = \"YourAppName.Resources.media.mp4\" };\r\n" +
        "mediaElement.Source = resourceMediaSource;";

    [ObservableProperty]
    string aspectRatioExample =
        "<toolkit:MediaElement x:Name=\"MediaElement\" \r\n" +
        "                      Aspect=\"AspectFill\"/>";

    [ObservableProperty]
    string xamlMediaElement =
        "<Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\">\r\n" +
        "     <toolkit:MediaElement x:Name=\"MediaElement\" \r\n" +
        "              ShouldAutoPlay=\"False\"\r\n" +
        "              Volume=\"{x:Binding Volume}\"\r\n" +
        "              MediaEnded=\"OnMediaEnded\"\r\n" +
        "              MediaFailed=\"OnMediaFailed\"\r\n" +
        "              MediaOpened=\"OnMediaOpened\"\r\n" +
        "              PositionChanged=\"OnPositionChanged\"\r\n" +
        "              StateChanged=\"OnStateChanged\"\r\n" +
        "              SeekCompleted=\"OnSeekCompleted\"\r\n" +
        "              Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\"/>\r\n" +
        "</Frame>\r\n" +
        "<Frame Style=\"{x:StaticResource DocumentContentFrameStyle}\">\r\n" +
        "     <HorizontalStackLayout BindingContext=\"{x:Reference MediaElement}\">\r\n" +
        "       <Button Grid.Column=\"0\" Text=\"Play\" Clicked=\"OnPlayClicked\" />\r\n" +
        "       <Button Grid.Column=\"1\" Text=\"Pause\" Clicked=\"OnPauseClicked\" />\r\n" +
        "       <Button Grid.Column=\"2\" Text=\"Stop\" Clicked=\"OnStopClicked\" />\r\n" +
        "       <Button Grid.Column=\"3\" Text=\"Mute\" Clicked=\"OnMuteClicked\">\r\n" +
        "           <Button.Triggers>\r\n" +
        "               <DataTrigger TargetType=\"Button\"\r\n" +
        "                            Binding=\"{Binding ShouldMute, Source={x:Reference MediaElement}}\"\r\n" +
        "                            Value=\"True\">\r\n" +
        "                   <Setter Property=\"Text\" Value=\"Unmute\" />\r\n" +
        "               </DataTrigger>\r\n" +
        "               <DataTrigger TargetType=\"Button\"\r\n" +
        "                            Binding=\"{Binding ShouldMute, Source={x:Reference MediaElement}}\"\r\n" +
        "                            Value=\"False\">\r\n" +
        "                   <Setter Property=\"Text\" Value=\"Mute\" />\r\n" +
        "               </DataTrigger>\r\n" +
        "           </Button.Triggers>\r\n" +
        "     </Button>\r\n" +
        "     <Button Text=\">\" Clicked=\"OnSpeedMinusClicked\" />\r\n" +
        "     <Button Text=\">>>\" Clicked=\"OnSpeedPlusClicked\" />\r\n" +
        "     <Button Text=\"-\" Clicked=\"OnVolumeMinusClicked\" />\r\n" +
        "     <Button Text=\"+\" Clicked=\"OnVolumePlusClicked\" />\r\n" +
        "   </HorizontalStackLayout>\r\n" +
        "</Frame>";

    [ObservableProperty]
    string cSharpMediaElement =
        "void OnMediaOpened(object? sender, EventArgs e) \r\n" +
        "   => MediaElementLogger.LogInformation(\"Media opened.\");\r\n\r\n" +
        "void OnStateChanged(object? sender, MediaStateChangedEventArgs e) \r\n" +
        "   => MediaElementLogger.LogInformation(\"Media State Changed. Old State: {PreviousState}, New State: {NewState}\", e.PreviousState, e.NewState);\r\n\r\n" +
        "void OnMediaFailed(object? sender, MediaFailedEventArgs e) \r\n" +
        "   => MediaElementLogger.LogInformation(\"Media failed. Error: {ErrorMessage}\", e.ErrorMessage);\r\n\r\n" +
        "void OnMediaEnded(object? sender, EventArgs e) \r\n" +
        "   => MediaElementLogger.LogInformation(\"Media ended.\");\r\n\r\n" +
        "void OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)\r\n" +
        "   => MediaElementLogger.LogInformation(\"Position changed to {position}\", e.Position);\r\n\r\n" +
        "void OnSeekCompleted(object? sender, EventArgs e) \r\n" +
        "   => MediaElementLogger.LogInformation(\"Seek completed.\");\r\n\r\n" +
        "void OnSpeedMinusClicked(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    if (MediaElement.Speed >= 1)\r\n" +
        "    {\r\n" +
        "        MediaElement.Speed -= 1;\r\n" +
        "    }\r\n" +
        "}\r\n" +
        "void OnSpeedPlusClicked(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    if (MediaElement.Speed < 10)\r\n" +
        "    {\r\n" +
        "        MediaElement.Speed += 1;\r\n" +
        "    }\r\n" +
        "}\r\n" +
        "void OnVolumeMinusClicked(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    if (MediaElement.Volume >= 0)\r\n" +
        "    {\r\n" +
        "        if (MediaElement.Volume < .1)\r\n" +
        "        {\r\n" +
        "            MediaElement.Volume = 0;\r\n" +
        "            return;\r\n" +
        "        }\r\n\r\n" +
        "        MediaElement.Volume -= .1;\r\n" +
        "    }\r\n" +
        "}\r\n\r\n" +
        "void OnVolumePlusClicked(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    if (MediaElement.Volume < 1)\r\n" +
        "    {\r\n" +
        "        if (MediaElement.Volume > .9)\r\n" +
        "        {\r\n" +
        "            MediaElement.Volume = 1;\r\n" +
        "            return;\r\n" +
        "        }\r\n" +
        "        MediaElement.Volume += .1;\r\n" +
        "    }\r\n" +
        "}\r\n\r\n" +
        "void OnPlayClicked(object? sender, EventArgs e)\r\n" +
        "   => MediaElement.Play();\r\n\r\n" +
        "void OnPauseClicked(object? sender, EventArgs e)\r\n" +
        "   => MediaElement.Pause();\r\n\r\n" +
        "void OnStopClicked(object? sender, EventArgs e)\r\n" +
        "   => MediaElement.Stop();\r\n\r\n" +
        "void OnMuteClicked(object? sender, EventArgs e)\r\n" +
        "   => MediaElement.ShouldMute = !MediaElement.ShouldMute;";

    [ObservableProperty]
    string xamlVolumeControl =
        "<toolkit:MediaElement x:Name=\"MediaElement\" \r\n" +
        "                      ShouldAutoPlay=\"False\"\r\n" +
        "                      Volume=\"{x:Binding Volume, Mode=TwoWay}\" \r\n" +
        "                      Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\"/>\r\n\r\n" +
        "<Slider x:Name=\"VolumeSlider\"\r\n" +
        "        IsEnabled=\"True\"\r\n" +
        "        Maximum=\"1.0\"\r\n" +
        "        Minimum=\"0.0\"\r\n" +
        "        MinimumTrackColor=\"Gray\"\r\n" +
        "        Value=\"{x:Binding Volume, Mode=TwoWay}\"\r\n" +
        "        WidthRequest=\"200\" />";

    [ObservableProperty]
    string cSharpVolumeControl =
        "[ObservableProperty]\r\n" +
        "double volume;\r\n ";

    [ObservableProperty]
    string xamlPositionControl =
        "<toolkit:MediaElement x:Name=\"MediaElement\" \r\n" +
        "                      ShouldAutoPlay=\"False\"\r\n" +
        "                      PositionChanged=\"OnPositionChanged\"\r\n" +
        "                      Source=\"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4\"/>\r\n\r\n" +
        "<Slider x:Name=\"PositionSlider\"\r\n" +
        "        IsEnabled=\"True\"\r\n" +
        "        MinimumTrackColor=\"Gray\"\r\n" +
        "        DragStarted=\"Slider_DragStarted\"\r\n" +
        "        DragCompleted=\"Slider_DragCompleted\"\r\n" +
        "        WidthRequest=\"200\" />";

    [ObservableProperty]
    string cSharpPositionControl =
        "public MediaElementPage(MediaElementPageViewModel vm)\r\n" +
        "{\r\n" +
        "     InitializeComponent();\r\n\r\n" +
        "     BindingContext = vm;\r\n" +
        "     MediaElement.PropertyChanged += MediaElementPropertyChanged;\r\n" +
        "}\r\n\r\n" +
        "void MediaElementPropertyChanged(object? sender, PropertyChangedEventArgs e)\r\n" +
        "{\r\n" +
        "    if (e.PropertyName == MediaElement.DurationProperty.PropertyName)\r\n" +
        "    {\r\n" +
        "        PositionSlider.Maximum = MediaElement.Duration.TotalSeconds;\r\n" +
        "    }\r\n" +
        "}\r\n" +
        "void OnPositionChanged(object? sender, MediaPositionChangedEventArgs e)\r\n" +
        "{\r\n" +
        "    PositionSlider.Value = e.Position.TotalSeconds;\r\n" +
        "}\r\n" +
        "void Slider_DragCompleted(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    ArgumentNullException.ThrowIfNull(sender);\r\n\r\n" +
        "    var newValue = ((Slider)sender).Value;\r\n" +
        "    MediaElement.SeekTo(TimeSpan.FromSeconds(newValue));\r\n\r\n" +
        "    MediaElement.Play();\r\n" +
        "}\r\n\r\n" +
        "void Slider_DragStarted(object sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    MediaElement.Pause();\r\n" +
        "}";

    [ObservableProperty]
    string xamlCleanUpProperty = "Unloaded=\"ContentPage_Unloaded\"";

    [ObservableProperty]
    string cleanUpOnDisappearing = "";

    [ObservableProperty]
    string xamlCleanUpMediaElementResourcesRemovedVisualTree =
        "<app:BasePage\r\n" +
        "    x:Class=\"MAUIsland.MediaElementPage\"\r\n" +
        "    x:DataType=\"app:MediaElementPageViewModel\"\r\n" +
        "    xmlns=\"http://schemas.microsoft.com/dotnet/2021/maui\"\r\n" +
        "    xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\"\r\n" +
        "    xmlns:app=\"clr-namespace:MAUIsland\"\r\n" +
        "    xmlns:toolkit=\"http://schemas.microsoft.com/dotnet/2022/maui/toolkit\"\r\n" +
        "    Loaded=\"ContentPage_Loaded\"\r\n" +
        "    Unloaded=\"ContentPage_Unloaded\">\r\n" +
        "</app:BasePage>";

    [ObservableProperty]
    string cSharpCleanUpMediaElementResourcesRemovedVisualTree =
        "void ContentPage_Unloaded(object? sender, EventArgs e)\r\n" +
        "{\r\n" +
        "    MediaElementDownloadSample.Handler?.DisconnectHandler();\r\n" +
        "    MediaElement.Handler?.DisconnectHandler();\r\n" +
        "    SimpleMediaElement.Handler?.DisconnectHandler();\r\n" +
        "}";

    [ObservableProperty]
    string cleanUpMediaElementResourcesPageInvisible =
        "protected override void OnDisappearing()\r\n" +
        "{\r\n" +
        "     base.OnDisappearing();\r\n\r\n" +
        "     // Disconnect the event handlers.\r\n" +
        "     MediaElement.MediaEnded -= OnMediaEnded;\r\n" +
        "     MediaElement.MediaFailed -= OnMediaFailed;\r\n" +
        "     MediaElement.MediaOpened -= OnMediaOpened;\r\n" +
        "     MediaElement.PositionChanged -= OnPositionChanged;\r\n" +
        "     MediaElement.StateChanged -= OnStateChanged;\r\n" +
        "     MediaElement.SeekCompleted -= OnSeekCompleted;\r\n\r\n" +
        "     // Set the Source property to null.\r\n" +
        "     MediaElement.Source = null;\r\n    }";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);
        Volume = 0.5;
        ControlInformation = query.GetData<IGalleryCardInfo>();
    }
    #endregion

    #region [ Relay Commands ]
    [RelayCommand]
    Task OpenUrlAsync(string url)
    => AppNavigator.OpenUrlAsync(url);
    #endregion
}

public partial class SupportedFormatsTable
{
    public string Platform { get; set; }
    public string Link { get; set; }
    public string Notes { get; set; }
}