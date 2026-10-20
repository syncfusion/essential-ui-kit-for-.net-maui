using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using Syncfusion.Maui.Toolkit.Buttons;
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

            this.mainGrid = (Grid)forgotPasswordPage.Content.FindByName("mainGrid");
            this.bannerPage = (Border)forgotPasswordPage.Content.FindByName("bannerPage");
            this.formsPage = (Border)forgotPasswordPage.Content.FindByName("formsPage");

            forgotPasswordPage.SizeChanged += OnForgotPasswordPageSizeChanged;
            UpdateResponsiveLayout(forgotPasswordPage.Width);

            this.sendButton = (SfButton)forgotPasswordPage.Content.FindByName("sendButton");
            if (this.sendButton != null)
            {
                this.sendButton.Clicked += OnSendButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem += DataForm_GenerateDataFormItem;
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

            forgotPasswordPage.SizeChanged -= OnForgotPasswordPageSizeChanged;

            if (this.sendButton != null)
            {
                this.sendButton.Clicked -= OnSendButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= DataForm_GenerateDataFormItem;
            }

            this.dataForm = null;
            this.sendButton = null;
            this.mainGrid = null;
            this.bannerPage = null;
            this.formsPage = null;
        }

        private void OnSendButtonClicked(object? sender, EventArgs e)
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
        private void OnForgotPasswordPageSizeChanged(object? sender, EventArgs e)
        {
            if (sender is ForgotPasswordPage forgotPasswordPage)
            {
                UpdateResponsiveLayout(forgotPasswordPage.Width);
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

        private void DataForm_GenerateDataFormItem(object? sender, Syncfusion.Maui.DataForm.GenerateDataFormItemEventArgs e)
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

            if (e.DataFormItem is DataFormTextItem textItem)
            {
                textItem.EditorHeight = 56;
            }

            if (fieldName == "Email")
            {
                e.DataFormItem.PlaceholderText = "Email";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE725", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor= Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE725", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor = Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
        }
    }
}
