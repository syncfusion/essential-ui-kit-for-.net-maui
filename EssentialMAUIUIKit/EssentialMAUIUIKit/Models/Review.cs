using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Model for review list.
    /// </summary>
    public class Review : INotifyPropertyChanged
    {
        #region Field

        /// <summary>
        /// Gets or sets the images
        /// </summary>
        private List<string>? customerReviewImages;

        /// <summary>
        /// Gets or sets the profile image
        /// </summary>
        private string? customerImage;

        private bool isFavourite;

        private double likeCount = 6;

        #endregion

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the customer image.
        /// </summary>
        public string CustomerImage
        {
            get { return App.ImageServerPath + this.customerImage; }
            set { this.customerImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with an image, which displays the customer added image.
        /// </summary>
        public List<string>? CustomerReviewImages
        {
            get { return this.customerReviewImages; }
            set { this.customerReviewImages = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the customer name.
        /// </summary>
        public string? CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the commented date.
        /// </summary>
        public string? ReviewedDate { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with SfRating control, which displays the rating of the item.
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the comment updated by the customer.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the Review title updated by the customer.
        /// </summary>
        public string? ReviewTitle { get; set; }

        /// <summary>
        /// Gets or sets the number of likes on this review. Incremented when
        /// the user taps the favourite icon and the review is not already
        /// favourited. The setter raises <see cref="PropertyChanged"/> so
        /// the bound count label on <c>FeedbackPage.xaml</c> re-renders.
        /// Initial value of 6 matches the static "6" previously shown in XAML.
        /// </summary>
        public double LikeCount
        {
            get => likeCount;
            set
            {
                if (likeCount != value)
                {
                    likeCount = value;
                    OnPropertyChanged(nameof(LikeCount));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the review has been marked as favourite.
        /// Drives the Favourite icon button on the feedback page via the
        /// BooleanToStringConverter (parameter 1) and BooleanToColorConverter
        /// (parameter 4). Mirrors the pattern on <see cref="EssentialMAUIUIKit.ProductImage"/>.
        /// </summary>
        public bool IsFavourite
        {
            get => isFavourite;
            set
            {
                if (isFavourite != value)
                {
                    isFavourite = value;
                    OnPropertyChanged(nameof(IsFavourite));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
