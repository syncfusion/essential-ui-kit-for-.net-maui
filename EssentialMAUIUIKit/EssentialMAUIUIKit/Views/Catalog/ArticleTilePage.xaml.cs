using Syncfusion.Maui.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class ArticleTilePage : ContentView
    {
        public ArticleTilePage()
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
    }
}