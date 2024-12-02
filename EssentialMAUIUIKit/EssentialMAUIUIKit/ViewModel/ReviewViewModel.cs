using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    public class ReviewViewModel
    {
        public ReviewInfo ReviewInfo { get; set; }

        #region Constructor
        public ReviewViewModel()
        {
            this.ReviewInfo = new ReviewInfo();
        }

        #endregion
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

        [Display(Name = "Describe your review")]
        [Required(ErrorMessage = "Enter your review")]
        public string Review { get; set; }
    }
}
