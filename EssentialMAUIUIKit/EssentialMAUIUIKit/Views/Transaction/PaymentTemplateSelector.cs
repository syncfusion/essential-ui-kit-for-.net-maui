namespace EssentialMAUIUIKit.Views.Transaction
{
    public class PaymentTemplateSelector : DataTemplateSelector
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate? CardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with ItemTemplate.
        /// </summary>
        public DataTemplate? CommonTemplate { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// This methoid returns the DataTemplate based on selection.
        /// </summary>
        /// <param name="item">The Model</param>
        /// <param name="container">The bindable object</param>
        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            var payment = item as PaymentMode;

            if (payment != null && payment.CardNumber != null)
            {
                return this.CardTemplate;
            }
            else
            {
                return this.CommonTemplate;
            }
        }

        #endregion
    }
}
