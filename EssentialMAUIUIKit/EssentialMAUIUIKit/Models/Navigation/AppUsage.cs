namespace EssentialMAUIUIKit.Models.Navigation
{
    /// <summary>
    /// Model for the app usage list page.
    /// </summary>
    public class AppUsage
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the app.
        /// </summary>
        public string? AppName { get; set; }

        /// <summary>
        /// Gets or sets the progress bar value.
        /// </summary>
        public string? ProgressBarValue { get; set; }

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        public string? ProgressValue { get; set; }

        /// <summary>
        /// Gets or sets the background color for the app within the circular border.
        /// </summary>
        public string? BackgroundColor { get; set; }

        #endregion
    }
}