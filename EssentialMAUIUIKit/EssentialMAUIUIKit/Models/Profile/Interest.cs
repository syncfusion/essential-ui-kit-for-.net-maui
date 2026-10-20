namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Represents a single interest entry shown on the social profile screens.
    /// </summary>
    public class Interest
    {
        private string? imagePath;

        public string? Name { get; set; }

        public string? ImagePath
        {
            get { return string.IsNullOrWhiteSpace(imagePath) ? null : App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }
    }
}
