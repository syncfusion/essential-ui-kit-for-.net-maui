using System.Collections.ObjectModel;

namespace EssentialMAUIUIKit
{
   public class EventDetailViewModel
    {
        private string? headerImagePath;
        public ObservableCollection<EssentialMAUIUIKit.Models.UserProfile>? Connections { get; set; }
        public string? HeaderImagePath
        {
            get
            {
                return App.ImageServerPath + this.headerImagePath;
            }
            set
            {
                this.headerImagePath = value;
            }
        }

        public EventDetailViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            HeaderImagePath = "Album2.png";
            var images = new List<string>() { "ProfileImage10.png", "ProfileImage11.png", "ProfileImage12.png", "ProfileImage13.png", "ProfileImage14.png", "ProfileImage15.png" };
            Connections = new ObservableCollection<EssentialMAUIUIKit.Models.UserProfile>();
            for (int i = 0; i < images.Count; i++)
            {
                Connections.Add(new EssentialMAUIUIKit.Models.UserProfile { ImagePath = images[i] });
            }
        }
    }
}
