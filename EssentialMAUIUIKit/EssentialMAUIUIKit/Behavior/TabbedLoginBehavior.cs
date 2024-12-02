using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class TabbedLoginBehavior : Behavior<TabbedLogin>
    {
        /// <summary>
        /// The login form.
        /// </summary>
        private SfDataForm? logInForm;

        /// <summary>
        /// The signup form.
        /// </summary>
        private SfDataForm? signupForm;

        /// <summary>
        /// The login button.
        /// </summary>
        private SfButton? loginButton;

        /// <summary>
        /// The signup button.
        /// </summary>
        private SfButton? signupButton;

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            TabbedLogin? tabbedLogin = bindable as TabbedLogin;
            if (tabbedLogin == null)
            {
                return;
            }

            this.logInForm = (SfDataForm)tabbedLogin.Content.FindByName("logInForm");
            if (this.logInForm != null)
            {
                logInForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.signupForm = (SfDataForm)tabbedLogin.Content.FindByName("signupForm");
            if (this.signupForm != null)
            {
                signupForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.loginButton = (SfButton)tabbedLogin.Content.FindByName("loginButton");
            if (this.loginButton != null)
            {
                this.loginButton.Clicked += OnLoginButtonClicked;
            }

            this.signupButton = (SfButton)tabbedLogin.Content.FindByName("signupButton");
            if (this.signupButton != null)
            {
                this.signupButton.Clicked += OnSignUpButtonClicked;
            }
        }

        private void OnSignUpButtonClicked(object? sender, EventArgs e)
        {
            this.signupForm?.Validate();
        }

        private void OnLoginButtonClicked(object? sender, EventArgs e)
        {
            this.logInForm?.Validate();
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            TabbedLogin? tabbedLogin = bindable as TabbedLogin;
            if (tabbedLogin == null)
            {
                return;
            }

            this.logInForm = (SfDataForm)tabbedLogin.Content.FindByName("logInForm");
            if (this.logInForm != null)
            {
                logInForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.signupForm = (SfDataForm)tabbedLogin.Content.FindByName("signupForm");
            if (this.signupForm != null)
            {
                signupForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.loginButton = (SfButton)tabbedLogin.Content.FindByName("loginButton");
            if (this.loginButton != null)
            {
                this.loginButton.Clicked -= OnLoginButtonClicked;
            }

            this.signupButton = (SfButton)tabbedLogin.Content.FindByName("signupButton");
            if (this.signupButton != null)
            {
                this.signupButton.Clicked -= OnSignUpButtonClicked;
            }
        }
    }
}
