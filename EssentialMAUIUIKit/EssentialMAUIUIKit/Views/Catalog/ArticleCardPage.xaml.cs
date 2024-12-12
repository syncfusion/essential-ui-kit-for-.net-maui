using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class ArticleCardPage : ContentView
    {
        public ArticleCardPage()
        {
            InitializeComponent();
        }

        private void BookmarkButton_Clicked(object sender, EventArgs e)
        {
            SfButton? button = sender as SfButton;
            var story = button?.BindingContext as EssentialMAUIUIKit.Models.Story;
            if (story != null)
            {
                story.IsBookmarked = !story.IsBookmarked;
            }
        }

        private void FavouriteButton_Clicked_1(object sender, EventArgs e)
        {
            SfButton? button = sender as SfButton;
            var story = button?.BindingContext as EssentialMAUIUIKit.Models.Story;
            if (story != null)
            {
                story.IsFavourite = !story.IsFavourite;
            }
        }
    }
}