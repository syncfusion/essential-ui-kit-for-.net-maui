using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class BusinessRegistrationFormBehavior : Behavior<BusinessRegistrationForm>
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
            BusinessRegistrationForm? businessRegistrationForm = bindable as BusinessRegistrationForm;
            if (businessRegistrationForm == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)businessRegistrationForm.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
                this.dataForm.RegisterEditor("BusinessType", DataFormEditorType.ComboBox);
                this.dataForm.RegisterEditor("BusinessCountry", DataFormEditorType.ComboBox);
                this.dataForm.RegisterEditor("BusinessState", DataFormEditorType.ComboBox);
            }

            this.submitButton = (SfButton)businessRegistrationForm.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked += OnSubmitButtonClicked;
            }

        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            BusinessRegistrationForm? businessRegistrationForm = bindable as BusinessRegistrationForm;
            if (businessRegistrationForm == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)businessRegistrationForm.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)businessRegistrationForm.Content.FindByName("submitButton");
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
