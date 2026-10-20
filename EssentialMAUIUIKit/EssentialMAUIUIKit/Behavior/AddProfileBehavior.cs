using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Forms;
using Syncfusion.Maui.Toolkit.Buttons;
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

        /// <summary>
        /// Holds the banner page instance.
        /// </summary>
        private Border? bannerPage;

        /// <summary>
        /// Holds the form container instance.
        /// </summary>
        private Border? profilePage;

        /// <summary>
        /// Holds the root grid instance.
        /// </summary>
        private Grid? mainGrid;

        /// <summary>
        /// Minimum width required to display the banner.
        /// </summary>
        private const double BannerVisibleThreshold = 900d;

        protected override void OnAttachedTo(AddProfilePage bindable)
        {
            base.OnAttachedTo(bindable);
            AddProfilePage? addProfilePage = bindable as AddProfilePage;
            if (addProfilePage == null)
            {
                return;
            }

            this.dataForm = (SfDataForm)addProfilePage.Content.FindByName("dataForm");
            this.mainGrid = (Grid)addProfilePage.Content.FindByName("mainGrid");
            this.bannerPage = (Border)addProfilePage.Content.FindByName("bannerPage");
            this.profilePage = (Border)addProfilePage.Content.FindByName("profilePage");
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

            addProfilePage.SizeChanged += AddProfilePage_SizeChanged;
            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem += DataForm_GenerateDataFormItem;
            }
        }

        private void DataForm_GenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
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
                textItem.EditorHeight = 50;
                if (e.DataFormItem.FieldName == "PhoneNumber")
                {
                    textItem.Keyboard = Keyboard.Numeric;
                }
            }

            if (fieldName == "Name")
            {
                e.DataFormItem.PlaceholderText = "First Name";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE70E", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor= Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE70E", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor = Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
            else if (fieldName == "Email")
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
            else if (fieldName == "PhoneNumber")
            {
                e.DataFormItem.PlaceholderText = "PhoneNumber";
                e.DataFormItem.LabelText = "";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE71C", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor= Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE71C", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, TextColor = Colors.Black, WidthRequest = 18, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
            else if (fieldName == "Groups")
            {
                e.DataFormItem.PlaceholderText = "Groups";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE714", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, WidthRequest = 18, TextColor= Colors.Black, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE714", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, WidthRequest = 18, TextColor = Colors.Black, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
            else if (fieldName == "Company")
            {
                e.DataFormItem.PlaceholderText = "Company";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
                e.DataFormItem.LeadingView = new Label { Text = "\uE706", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, WidthRequest = 18, TextColor= Colors.Black, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView = new Label { Text = "\uE706", FontSize = 18, FontFamily = "FontIcons", HeightRequest = 18, WidthRequest = 18, TextColor = Colors.Black, VerticalTextAlignment = TextAlignment.End, Margin = new Thickness(0, 8, 0, 5) };
#endif
            }
            else if (fieldName == "State")
            {
                e.DataFormItem.PlaceholderText = "State";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.EditorHeight = 50;
            }
            else if (fieldName == "City")
            {
                e.DataFormItem.PlaceholderText = "City";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.EditorHeight = 50;
            }
        }

        private void AddProfilePage_SizeChanged(object? sender, EventArgs e)
        {
            if (sender is AddProfilePage addProfilePage)
            {
                UpdateResponsiveLayout(addProfilePage.Width);
            }
        }

        /// <summary>
        /// Shows or hides the banner based on available width.
        /// </summary>
        /// <param name="width">The current page width.</param>
        private void UpdateResponsiveLayout(double width)
        {
            if (this.mainGrid == null || this.bannerPage == null || this.profilePage == null || width <= 0)
            {
                return;
            }

            var showBanner = DeviceInfo.Idiom == DeviceIdiom.Desktop && width >= BannerVisibleThreshold;

            this.bannerPage.IsVisible = showBanner;
            Grid.SetColumn(this.profilePage, showBanner ? 1 : 0);
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

            addProfilePage.SizeChanged -= AddProfilePage_SizeChanged;
        }

        private void OnAddButtonClicked(object? sender, EventArgs e)
        {
            this.dataForm?.Validate();
        }
    }
}
