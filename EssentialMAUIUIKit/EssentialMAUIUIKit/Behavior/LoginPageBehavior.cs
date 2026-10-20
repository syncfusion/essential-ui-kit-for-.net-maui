using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
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
            LoginPage? loginPage = bindable as LoginPage;
            if (loginPage == null)
            {
                return;
            }

            this.logInForm = (SfDataForm)loginPage.Content.FindByName("logInForm");
            if (this.logInForm != null)
            {
                this.logInForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.mainGrid = (Grid)loginPage.Content.FindByName("mainGrid");
            this.bannerPage = (Border)loginPage.Content.FindByName("bannerPage");
            this.formsPage = (Border)loginPage.Content.FindByName("formsPage");

            loginPage.SizeChanged += OnLoginPageSizeChanged;
            UpdateResponsiveLayout(loginPage.Width);

            this.saveButton = (SfButton)loginPage.Content.FindByName("saveButton");
            if (this.saveButton != null)
            {
                this.saveButton.Clicked += OnSaveButtonClicked;
            }

            if (this.logInForm != null)
            {
                this.logInForm.GenerateDataFormItem += LogInForm_GenerateDataFormItem;
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

            loginPage.SizeChanged -= OnLoginPageSizeChanged;

            if (this.saveButton != null)
            {
                this.saveButton.Clicked -= OnSaveButtonClicked;
            }

            if (this.logInForm != null)
            {
                this.logInForm.GenerateDataFormItem -= LogInForm_GenerateDataFormItem;
            }

            this.logInForm = null;
            this.saveButton = null;
            this.mainGrid = null;
            this.bannerPage = null;
            this.formsPage = null;
        }

        /// <summary>
        /// Invokes on save button click.
        /// </summary>
        /// <param name="sender">The button.</param>
        /// <param name="e">The event arguments.</param>
        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            if (this.logInForm != null)
            {
                this.logInForm.Validate();
            }
        }

        /// <summary>
        /// Updates the layout when the page size changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void OnLoginPageSizeChanged(object? sender, EventArgs e)
        {
            if (sender is LoginPage loginPage)
            {
                UpdateResponsiveLayout(loginPage.Width);
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

            if (e.DataFormItem is DataFormTextItem textItem)
            {
                textItem.EditorHeight = 56;
            }
            else if (e.DataFormItem is DataFormPasswordItem passwordItem)
            {
                passwordItem.EditorHeight = 56;
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
            else if (fieldName == "Password")
            {
                e.DataFormItem.PlaceholderText = "Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE71C", FontSize = 18, FontFamily = "UIKitIcons", HeightRequest = 18, TextColor= Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE71C", FontSize = 18, FontFamily = "UIKitIcons", HeightRequest = 18, TextColor = Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
        }
    }
}
