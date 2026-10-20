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

        private void FavouriteButton_Clicked_1(object sender, EventArgs e)
        {
            if (sender is not SfButton button)
            {
                return;
            }

            if (button.BindingContext is not EssentialMAUIUIKit.Models.Story @event)
            {
                return;
            }

            @event.IsFavourite = !@event.IsFavourite;
            @event.NotifyPropertyChanged(nameof(@event.IsFavourite));
        }
    }
}