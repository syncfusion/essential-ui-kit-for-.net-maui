using Syncfusion.Maui.DataForm;
using System.ComponentModel.DataAnnotations;

namespace EssentialMAUIUIKit
{
    class CardPaymentViewModel
    {
        public CardPaymentInfo ContactsInfo { get; set; }

        public List<CardPaymentInfo> CardDetails { get; set; }

        #region Constructor
        public CardPaymentViewModel()
        {
            this.ContactsInfo = new CardPaymentInfo();
            this.CardDetails = new List<CardPaymentInfo>()
            {
                new CardPaymentInfo()
                {
                    CardNumber = "XXXX XXXX XXXX 3456",
                    ExpiryDate = DateTime.Now.AddYears(5),
                    CVV = "123",
                    CardHolderName = "John Doe"
                },
                new CardPaymentInfo()
                {
                    CardNumber = "XXXX XXXX XXXX 4567",
                    ExpiryDate = DateTime.Now.AddYears(3),
                    CVV = "456",
                    CardHolderName = "John Doe"
                }
            };
        }

        #endregion
    }

    public class CardPaymentInfo
    {
        public CardPaymentInfo()
        {
            this.CardNumber = string.Empty;
            this.ExpiryDate = DateTime.Now;
            this.CVV = string.Empty;
            this.CardHolderName = string.Empty;
        }

        [Display(Name = "Card Number")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Card number should not be empty")]
        public string CardNumber { get; set; }

        [Display(Name = "Expiration Date")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Expiry required")]
        public DateTime ExpiryDate { get; set; }

        [Display(Name = "CVV")]
        [DataFormDisplayOptions(ColumnSpan = 1)]
        [Required(ErrorMessage = "CVV required")]
        public string CVV { get; set; }

        [Display(Name = "Card Holder Name")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Card holder name required")]
        public string CardHolderName { get; set; }
    }
}
