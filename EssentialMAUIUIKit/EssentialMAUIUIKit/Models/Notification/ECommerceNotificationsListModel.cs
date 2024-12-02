using EssentialMAUIUIKit.ViewModel;

namespace EssentialMAUIUIKit.Models.Notification
{
    /// <summary>
    /// Model for the E-Commerce notification page.
    /// </summary>
    public class ECommerceNotificationsListModel : BaseViewModel
    {
        #region Field

        private bool isRead;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the notification Icon.
        /// </summary>
        public string? NotificationIcon { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the background color inside the circular border.
        /// </summary>
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public string? Time { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the notification item is read or not.
        /// </summary>
        public bool IsRead
        {
            get { return this.isRead; }

            set { this.SetProperty(ref this.isRead, value); }
        }

        #endregion
    }
}