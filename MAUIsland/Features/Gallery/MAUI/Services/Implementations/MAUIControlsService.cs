﻿namespace MAUIsland;

public class MAUIControlsService : IMAUIControlsService
{

    public Task<IEnumerable<ControlInfo>> GetAllControlInfoAsync()
    {
        return Task.Run(() =>
        {
            var controls = new List<ControlInfo>();
            controls.Add(new ControlInfo()
            {
                ControlName = "Button",
                ControlRoute = AppRoutes.ButtonPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_add_circle_32_regular
                },
                ControlDetail = "Button displays text and responds to a tap or click that directs the app to carry out a task. A Button usually displays a short text string indicating a command, but it can also display a bitmap image, or a combination of text and an image. When the Button is pressed with a finger or clicked with a mouse it initiates that command."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Image Button",
                ControlRoute = AppRoutes.ImageButtonPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_image_add_24_regular
                },
                ControlDetail = "ImageButton view combines the Button view and Image view to create a button whose content is an image. When you press the ImageButton with a finger or click it with a mouse, it directs the app to carry out a task. However, unlike the Button the ImageButton view has no concept of text and text appearance."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Activity Indicator",
                ControlRoute = AppRoutes.ActivityIndicatorPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_approvals_app_20_regular
                },
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Editor",
                ControlRoute = AppRoutes.EditorPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_code_text_edit_20_regular
                },
                ControlDetail = "ActivityIndicator displays an animation to show that the application is engaged in a lengthy activity. Unlike ProgressBar, ActivityIndicator gives no indication of progress."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Date Picker",
                ControlRoute = AppRoutes.DatePickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_calendar_3_day_28_regular
                },
                ControlDetail = "DatePicker invokes the platform's date-picker control and allows you to select a date."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Progress Bar",
                ControlRoute = AppRoutes.ProgressBarPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_battery_2_24_regular
                },
                ControlDetail = "ProgressBar indicates to users that the app is progressing through a lengthy activity. The progress bar is a horizontal bar that is filled to a percentage represented by a double value."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Picker",
                ControlRoute = AppRoutes.PickerPage,
                ControlIcon = new FontImageSource()
                {
                    FontFamily = FontNames.FluentSystemIconsRegular,
                    Glyph = FluentUIIcon.Ic_fluent_time_picker_24_regular
                },
                ControlDetail = "Picker displays a short list of items, from which the user can select an item."
            });

            controls.Add(new ControlInfo()
            {
                ControlName = "Slider",
                ControlRoute = AppRoutes.SliderPage,
                ControlIcon = "fluenticon_options_white.png",
                ControlDetail = "Slider is a horizontal bar that you can manipulate to select a double value from a continuous range."
            });

            return controls.AsEnumerable();
        });
    }
}
