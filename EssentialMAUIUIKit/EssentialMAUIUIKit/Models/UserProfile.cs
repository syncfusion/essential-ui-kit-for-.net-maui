namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Model for SocialProfile
    /// </summary>
    public class UserProfile
    {
        #region Fields

        private string? imagePath;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        #endregion
    }
}