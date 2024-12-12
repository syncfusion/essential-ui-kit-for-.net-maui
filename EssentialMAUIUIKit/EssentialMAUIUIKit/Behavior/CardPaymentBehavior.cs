using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class CardPaymentBehavior : Behavior<CardPaymentPage>
    {
        /// <summary>
        /// The data form.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The add button.
        /// </summary>
        private SfButton? addButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            CardPaymentPage? cardPaymentPage = bindable as CardPaymentPage;
            if (cardPaymentPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)cardPaymentPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
                this.dataForm.RegisterEditor("ExpiryDate", DataFormEditorType.Date);
            }

            this.addButton = (SfButton)cardPaymentPage.Content.FindByName("addButton");
            if (this.addButton != null)
            {
                this.addButton.Clicked += OnAddButtonClicked;
            }
        }

        private void OnAddButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            CardPaymentPage? cardPaymentPage = bindable as CardPaymentPage;
            if (cardPaymentPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)cardPaymentPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.addButton = (SfButton)cardPaymentPage.Content.FindByName("addButton");
            if (this.addButton != null)
            {
                this.addButton.Clicked -= OnAddButtonClicked;
            }
        }
    }
}
