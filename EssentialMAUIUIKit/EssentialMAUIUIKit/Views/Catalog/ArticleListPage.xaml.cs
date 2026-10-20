using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class ArticleListPage : ContentView
    {
        public ArticleListPage()
        {
            InitializeComponent();
        }

        private void BookmarkButton_Clicked(object sender, EventArgs e)
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