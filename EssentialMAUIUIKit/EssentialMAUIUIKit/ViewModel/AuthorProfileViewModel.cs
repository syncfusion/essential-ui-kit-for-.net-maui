namespace EssentialMAUIUIKit
{
    public class AuthorProfileViewModel
    {
        private string? profileImage;

        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        public string? ProfileName { get; set; }

        public string? Email { get; set; }

        public AuthorProfileViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            ProfileImage = "ProfileImage1.png";
            ProfileName = "John Doe";
            Email = "johndoe@gmail.com";
        }

    }
}
