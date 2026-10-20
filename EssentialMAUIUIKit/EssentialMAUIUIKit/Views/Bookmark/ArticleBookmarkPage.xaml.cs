using Microsoft.Maui.Controls;
using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Bookmark
{
    /// <summary>
    /// Code-behind for the Article Bookmark page. Bookmark
    /// toggling is driven by a command on the bound
    /// <see cref="Models.Story"/> instance, so the code-behind
    /// no longer needs to reach into template elements.
    /// </summary>
    public partial class ArticleBookmarkPage : ContentView
    {
        public ArticleBookmarkPage()
        {
            InitializeComponent();
        }

        private async void OnArticleItemTapped(object sender, TappedEventArgs e)
        {
            if (sender is Border border)
            {
                await border.ScaleToAsync(0.97, 80, Easing.CubicOut);
                await border.ScaleToAsync(1.0, 80, Easing.CubicIn);
            }
        }

        private void ArticleBookmarkButton_Clicked(object sender, EventArgs e)
        {
            if (sender is not SfButton button)
            {
                return;
            }
            if (button.BindingContext is not EssentialMAUIUIKit.Models.Story story)
            {
                return;
            }
            story.IsBookmarked = !story.IsBookmarked;
            story.NotifyPropertyChanged(nameof(story.IsBookmarked));
        }
    }
}