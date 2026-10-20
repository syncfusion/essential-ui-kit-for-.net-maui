using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Chat;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View-model for the chat conversation page.
    /// </summary>
    public class ChatMessageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private bool isBadgeViewVisible;
        private ObservableCollection<object>? messages;
        private Author? currentUser;
        private Author? partner;
        private bool? showTypingIndicator;
        private ChatTypingIndicator? typingIndicator;
        private ICommand? sendMessageCommand;
        private string messageCount = string.Empty;
        private string messageText = string.Empty;
        private ICommand? attachmentCommand;
        private ICommand? audioCommand;
        private ICommand? micCommand;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatMessageViewModel"/> class.
        /// </summary>
        public ChatMessageViewModel()
        {
            this.Messages = new ObservableCollection<object>();
            this.TypingIndicator = new ChatTypingIndicator();

            // Create two authors: the current user (outgoing) and a partner (incoming).
            var me = new Author { Name = "You" };
            var partner = new Author
            {
                Name = "Danielle Schneider",
                Avatar = App.ImageServerPath + "ProfileImage3.png"
            };

            this.CurrentUser = me;
            this.Partner = partner;

            var today = DateTime.Today;

            // Today's messages – seeded for the sample conversation.
            this.Messages.Add(new TextMessage
            {
                DateTime = today.AddHours(15),
                Author = this.Partner,
                Text = "Hey John! That sounds awesome. I've been wanting to get out and enjoy some fresh air. Do you have a place in mind?"
            });

            this.Messages.Add(new TextMessage
            {
                DateTime = today.AddHours(16).AddMinutes(11),
                Author = this.CurrentUser,
                Text = "Yeah, I was thinking about checking out Green Valley Trail. I've heard it's beautiful this time of year with all the wildflowers blooming."
            });

            this.Messages.Add(new ImageMessage
            {
                DateTime = today.AddHours(16).AddMinutes(12),
                Author = this.CurrentUser,
                Source = "deer.png"
            });

            this.Messages.Add(new TextMessage
            {
                DateTime = today.AddHours(16).AddMinutes(13),
                Author = this.CurrentUser,
                Text = "Ooh, that sounds perfect! How long is the trail?"
            });

            this.Messages.Add(new TextMessage
            {
                DateTime = today.AddHours(16).AddMinutes(14),
                Author = this.Partner,
                Text = "It's about 5 miles round trip, so it's a good workout but not too intense. We could take it easy and bring some snacks for a picnic at the top."
            });

            this.SendMessageCommand = new Command<object>(this.OnSendMessage);
            this.AttachmentCommand = new Command(this.OnAttachmentTapped);
            this.AudioCommand = new Command(this.OnAudioTapped);
            this.MicCommand = new Command(this.OnMicTapped);
        }

        #region Public Properties

        public ICommand? SendMessageCommand
        {
            get => this.sendMessageCommand;
            set => this.SetProperty(ref this.sendMessageCommand, value);
        }

        public ICommand? AttachmentCommand
        {
            get => this.attachmentCommand;
            set => this.SetProperty(ref this.attachmentCommand, value);
        }

        public ICommand? AudioCommand
        {
            get => this.audioCommand;
            set => this.SetProperty(ref this.audioCommand, value);
        }

        /// <summary>
        /// Gets or sets the command invoked when the microphone button is tapped.
        /// </summary>
        public ICommand? MicCommand
        {
            get => this.micCommand;
            set => this.SetProperty(ref this.micCommand, value);
        }

        public string MessageCount
        {
            get => this.messageCount;
            set => this.SetProperty(ref this.messageCount, value);
        }

        public ChatTypingIndicator? TypingIndicator
        {
            get => this.typingIndicator;
            private set => this.SetProperty(ref this.typingIndicator, value);
        }

        public bool? ShowTypingIndicator
        {
            get => this.showTypingIndicator;
            private set => this.SetProperty(ref this.showTypingIndicator, value);
        }

        public bool IsBadgeViewVisible
        {
            get => this.isBadgeViewVisible;
            set => this.SetProperty(ref this.isBadgeViewVisible, value);
        }

        public ObservableCollection<object>? Messages
        {
            get => this.messages;
            set => this.SetProperty(ref this.messages, value);
        }

        public Author? CurrentUser
        {
            get => this.currentUser;
            set => this.SetProperty(ref this.currentUser, value);
        }

        public Author? Partner
        {
            get => this.partner;
            set => this.SetProperty(ref this.partner, value);
        }

        /// <summary>
        /// Gets or sets the text currently in the message composer.
        /// </summary>
        public string MessageText
        {
            get => this.messageText;
            set => this.SetProperty(ref this.messageText, value);
        }

        #endregion

        #region Property Changed

        private void OnSendMessage(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(this.MessageText))
            {
                return;
            }

            // Ensure the underlying collection exists before mutating it.
            this.Messages ??= new ObservableCollection<object>();

            // Choose a timestamp that is strictly later than the most recent
            // message in the conversation. Real "now" can fall earlier than the
            // seeded sample messages (e.g. a sample seeded at 4:14 PM with the
            // wall clock at 10:46 AM) and the SfChat control groups / orders
            // items by DateTime, which would otherwise place the new outgoing
            // message above the seeded ones and just below the "Today" time
            // break instead of at the bottom of the conversation.
            DateTime sentAt = DateTime.Now;
            DateTime latest = DateTime.MinValue;
            foreach (var item in this.Messages)
            {
                if (item is TextMessage text)
                {
                    if (text.DateTime > latest)
                    {
                        latest = text.DateTime;
                    }
                }
                else if (item is ImageMessage image)
                {
                    if (image.DateTime > latest)
                    {
                        latest = image.DateTime;
                    }
                }
            }

            if (sentAt <= latest)
            {
                sentAt = latest.AddSeconds(1);
            }

            // Append the typed text as a new outgoing message from the current user.
            // CurrentUser is nullable in the public contract but is always set in
            // the constructor for this sample; the null-forgiving operator is safe
            // here and mirrors the original Partner-assignment pattern used at
            // construction time.
            this.Messages.Add(new TextMessage
            {
                Author = this.CurrentUser!,
                Text = this.MessageText,
                DateTime = sentAt
            });

            // Clear the composer so the entry resets after the message is dispatched.
            this.MessageText = string.Empty;
        }

        private void OnAttachmentTapped()
        {
            // Sample page: attachment picker is intentionally not implemented.
        }

        private void OnAudioTapped()
        {
            // Sample page: audio capture is intentionally not implemented.
        }

        private void OnMicTapped()
        {
            // Sample page: voice recording is intentionally not implemented.
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
