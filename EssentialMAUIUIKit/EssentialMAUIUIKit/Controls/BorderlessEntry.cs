#if ANDROID
using Android.Content.Res;
#endif
using Microsoft.Maui.Platform;

namespace EssentialMAUIUIKit.Controls
{
    /// <summary>
    /// An <see cref="Entry"/> with the native platform border / underline removed.
    /// Applies to Android (background tint), Windows (border thickness and
    /// focused-stroke thickness), and MacCatalyst (UITextBorderStyle).
    /// On iOS the default <see cref="Entry"/> already has no border.
    /// </summary>
    public class BorderlessEntry : Entry
    {
        public BorderlessEntry()
        {
#if ANDROID
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
                    handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                }
            });
#endif
#if WINDOWS
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                    handler.PlatformView.Resources["TextControlBorderThemeThicknessFocused"] = new Microsoft.UI.Xaml.Thickness(0);
                }
            });
#endif
#if MACCATALYST
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                }
            });
#endif
        }
    }
}
