using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class SignUpPageBehavior : Behavior<SignupPage>
    {
        /// <summary>
        /// The data form.
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The register button.
        /// </summary>
        private SfButton? registerButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            SignupPage? signupPage = bindable as SignupPage;
            if (signupPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)signupPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.registerButton = (SfButton)signupPage.Content.FindByName("registerButton");
            if (this.registerButton != null)
            {
                this.registerButton.Clicked += OnRegisterButtonClicked;
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            SignupPage? signupPage = bindable as SignupPage;
            if (signupPage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)signupPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.registerButton = (SfButton)signupPage.Content.FindByName("registerButton");
            if (this.registerButton != null)
            {
                this.registerButton.Clicked -= OnRegisterButtonClicked;
            }
        }

        private void OnRegisterButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }
    }
}
