namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Represents a single connection entry shown in the connections list on the social profile screens.
    /// </summary>
    public class Connection
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
