using EssentialMAUIUIKit.AppLayout.Models;
using EssentialMAUIUIKit.AppLayout.ViewModels;

namespace EssentialMAUIUIKit.AppLayout.Views
{
    public partial class HomePageMobileUI : ContentPage
    {
        ICollection<ResourceDictionary>? mergedDictionaries;
        public HomePageMobileUI()
        {
            InitializeComponent();
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
        }

        #region Methods

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void ListView_OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
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

        private async void GotoCodeViewer(object sender, EventArgs e)
        {
            string address = "https://github.com/syncfusion/essential-ui-kit-for-.net-maui";
            await Browser.Default.OpenAsync(address, BrowserLaunchMode.SystemPreferred);
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }

            Category? category = e.Item as Category;
            if (category == null)
            {
                return;
            }

            this.Navigation.PushAsync(new TemplatePage(category, category.Pages[0]));
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

        private void listView_ScrollChanged(object sender, Controls.ScrollChangedEventArgs e)
        {
        }

        private async void Search_ClickedAsync(object sender, EventArgs e)
        {
            this.searchGridView.IsVisible = !this.searchGridView.IsVisible;
            this.searchView.IsEnabled = true;
            this.searchListGrid.IsVisible = true;

            if (this.BindingContext is HomePageViewModel viewModel)
            {
                await Task.Delay(16);
                viewModel.PopulateSearchItem(String.Empty);
            }
        }

        private void searchView_Unfocused(object sender, FocusEventArgs e)
        {
            this.searchGridView.IsVisible = false;
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

            this.Navigation.PushAsync(new TemplatePage(category.Category, category.Template));
            this.searchView.Text = string.Empty;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.searchGridView.IsVisible = false;
            this.searchView.Text = string.Empty;
            this.searchView.IsEnabled = false;
        }

        #endregion
    }
}
