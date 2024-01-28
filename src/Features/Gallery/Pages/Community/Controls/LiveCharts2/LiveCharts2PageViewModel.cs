using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace MAUIsland;
public partial class LiveCharts2PageViewModel : NavigationAwareBaseViewModel
{
    #region [ CTor ]
    public LiveCharts2PageViewModel( IAppNavigator appNavigator ) 
        : base(appNavigator)
    {
        LoadLiveChartDesign();
    }
    #endregion

    #region [ LiveCharts Properties ]
    public ISeries[] Series { get; set; }

    public Axis[] XAxes { get; set; }
    #endregion

    #region [ Properties ]
    [ObservableProperty]    
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    string setupDescription =
        "In order to use the LiveCharts2 you would like to install LiveChartsCore.SkiaSharpView.Maui from NuGet. After that, in XAML, the following xmlns needs to be added into your page or view:";

    [ObservableProperty]
    string xamlNamespace =
        "xmlns:lc2=\"clr-namespace:LiveChartsCore.SkiaSharpView.Maui;assembly=LiveChartsCore.SkiaSharpView.Maui\"";

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
        "    xmlns:lc2=\"clr-namespace:LiveChartsCore.SkiaSharpView.Maui;assembly=LiveChartsCore.SkiaSharpView.Maui\"\r\n" +
        "</ContentPage>";
    #endregion

    #region [ Overrides ]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

        LoadDataAsync().FireAndForget();
    }
    #endregion

    #region [Relay Commands]

    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    Task OpenCartesianChartControlUrlAsync()
        => AppNavigator.OpenUrlAsync("https://livecharts.dev/docs/Maui/2.0.0-rc2/CartesianChart.Cartesian%20chart%20control");

    #endregion

    #region [ Data ]
    private async Task LoadDataAsync()
    {
    }
    #endregion

    #region [ LiveChart Designs ]
    private void LoadLiveChartDesign()
    {
        Series = new[]
        {
            new ColumnSeries<double>
            {
                Name = "Mary",
                Values = new double[] { 2, 5, 4 }
            },
            new ColumnSeries<double>
            {
                Name = "Ana",
                Values = new double[] { 3, 1, 6 }
            }
        };
        XAxes = new[]
        {
            new Axis()
            {
                Labels = new string[] { "Category 1", "Category 2", "Category 3" },
                LabelsRotation = 0,
                SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                SeparatorsAtCenter = false,
                TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                TicksAtCenter = true,
                ForceStepToMin = true,
                MinStep = 1
            }
        };

    }
    #endregion
}