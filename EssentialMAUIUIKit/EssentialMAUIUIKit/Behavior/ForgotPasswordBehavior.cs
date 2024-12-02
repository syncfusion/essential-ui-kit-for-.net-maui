using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class ForgotPasswordBehavior : Behavior<ForgotPasswordPage>
    {
        /// <summary>
        /// The data form.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The send button.
        /// </summary>
        private SfButton? sendButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            ForgotPasswordPage? forgotPasswordPage = bindable as ForgotPasswordPage;
            if (forgotPasswordPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)forgotPasswordPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.sendButton = (SfButton)forgotPasswordPage.Content.FindByName("sendButton");
            if (this.sendButton != null)
            {
                this.sendButton.Clicked += OnSendButtonClicked;
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            ForgotPasswordPage? forgotPasswordPage = bindable as ForgotPasswordPage;

            if (forgotPasswordPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)forgotPasswordPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.sendButton = (SfButton)forgotPasswordPage.Content.FindByName("sendButton");
            if (this.sendButton != null)
            {
                this.sendButton.Clicked -= OnSendButtonClicked;
            }
        }

        private void OnSendButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }
    }
}
