namespace EssentialMAUIUIKit
{
    public class ChatMessageViewModel
    {
        public UserProfileModel UserProfile { get; set; }
        public ChatMessageViewModel()
        {
            UserProfile = new UserProfileModel
            {
                ProfileImage = "ProfileImage1.png",
                ProfileName = "Alex Russell",
                Image = "ProfileImage3.png",
                ChatMessageInfo = new List<ChatMessageInfoModel>
            {
                new ChatMessageInfoModel
                {
                    IsReceived = true,
                    Message = "Hi, can you tell me the specifications of the Dell Inspiron 5370 laptop?",
                    Time = "5:30 AM"
                },
                new ChatMessageInfoModel
                {
                    Message = "* Processor: Intel Core i5-8250U processor \n* Display: 13.3-inch FHD (1920 x 1080) LED display \n* Memory: 8GB DDR RAM with Intel UHD 620 Graphics \n* Battery: Lithium battery",
                    Time = "5:35 AM"
                },
                new ChatMessageInfoModel
                {
                    ImagePath = "Electronics.png",
                    Time = "6:30 AM"
                },
                new ChatMessageInfoModel
                {
                    IsReceived = true,
                    Message = "How much battery life does it have with wifi and without?",
                    Time = "7:30 AM"
                },
                new ChatMessageInfoModel
                {
                    Message = "Approximately 5 hours with wifi. About 7 hours without.",
                    Time = "10:30 AM"
                }
            }
            };
        }
    }

    public class ChatMessageInfoModel
    {
        private string? imagePath;
        public bool IsReceived { get; set; } // Nullable to handle missing values
        public string? Message { get; set; }
        public string? Time { get; set; }
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }
    }

    public class UserProfileModel
    {
        private string? profileImage;
        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        public string? ProfileName { get; set; }
        public string? Image { get; set; }
        public List<ChatMessageInfoModel>? ChatMessageInfo { get; set; }
    }
}
