using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Transaction
{
    /// <summary>
    /// Selects a DataTemplate for items in the checkout payment list.
    /// Saved cards (those that expose a <see cref="PaymentMode.CardNumber"/>)
    /// are rendered with the rich card template; all other payment modes
    /// use a simpler common template.
    /// </summary>
    public class PaymentTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the template used for saved card payment modes.
        /// </summary>
        public DataTemplate? CardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template used for the remaining payment modes
        /// (Net Banking, UPI, Cash on Delivery, etc.).
        /// </summary>
        public DataTemplate? CommonTemplate { get; set; }

        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            return item is PaymentMode payment && !string.IsNullOrEmpty(payment.CardNumber)
                ? this.CardTemplate
                : this.CommonTemplate;
        }
    }
}
