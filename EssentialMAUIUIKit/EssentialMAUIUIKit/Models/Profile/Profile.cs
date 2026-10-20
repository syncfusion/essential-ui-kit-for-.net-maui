namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Represents the full profile information displayed on the social profile screens.
    /// Image properties prepend the application image server path automatically so that
    /// the consuming XAML can bind directly to them.
    /// </summary>
    public class Profile
    {
        private string? headerImagePath;
        private string? profileImage;
        private string? backgroundImage;

        public string HeaderImagePath
        {
            get { return App.ImageServerPath + headerImagePath; }
            set { headerImagePath = value; }
        }

        public string ProfileImage
        {
            get { return App.ImageServerPath + profileImage; }
            set { profileImage = value; }
        }

        public string BackgroundImage
        {
            get { return App.ImageServerPath + backgroundImage; }
            set { backgroundImage = value; }
        }

        public string? ProfileName { get; set; }
        public string? Designation { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? About { get; set; }
        public int PostsCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public List<Interest> Interests { get; set; } = [];
        public List<Connection> Connections { get; set; } = [];
        public List<Picture> Pictures { get; set; } = [];
    }
}
