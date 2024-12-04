using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.ContactUs;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class ContactUsBehavior : Behavior<ContactUsPage>
    {
#if ANDROID || IOS
        /// <summary>
        /// The data form
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The submit button
        /// </summary>
        private SfButton? submitButton;
#else
        /// <summary>
        /// The data form
        /// </summary>
        private SfDataForm? dataFormDesktop;

        /// <summary>
        /// The submit button
        /// </summary>
        private SfButton? submitButtonDesktop;
#endif

        protected override void OnAttachedTo(ContactUsPage bindable)
        {
            base.OnAttachedTo(bindable);
            ContactUsPage? contactUsPage = bindable as ContactUsPage;
            if (contactUsPage == null)
            {
                return;
            }

#if ANDROID || IOS
            this.dataForm = (SfDataForm)contactUsPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)contactUsPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked += OnAddButtonClicked;
            }
#else
            this.dataFormDesktop = (SfDataForm)contactUsPage.Content.FindByName("dataFormDesktop");
            if (this.dataFormDesktop != null)
            {
                dataFormDesktop.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButtonDesktop = (SfButton)contactUsPage.Content.FindByName("submitButtonDesktop");
            if (this.submitButtonDesktop != null)
            {
                this.submitButtonDesktop.Clicked += OnAddButtonClicked;
            }
#endif
        }

        protected override void OnDetachingFrom(ContactUsPage bindable)
        {
            base.OnDetachingFrom(bindable);
            ContactUsPage? contactUsPage = bindable as ContactUsPage;
            if (contactUsPage == null)
            {
                return;
            }

#if ANDROID || IOS
            this.dataForm = (SfDataForm)contactUsPage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)contactUsPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked -= OnAddButtonClicked;
            }
#else
            this.dataFormDesktop = (SfDataForm)contactUsPage.Content.FindByName("dataFormDesktop");
            if (this.dataFormDesktop != null)
            {
                dataFormDesktop.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButtonDesktop = (SfButton)contactUsPage.Content.FindByName("submitButtonDesktop");
            if (this.submitButtonDesktop != null)
            {
                this.submitButtonDesktop.Clicked -= OnAddButtonClicked;
            }
#endif
        }

        private void OnAddButtonClicked(object? sender, EventArgs e)
        {
#if ANDROID || IOS
            this.dataForm?.Validate();
#else
            this.dataFormDesktop?.Validate();
#endif
        }
    }
}
