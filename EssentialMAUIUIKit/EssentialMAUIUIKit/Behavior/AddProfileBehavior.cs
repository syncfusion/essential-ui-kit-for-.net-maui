using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class AddProfileBehavior : Behavior<AddProfilePage>
    {
        /// <summary>
        /// The data form
        /// </summary>
        private SfDataForm? dataForm;

        /// <summary>
        /// The add button
        /// </summary>
        private SfButton? addButton;

        protected override void OnAttachedTo(AddProfilePage bindable)
        {
            base.OnAttachedTo(bindable);
            AddProfilePage? addProfilePage = bindable as AddProfilePage;
            if (addProfilePage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)addProfilePage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
                this.dataForm.RegisterEditor("State", DataFormEditorType.ComboBox);
            }

            this.addButton = (SfButton)addProfilePage.Content.FindByName("addButton");
            if (this.addButton != null)
            {
                this.addButton.Clicked += OnAddButtonClicked;
            }
        }

        protected override void OnDetachingFrom(AddProfilePage bindable)
        {
            base.OnDetachingFrom(bindable);
            AddProfilePage? addProfilePage = bindable as AddProfilePage;
            if (addProfilePage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)addProfilePage.Content.FindByName("dataForm");
            if (this.dataForm != null)
            {
                dataForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.addButton = (SfButton)addProfilePage.Content.FindByName("addButton");
            if (this.addButton != null)
            {
                this.addButton.Clicked -= OnAddButtonClicked;
            }
        }

        private void OnAddButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }
    }
}
