using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using Syncfusion.Maui.Toolkit.Buttons;
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

        /// <summary>
        /// Holds the banner page instance.
        /// </summary>
        private Border? bannerPage;

        /// <summary>
        /// Holds the form container instance.
        /// </summary>
        private Border? formsPage;

        /// <summary>
        /// Holds the root grid instance.
        /// </summary>
        private Grid? mainGrid;

        /// <summary>
        /// Minimum width required to display the banner.
        /// </summary>
        private const double BannerVisibleThreshold = 900d;

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

            this.mainGrid = (Grid)resetPasswordPage.Content.FindByName("mainGrid");
            this.bannerPage = (Border)resetPasswordPage.Content.FindByName("bannerPage");
            this.formsPage = (Border)resetPasswordPage.Content.FindByName("formsPage");

            resetPasswordPage.SizeChanged += OnResetPasswordPageSizeChanged;
            UpdateResponsiveLayout(resetPasswordPage.Width);

            this.submitButton = (SfButton)resetPasswordPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked += OnSubmitButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem += LogInForm_GenerateDataFormItem;
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

            resetPasswordPage.SizeChanged -= OnResetPasswordPageSizeChanged;

            if (this.submitButton != null)
            {
                this.submitButton.Clicked -= OnSubmitButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= LogInForm_GenerateDataFormItem;
            }

            this.dataForm = null;
            this.submitButton = null;
            this.mainGrid = null;
            this.bannerPage = null;
            this.formsPage = null;
        }

        private void OnSubmitButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)
            {
                this.dataForm.Validate();
            }
        }

        /// <summary>
        /// Updates the layout when the page size changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnResetPasswordPageSizeChanged(object? sender, EventArgs e)
        {
            if (sender is ResetPasswordPage resetPasswordPage)
            {
                UpdateResponsiveLayout(resetPasswordPage.Width);
            }
        }

        /// <summary>
        /// Shows or hides the banner based on available width.
        /// </summary>
        /// <param name="width">The current page width.</param>
        private void UpdateResponsiveLayout(double width)
        {
            if (this.mainGrid == null || this.bannerPage == null || this.formsPage == null || width <= 0)
            {
                return;
            }

            var showBanner = DeviceInfo.Idiom == DeviceIdiom.Desktop && width >= BannerVisibleThreshold;

            this.bannerPage.IsVisible = showBanner;
            Grid.SetColumn(this.formsPage, showBanner ? 1 : 0);
            this.mainGrid.ColumnDefinitions.Clear();

            if (showBanner)
            {
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            }
            else
            {
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }
        }

        private void LogInForm_GenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e?.DataFormItem == null)
            {
                return;
            }

            string? fieldName = e.DataFormItem.FieldName;

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return;
            }

            if (e.DataFormItem is DataFormPasswordItem passwordItem)
            {
                passwordItem.EditorHeight = 56;
            }

            if (fieldName == "NewPassword")
            {
                e.DataFormItem.PlaceholderText = "New Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
            }
            else if (fieldName == "ConfirmPassword")
            {
                e.DataFormItem.PlaceholderText = "Confirm New Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
            }
        }
    }
}
