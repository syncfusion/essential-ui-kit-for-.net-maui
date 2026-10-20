namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Represents a single picture entry shown in the media grid on the social profile screens.
    /// </summary>
    public class Picture
    {
        private string? imagePath;

        public string? ImagePath
        {
            get { return string.IsNullOrWhiteSpace(imagePath) ? null : App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }
    }
}
