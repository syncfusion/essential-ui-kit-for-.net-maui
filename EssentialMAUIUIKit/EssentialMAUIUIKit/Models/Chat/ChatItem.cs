using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EssentialMAUIUIKit.Models.Chat
{
    /// <summary>
    /// Represents a single row in the Recent Chat list.
    /// </summary>
    public class ChatItem : INotifyPropertyChanged
    {
        private string? imagePath;
        private bool isUnread;
        private string? resolvedImagePath;

        /// <summary>
        /// Gets or sets the raw image path stored in the data source.
        /// </summary>
        public string? ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                if (this.SetProperty(ref this.imagePath, value))
                {
                    // Invalidate the cached, fully-qualified URL so it is recomputed
                    // the next time the binding evaluates.
                    this.resolvedImagePath = null;
                    this.OnPropertyChanged(nameof(ResolvedImagePath));
                }
            }
        }

        /// <summary>
        /// Gets the image path with <see cref="App.ImageServerPath"/> applied.
        /// Cached on first read to avoid repeated string allocations during list rendering.
        /// </summary>
        public string? ResolvedImagePath
        {
            get
            {
                if (this.resolvedImagePath != null)
                {
                    return this.resolvedImagePath;
                }

                if (string.IsNullOrWhiteSpace(this.imagePath))
                {
                    return null;
                }

                this.resolvedImagePath = this.imagePath!.Contains(App.ImageServerPath)
                    ? this.imagePath
                    : App.ImageServerPath + this.imagePath;

                return this.resolvedImagePath;
            }
        }

        public string? SenderName { get; set; }
        public string? MessageType { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
        public string? NotificationType { get; set; }
        public string? AvailableStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the chat has unread messages.
        /// Raises <see cref="PropertyChanged"/> so triggers in the XAML update.
        /// </summary>
        public bool IsUnread
        {
            get
            {
                return this.isUnread;
            }

            set
            {
                this.SetProperty(ref this.isUnread, value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string? propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
