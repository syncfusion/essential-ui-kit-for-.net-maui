using EssentialMAUIUIKit.Models;
using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Feedback
{
    public partial class FeedbackPage : ContentView
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Toggles the favourite state of the tapped review. The glyph (filled
        /// vs outline) and colour (Red vs dark gray) are driven by
        /// <see cref="Review.IsFavourite"/> through the
        /// <c>BooleanToStringConverter</c> (parameter 1) and
        /// <c>BooleanToColorConverter</c> (parameter 4) registered in the page
        /// resources. Mirrors <c>ProductDetailPage.FavouriteButton_Clicked</c>.
        /// </summary>
        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            SfButton? button = sender as SfButton;
            var review = button?.BindingContext as EssentialMAUIUIKit.Models.Review;
            if (review != null)
            {
                review.IsFavourite = !review.IsFavourite;

                if(review.IsFavourite)
                {
                    review.LikeCount += 1;
                }
                else
                {
                    review.LikeCount -= 1;
                }
            }
        }
    }
}