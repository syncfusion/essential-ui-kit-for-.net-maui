using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit.Views.Forms
{
    public partial class TabbedLogin : ContentView
    {
        public TabbedLogin()
        {
            InitializeComponent();
            this.logInForm.GenerateDataFormItem += LogInForm_GenerateDataFormItem;
            this.signupForm.GenerateDataFormItem += DataForm_GenerateDataFormItem;
        }
        private void LogInForm_GenerateDataFormItem(
            object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem is DataFormTextItem textItem)
            {
                textItem.EditorHeight = 56;
            }
            else if (e.DataFormItem is DataFormPasswordItem passwordItem)
            {
                passwordItem.EditorHeight = 56;
            }

            if (e.DataFormItem.FieldName == "Email")
            {
                e.DataFormItem.PlaceholderText = "Email";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE725",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE725",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
            else if (e.DataFormItem.FieldName == "Password")
            {
                e.DataFormItem.PlaceholderText = "Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "UIKitIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "UIKitIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
        }

        private void DataForm_GenerateDataFormItem(
            object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem is DataFormTextItem textItem)
            {
                textItem.EditorHeight = 56;
            }
            else if (e.DataFormItem is DataFormPasswordItem passwordItem)
            {
                passwordItem.EditorHeight = 56;
            }

            if (e.DataFormItem.FieldName == "Name")
            {
                e.DataFormItem.PlaceholderText = "Name";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE70E",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE70E",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
            else if (e.DataFormItem.FieldName == "Email")
            {
                e.DataFormItem.PlaceholderText = "Email";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE725",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE725",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
            else if (e.DataFormItem.FieldName == "ConfirmPassword")
            {
                e.DataFormItem.PlaceholderText = "Confirm Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "FontIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "UIKitIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
            else if (e.DataFormItem.FieldName == "Password")
            {
                e.DataFormItem.PlaceholderText = "Password";
                e.DataFormItem.PlaceholderColor = Color.FromArgb("#ADAAAC");
                e.DataFormItem.LabelText = "";
                e.DataFormItem.LeadingViewPosition = TextInputLayoutViewPosition.Inside;
#if MACCATALYST || IOS
        e.DataFormItem.LeadingView =
            new Label { Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "UIKitIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 10) };
#else
                e.DataFormItem.LeadingView =
                    new Label
                    {
                        Text = "\uE71C",
                        FontSize = 18,
                        FontFamily = "UIKitIcons",
                        HeightRequest = 18,
                        WidthRequest = 18,
                        VerticalTextAlignment = TextAlignment.End,
                        Margin = new Thickness(0, 8, 0, 5)
                    };
#endif
            }
        }
    }

}