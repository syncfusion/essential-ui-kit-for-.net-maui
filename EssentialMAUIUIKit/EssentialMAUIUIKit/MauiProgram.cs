namespace EssentialMAUIUIKit
{
#if ANDROID
    using Android.Graphics;
    using Android.Content.Res;
#elif WINDOWS
    using Microsoft.UI.Xaml.Controls;
#endif
    using Microsoft.Extensions.Logging;
    using Microsoft.Maui.Handlers;
    using Syncfusion.Maui.Core.Hosting;
    using Syncfusion.Maui.Toolkit.Hosting;

    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureSyncfusionCore()
                .ConfigureSyncfusionToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Medium.ttf", "Roboto-Medium");
                    fonts.AddFont("Roboto-Regular.ttf", "Roboto-Regular");
                    fonts.AddFont("Righteous-Regular.ttf", "Righteous");
                    fonts.AddFont("UIFontIcons.ttf", "FontIcons");
                    fonts.AddFont("Dashboard.ttf", "DashboardFontIcons");
                    fonts.AddFont("MauiMaterialAssets.ttf", "MaterialAssets");
                    fonts.AddFont("UIKitIcons.ttf", "UIKitIcons");
                });

            DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList =
                    ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

#elif WINDOWS
                var nativeDatePicker = handler.PlatformView;
                if (nativeDatePicker != null)
                {
                    // Hook into Loaded and subsequent layout updates because the templated child
                    // icons (calendar glyph + dropdown glyph) are generated asynchronously.
                    Microsoft.UI.Xaml.RoutedEventHandler? hideIcons = null;
                    hideIcons = (s, e) =>
                    {
                        HideCalendarIcons(nativeDatePicker);
                    };

                    nativeDatePicker.Loaded += hideIcons;

                    // Re-run after every layout pass to catch icons generated after Loaded
                    nativeDatePicker.LayoutUpdated += (s, e) => HideCalendarIcons(nativeDatePicker);
                }

                var datePicker = handler.PlatformView;
                datePicker.Margin = new Microsoft.UI.Xaml.Thickness(0);
                datePicker.BorderBrush = null;
                datePicker.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

#if WINDOWS
        // Walk the visual tree and collapse any FontIcon whose glyph corresponds to a calendar.
        // The WinUI CalendarDatePicker renders its built-in icon as a FontIcon with the
        // "Calendar" Segoe MDL2 glyph (U+E787 / U+F08A / U+E8BF depending on theme resources).
        private static void HideCalendarIcons(Microsoft.UI.Xaml.DependencyObject parent)
        {
            int childrenCount = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChild(parent, i);

                if (child is Microsoft.UI.Xaml.Controls.FontIcon fontIcon)
                {
                    string? glyph = fontIcon.Glyph;
                    // Common calendar glyphs used in WinUI CalendarDatePicker template
                    if (!string.IsNullOrEmpty(glyph) &&
                        (glyph == "\uE787" || glyph == "\uF08A" || glyph == "\uE8BF" || glyph == "\uE787F"))
                    {
                        fontIcon.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                        fontIcon.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);
                    }
                }

                HideCalendarIcons(child);
            }
        }
#endif
    }
}
