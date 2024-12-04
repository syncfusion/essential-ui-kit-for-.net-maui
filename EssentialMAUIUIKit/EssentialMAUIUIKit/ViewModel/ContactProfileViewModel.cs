using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;

namespace EssentialMAUIUIKit
{
    public class ContactProfileViewModel
    {
        private string? profileImage;
        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        public ProfileData? ProfileImages { get; set; }

        public ContactProfileViewModel()
        {
            PopulateData();
        }

        public void PopulateData()
        {
            ProfileImage = "ContactProfileImage.png";
            var images = new List<string>() { "ProfileImage10.png", "ProfileImage11.png", "ProfileImage12.png", "ProfileImage13.png", "ProfileImage14.png", "ProfileImage15.png" };
            ProfileImages = new ProfileData();
            ProfileImages.Profiles = new ObservableCollection<UserProfile>();
            for (int i = 0; i < images.Count; i++)
            {
                ProfileImages.Profiles.Add(new UserProfile { ImagePath = images[i] });
            }
        }
    }

    public class ProfileData
    {
        public ObservableCollection<UserProfile>? Profiles { get; set; }
    }

}
