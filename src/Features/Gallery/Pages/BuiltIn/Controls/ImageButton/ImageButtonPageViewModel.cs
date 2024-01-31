﻿namespace MAUIsland;

public partial class ImageButtonPageViewModel : NavigationAwareBaseViewModel
{
    #region [Services]
    private readonly IFilePicker filePicker;
    #endregion

    #region [CTor]
    public ImageButtonPageViewModel(IAppNavigator appNavigator,
                                    IFilePicker filePicker)
                                : base(appNavigator)
    {
        this.filePicker = filePicker;
    }
    #endregion

    #region [Properties]
    [ObservableProperty]
    IGalleryCardInfo controlInformation;

    [ObservableProperty]
    ImageSource imageSourceSample;

    [ObservableProperty]
    string imageButtonClickedCheck = "No Image To Click";

    [ObservableProperty]
    int imageButtonClickCount;
    #endregion

    #region [Overrides]
    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        ControlInformation = query.GetData<IGalleryCardInfo>();

    }
    #endregion

    #region [Relay Commands]
    [RelayCommand]
    Task OpenUrlAsync(string url)
        => AppNavigator.OpenUrlAsync(url);

    [RelayCommand]
    async Task OpenFileAsync()
    {
        var pickedImage = await filePicker.OpenMediaPickerAsync();

        var imagefile = await filePicker.UploadImageFile(pickedImage);

        ImageSourceSample = ImageSource.FromStream(() =>
            filePicker.ByteArrayToStream(filePicker.StringToByteBase64(imagefile?.byteBase64))
        );
        ImageButtonClickedCheck = "Image Loaded";
    }

    [RelayCommand]
    void ClickedCheck()
    {
        ImageButtonClickedCheck = "You Clicked the Image";
    }

    [RelayCommand]
    void ClickedCount()
    {
        ImageButtonClickCount += 1;
    }
    #endregion
}
