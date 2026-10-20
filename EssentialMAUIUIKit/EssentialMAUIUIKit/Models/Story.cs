using System.ComponentModel;
using System.Windows.Input;

namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Model for Article templates.
    /// </summary>
    public class Story : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Gets or sets a value indicating image path.
        /// </summary>
        private string? imagePath;
        private bool isBookmarked;
        private bool isFavourite;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the article image path.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return App.ImageServerPath + imagePath;
            }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the article name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the article related title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the article trending or not.
        /// </summary>
        public bool? IsTrending { get; set; }

        /// <summary>
        /// Gets or sets the article author name.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the article publish date.
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// Gets or sets the article read time.
        /// </summary>
        public string? AverageReadingTime { get; set; }

        /// <summary>
        /// Gets or sets the article description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the article is bookmarked.
        /// </summary>
        public bool IsBookmarked
        {
            get
            {
                return this.isBookmarked;
            }

            set
            {
                this.isBookmarked = value;
                this.NotifyPropertyChanged(nameof(this.IsBookmarked));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the article is favourite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                if (this.isFavourite == value)
                {
                    return;
                }

                this.isFavourite = value;
				this.NotifyPropertyChanged(nameof(this.IsFavourite));
			}
        }

        /// <summary>
        /// Gets or sets the bookmarked count.
        /// </summary>
        public int BookmarkedCount { get; set; }

        /// <summary>
        /// Gets or sets the favourite count.
        /// </summary>
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Gets or sets the shared count.
        /// </summary>
        public int SharedCount { get; set; }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        #region Commands

        /// <summary>
        /// Gets the command that toggles the bookmark state.
        /// </summary>
        public ICommand ToggleBookmarkCommand => new Command(() =>
        {
            this.IsBookmarked = !this.IsBookmarked;
        });

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}