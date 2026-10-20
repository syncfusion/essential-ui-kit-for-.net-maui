using EssentialMAUIUIKit.ViewModel;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Models.Notification
{
    /// <summary>
    /// Model for the E-Commerce notification page.
    /// </summary>
    public class ECommerceNotificationsListModel : BaseViewModel
    {
        #region Field

        private bool isRead;
        private string? notificationIcon;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the notification icon key (e.g. "Delivered"). The
        /// <see cref="Glyph"/> property resolves this key against the
        /// <c>FontIcons</c> resource dictionary so the page can bind
        /// directly without a converter.
        /// </summary>
        public string? NotificationIcon
        {
            get { return this.notificationIcon; }
            set { this.SetProperty(ref this.notificationIcon, value); }
        }

        /// <summary>
        /// Gets the resolved font icon glyph for the current
        /// <see cref="NotificationIcon"/> key. Returns an empty string when
        /// the key is missing or the resource cannot be located.
        /// </summary>
        public string Glyph
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.notificationIcon))
                {
                    return string.Empty;
                }

                if (Application.Current?.Resources.TryGetValue(this.notificationIcon, out var resource) == true
                    && resource is string glyph)
                {
                    return glyph;
                }

                return string.Empty;
            }
        }

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

            set
            {
                if (this.SetProperty(ref this.isRead, value))
                {
                    this.NotifyPropertyChanged(nameof(this.SemanticDescription));
                }
            }
        }

        /// <summary>
        /// Screen reader friendly description combining the notification
        /// text and relative time.
        /// </summary>
        public string SemanticDescription
        {
            get
            {
                var readState = this.isRead ? "read" : "unread";
                return string.IsNullOrWhiteSpace(this.Time)
                    ? $"{this.Description}, {readState}"
                    : $"{this.Description}, {this.Time}, {readState}";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises change notifications for the <see cref="Glyph"/> property
        /// whenever the <see cref="NotificationIcon"/> key is reassigned.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected new void NotifyPropertyChanged(string? propertyName = null)
        {
            base.NotifyPropertyChanged(propertyName);
            if (string.Equals(propertyName, nameof(this.NotificationIcon), System.StringComparison.Ordinal))
            {
                base.NotifyPropertyChanged(nameof(this.Glyph));
            }
        }

        #endregion
    }
}