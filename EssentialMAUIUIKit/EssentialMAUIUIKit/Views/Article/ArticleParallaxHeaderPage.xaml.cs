using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Article
{
    public partial class ArticleParallaxHeaderPage : ContentView
    {
        public ArticleParallaxHeaderPage()
        {
            InitializeComponent();
        }

        private void SfButton_Clicked(object sender, EventArgs e)
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