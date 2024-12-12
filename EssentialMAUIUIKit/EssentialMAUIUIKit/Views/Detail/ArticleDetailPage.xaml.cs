using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Detail
{
    public partial class ArticleDetailPage : ContentView
    {
        public ArticleDetailPage()
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