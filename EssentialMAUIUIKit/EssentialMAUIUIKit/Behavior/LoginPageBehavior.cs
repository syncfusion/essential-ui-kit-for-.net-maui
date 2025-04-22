using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class LoginPageBehavior : Behavior<LoginPage>
    {
        /// <summary>
        /// Holds the data form object.
        /// </summary>
        private SfDataForm? logInForm;

        /// <summary>
        /// Holds the save button instance.
        /// </summary>
        private SfButton? saveButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            LoginPage? loginPage = bindable as LoginPage;
            if (loginPage == null)
            {
                return;
            }

            this.logInForm = (SfDataForm)loginPage.Content.FindByName("logInForm");
            this.saveButton = (SfButton)loginPage.Content.FindByName("saveButton");
            if (this.saveButton != null)
            {
                this.saveButton.Clicked += OnSaveButtonClicked;
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            LoginPage? loginPage = bindable as LoginPage;
            if (loginPage == null)
            {
                return;
            }

            this.logInForm = (SfDataForm?)loginPage.Content.FindByName("logInForm");
            this.saveButton = (SfButton?)loginPage.Content.FindByName("saveButton");
            if (this.saveButton != null)
            {
                this.saveButton.Clicked -= OnSaveButtonClicked;
            }
        }

        /// <summary>
        /// Invokes on save button click.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            this.logInForm?.Validate();
        }
    }
}
