using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class ResetPasswordBehavior : Behavior<ResetPasswordPage>
    {
        /// <summary>
        /// The data form.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The submit button.
        /// </summary>
        private SfButton? submitButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            ResetPasswordPage? resetPasswordPage = bindable as ResetPasswordPage;
            if (resetPasswordPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)resetPasswordPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)resetPasswordPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked += OnSubmitButtonClicked;
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            ResetPasswordPage? resetPasswordPage = bindable as ResetPasswordPage;

            if (resetPasswordPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)resetPasswordPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)resetPasswordPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked -= OnSubmitButtonClicked;
            }
        }

        private void OnSubmitButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }
    }
}
