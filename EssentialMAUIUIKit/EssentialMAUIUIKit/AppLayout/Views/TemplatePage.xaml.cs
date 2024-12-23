using EssentialMAUIUIKit.AppLayout.Models;
using EssentialMAUIUIKit.AppLayout.ViewModels;
using System.Reflection;

namespace EssentialMAUIUIKit.AppLayout.Views
{
    public partial class TemplatePage : ContentPage
    {
        ICollection<ResourceDictionary>? mergedDictionaries;
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatePage" /> class.
        /// </summary>
        public TemplatePage(Category selectedCategory, Template selectedTemplate)
        {
            this.InitializeComponent();
            var bindingContext = (TemplatePageViewModel)this.BindingContext;
            bindingContext.SelectedCategory = selectedCategory;
            this.chipView.ItemsSource = selectedCategory.Pages;
            Template initialPage = selectedTemplate;
            this.chipView.SelectedItem = selectedTemplate;
            var page = this.LoadPage(initialPage.PageName);
            this.CategoryTextLabel.Text = selectedCategory.Name;
            this.SampleGrid.Children.Add(page);
            if (Application.Current != null)
            {
                mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (themeSwitch == null)
                {
                    return;
                }

                if (Application.Current.UserAppTheme == AppTheme.Dark)
                {
                    this.themeSwitch.IsOn = true;
                    if (mergedDictionaries != null)
                    {
                        var theme = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        var themeToolkit = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        if (theme != null && themeToolkit != null)
                        {
                            theme.VisualTheme = Syncfusion.Maui.Themes.SfVisuals.MaterialDark;
                            themeToolkit.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialDark;
                        }
                    }
                }
                else
                {
                    this.themeSwitch.IsOn = false;
                }
            }
        }

        #endregion

        #region Methods

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            if (Application.Current != null)
            {
                if (Application.Current.UserAppTheme == AppTheme.Dark)
                {
                    if (mergedDictionaries != null)
                    {
                        var theme = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        var themeToolkit = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        if (theme != null && themeToolkit != null)
                        {
                            theme.VisualTheme = Syncfusion.Maui.Themes.SfVisuals.MaterialDark;
                            themeToolkit.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialDark;
                        }
                    }

                    this.themeSwitch.IsOn = true;
                }
                else
                {
                    if (mergedDictionaries != null)
                    {
                        var theme = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        var themeToolkit = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        if (theme != null && themeToolkit != null)
                        {
                            theme.VisualTheme = Syncfusion.Maui.Themes.SfVisuals.MaterialLight;
                            themeToolkit.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialLight;
                        }
                    }

                    this.themeSwitch.IsOn = false;
                }
            }

            this.propertyFrame.IsVisible = !this.propertyFrame.IsVisible;
            this.propertyFrameOverlay.IsVisible = !this.propertyFrameOverlay.IsVisible;
        }

        private void BackButtonPressed(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }

        private async void GotoCodeViewer(object sender, EventArgs e)
        {
            string address = "https://github.com/syncfusion/essential-ui-kit-for-.net-maui/blob/master/EssentialMAUIUIKit/EssentialMAUIUIKit/" + this.GetCodeViewerPath() + "";
            await Browser.Default.OpenAsync(address, BrowserLaunchMode.SystemPreferred);
        }

        private ContentView? LoadPage(string? pageURL)
        {
            // Get the assembly of the current app
            var assembly = typeof(App).GetTypeInfo().Assembly;

            // Get the type of the page
            var pageType = assembly.GetType($"EssentialMAUIUIKit.{pageURL}");

            // Check if the pageType is null
            if (pageType == null)
            {
                throw new Exception($"The page '{pageURL}' was not found in the assembly.");
            }

            var page = new ContentView();

            // Create an instance of the page
            return page = (ContentView?)Activator.CreateInstance(pageType);

        }

        private void chipView_ChipClicked(object sender, EventArgs e)
        {
            this.SampleGrid.Children.Clear();
            Template? template = (Template?)this.chipView.SelectedItem;
            if (template == null)
            {
                return;
            }

            var page = this.LoadPage(template.PageName);
            this.SampleGrid.Children.Add(page);
        }

        private void PropertiesTapped(object sender, TappedEventArgs e)
        {
            this.propertyFrame.IsVisible = !this.propertyFrame.IsVisible;
            this.propertyFrameOverlay.IsVisible = !this.propertyFrameOverlay.IsVisible;
        }

        private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
        {
            if (Application.Current != null)
            {
                if (themeSwitch == null)
                {
                    return;
                }

                if ((bool)themeSwitch.IsOn!)
                {
                    Application.Current.UserAppTheme = AppTheme.Dark;
                    if (mergedDictionaries != null)
                    {
                        var theme = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        var themeToolkit = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        if (theme != null && themeToolkit != null)
                        {
                            theme.VisualTheme = Syncfusion.Maui.Themes.SfVisuals.MaterialDark;
                            themeToolkit.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialDark;
                        }
                    }
                }
                else
                {
                    Application.Current.UserAppTheme = AppTheme.Light;
                    if (mergedDictionaries != null)
                    {
                        var theme = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        var themeToolkit = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                        if (theme != null && themeToolkit != null)
                        {
                            theme.VisualTheme = Syncfusion.Maui.Themes.SfVisuals.MaterialLight;
                            themeToolkit.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialLight;
                        }
                    }
                }
            }
        }

        public string? GetCodeViewerPath()
        {
            Template? template = (Template?)this.chipView.SelectedItem;
            if (template == null)
            {
                return string.Empty;
            }

            return template.PageName?.Replace('.', '/') + ".xaml";
        }

        #endregion
    }
}