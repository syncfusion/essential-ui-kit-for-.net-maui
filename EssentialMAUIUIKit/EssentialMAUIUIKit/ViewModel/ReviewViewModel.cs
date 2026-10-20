using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EssentialMAUIUIKit
{
    public class ReviewViewModel : INotifyPropertyChanged
    {
        public ReviewInfo ReviewInfo { get; set; }

        private string productImageUrl = string.Empty;
        public string ProductImageUrl
        {
            get => productImageUrl;
            set
            {
                if (productImageUrl != value)
                {
                    productImageUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        private string productName = "Full-Length Skirt";
        public string ProductName
        {
            get => productName;
            set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Constructor
        public ReviewViewModel()
        {
            this.ReviewInfo = new ReviewInfo();
            this.ProductImageUrl = App.ImageServerPath + "Image1.png";
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ReviewInfo
    {
        public ReviewInfo()
        {
            this.Title = string.Empty;
            this.Review = string.Empty;
        }

        [Display(Name = "Title (Optional)")]
        public string Title { get; set; }

        [Display(Name = "Leave us a message...")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Enter your review")]
        public string Review { get; set; }
    }
}
