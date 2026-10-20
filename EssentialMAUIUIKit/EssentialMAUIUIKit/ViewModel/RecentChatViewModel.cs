using System.Collections.ObjectModel;
using EssentialMAUIUIKit.Models.Chat;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View-model for the Recent Chat list page.
    /// </summary>
    public class RecentChatViewModel
    {
        /// <summary>
        /// Gets the collection of chat items shown in the list.
        /// </summary>
        public ObservableCollection<ChatItem> ChatItems { get; }

        /// <summary>
        /// Gets the header profile image shown in the Recent Chat page title bar.
        /// Surfaces the avatar of the currently active conversation so the XAML
        /// can bind declaratively instead of indexing into <see cref="ChatItems"/>.
        /// </summary>
        public string ActiveChatImage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentChatViewModel"/> class.
        /// </summary>
        public RecentChatViewModel()
        {
            // Default the header avatar to the partner shown in the conversation
            // page (Danielle Schneider). This keeps the value stable even if the
            // underlying ChatItems collection is later re-seeded.
            this.ActiveChatImage = App.ImageServerPath + "ProfileImage3.png";

            this.ChatItems = new ObservableCollection<ChatItem>
            {
                new ChatItem
                {
                    ImagePath = "ProfileImage2.png",
                    SenderName = "Alice Russell",
                    MessageType = "Text",
                    Message = "https://app.syncfusion",
                    Time = "12:03 pm",
                    AvailableStatus = "Not available",
                    NotificationType = "New",
                    IsUnread = true
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage3.png",
                    SenderName = "Danielle Schneider",
                    MessageType = "Audio",
                    Time = "12:03",
                    AvailableStatus = "Available",
                    NotificationType = "Viewed",
                    IsUnread = true
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage4.png",
                    SenderName = "Jessica Park",
                    MessageType = "Text",
                    AvailableStatus = "Not available",
                    Message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                    Time = "12:03",
                    NotificationType = "New",
                    IsUnread = true
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage5.png",
                    SenderName = "Julia Grant",
                    MessageType = "Video",
                    AvailableStatus = "Available",
                    Time = "Yesterday",
                    NotificationType = "Received"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage6.png",
                    SenderName = "Kyle Greene",
                    MessageType = "Contact",
                    AvailableStatus = "Not available",
                    Message = "Jhone Deo Sync",
                    Time = "Yesterday",
                    NotificationType = "Viewed"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage7.png",
                    SenderName = "Danielle Booker",
                    MessageType = "Text",
                    Message = "Val Geisier is a writer who",
                    Time = "12/12/2025",
                    AvailableStatus = "Available",
                    NotificationType = "Received"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage8.png",
                    SenderName = "Jazmine Simmons",
                    MessageType = "Text",
                    Message = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                    AvailableStatus = "Available",
                    Time = "12/8/2025",
                    NotificationType = "Sent"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage9.png",
                    SenderName = "Ira Membrit",
                    MessageType = "Photo",
                    Time = "8/8/2025",
                    AvailableStatus = "Available",
                    NotificationType = "Viewed"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage10.png",
                    SenderName = "Serina Willams",
                    MessageType = "Text",
                    Message = "A customer who bought your",
                    Time = "10/6/2025",
                    AvailableStatus = "Not available",
                    NotificationType = "Sent"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage11.png",
                    SenderName = "Alise Valasquez",
                    MessageType = "Text",
                    AvailableStatus = "Not available",
                    Message = "Syncfusion components help you deliver applications with great user experiences across iOS, Android, and Universal Windows Platform from a single code base.",
                    Time = "2/5/2018",
                    NotificationType = "New"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage12.png",
                    SenderName = "Allie Bellew",
                    MessageType = "Audio",
                    AvailableStatus = "Available",
                    Time = "24/4/2018",
                    NotificationType = "Viewed"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage13.png",
                    SenderName = "Navya Sharma",
                    MessageType = "Text",
                    AvailableStatus = "Not available",
                    Message = "https://www.syncfusion.com",
                    Time = "10/4/2018",
                    NotificationType = "New"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage14.png",
                    SenderName = "Carly Ling",
                    MessageType = "Video",
                    AvailableStatus = "Available",
                    Time = "22/3/2018",
                    NotificationType = "Received"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage15.png",
                    SenderName = "Diayana Sebastine",
                    MessageType = "Contact",
                    AvailableStatus = "Not available",
                    Message = "Kishore Nisanth",
                    Time = "15/3/2018",
                    NotificationType = "Viewed"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage16.png",
                    SenderName = "Marc Sherry",
                    MessageType = "Text",
                    Message = "Val Geisier is a writer who",
                    Time = "12/3/2018",
                    AvailableStatus = "Available",
                    NotificationType = "Sent"
                },
                new ChatItem
                {
                    ImagePath = "ProfileImage17.png",
                    SenderName = "Dona Merina",
                    MessageType = "Text",
                    AvailableStatus = "Not available",
                    Message = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                    Time = "3/2/2018",
                    NotificationType = "Sent"
                }
            };
        }
    }
}
