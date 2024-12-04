using System.Collections.ObjectModel;

namespace EssentialMAUIUIKit
{
    public class RecentChatViewModel
    {
        public ObservableCollection<ChatItem> ChatItems { get; set; }

        public RecentChatViewModel()
        {
            ChatItems = new ObservableCollection<ChatItem>
        {
            new ChatItem
            {
                ImagePath = "ProfileImage2.png",
                SenderName = "Alice Russell",
                MessageType = "Text",
                Message = "https://app.syncfusion",
                Time = "15 min",
                NotificationType = "New"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage3.png",
                SenderName = "Danielle Schneider",
                MessageType = "Audio",
                Time = "23 min",
                AvailableStatus = "Available",
                NotificationType = "Viewed"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage4.png",
                SenderName = "Jessica Park",
                MessageType = "Text",
                Message = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Time = "1 hr",
                NotificationType = "New"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage5.png",
                SenderName = "Julia Grant",
                MessageType = "Video",
                AvailableStatus = "Available",
                Time = "3 hr",
                NotificationType = "Received"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage6.png",
                SenderName = "kyle Greene",
                MessageType = "Contact",
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
                Time = "Jan 30",
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
                Time = "12/8/2018",
                NotificationType = "Sent"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage9.png",
                SenderName = "Ira Membrit",
                MessageType = "Photo",
                Message = "8/8/2018",
                AvailableStatus = "Available",
                NotificationType = "Viewed"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage10.png",
                SenderName = "Serina Willams",
                MessageType = "Text",
                Message = "A customer who bought your",
                Time = "10/6/2018",
                NotificationType = "Sent"
            },
            new ChatItem
            {
                ImagePath = "ProfileImage11.png",
                SenderName = "Alise Valasquez",
                MessageType = "Text",
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
                Message = "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old.",
                Time = "3/2/2018",
                NotificationType = "Sent"
            }
        };
        }
    }

    public class ChatItem
    {
        private string? imagePath;
        public string? ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }

        public string? SenderName { get; set; }
        public string? MessageType { get; set; }
        public string? Message { get; set; }
        public string? Time { get; set; }
        public string? NotificationType { get; set; }
        public string? AvailableStatus { get; set; }
    }

}
