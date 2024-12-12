using EssentialMAUIUIKit.AppLayout.Models;
using EssentialMAUIUIKit.AppLayout.ViewModels;

namespace EssentialMAUIUIKit.AppLayout.Views
{
    public partial class HomePageDesktopUI : ContentPage
    {
        ICollection<ResourceDictionary>? mergedDictionaries;
        public HomePageDesktopUI()
        {
            InitializeComponent();
            var bindingContext = (HomePageViewModel)this.BindingContext;
            this.listView.SelectedItem = bindingContext.Categories[0];
            if (Application.Current != null)
            {
                mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (themeSwitch == null)
                {
                    return;
                }

                if (Application.Current.PlatformAppTheme == AppTheme.Dark)
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

            this.UpdateLoadedChild(new TemplatesView(bindingContext.Categories[0], bindingContext.Categories[0].Pages[0]));
        }

        #region Methods

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void ShowSettings(object sender, EventArgs e)
        {
            this.propertyFrame.IsVisible = !this.propertyFrame.IsVisible;
            this.propertyFrameOverlay.IsVisible = !this.propertyFrameOverlay.IsVisible;
        }

        private async void GotoCodeViewer(object sender, EventArgs e)
        {
            var selectedTemplate = (TemplatesView)this.SampleViewGrid.Children[0];
            string address = "https://github.com/syncfusion/essential-ui-kit-for-.net-maui/blob/master/EssentialMAUIUIKit/EssentialMAUIUIKit/" + selectedTemplate.GetPageName() + "";
            await Browser.Default.OpenAsync(address, BrowserLaunchMode.SystemPreferred);
        }

        private void listView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            this.SampleViewGrid.Children.Clear();
            if (e.DataItem == null)
            {
                return;
            }

            Category? category = e.DataItem as Category;
            if (category == null)
            {
                return;
            }

            this.UpdateLoadedChild(new TemplatesView(category, category.Pages[0]));
        }

        private void UpdateLoadedChild(TemplatesView page)
        {
            this.SampleViewGrid.Children.Add(page);
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

        private void searchView_Unfocused(object sender, FocusEventArgs e)
        {
            this.searchListGrid.IsVisible = false;
        }

        private void searchView_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textValue = (sender as Entry);

            if (e.NewTextValue.Length > 1 && !searchListGrid.IsVisible)
            {
                this.searchListGrid.IsVisible = true;
                this.searchListGrid.ZIndex = 1;
            }
            else if (e.NewTextValue.Length <= 1)
            {
                this.searchListGrid.IsVisible = false;
            }

            var bindingContext = (HomePageViewModel)this.BindingContext;
            this.searchListGrid.IsVisible = bindingContext.CanShowSearchList();
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            this.SampleViewGrid.Children.Clear();
            HorizontalStackLayout? stackLayout = sender as HorizontalStackLayout;

            if (stackLayout == null)
            {
                return;
            }

            SearchModel? category = (SearchModel)stackLayout.BindingContext;
            if (category.Category == null || category.Template == null)
            {
                return;
            }

            this.UpdateLoadedChild(new TemplatesView(category.Category, category.Template));
            this.searchView.Text = string.Empty;
        }

        #endregion
    }
}