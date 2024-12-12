using EssentialMAUIUIKit.AppLayout.Models;
using EssentialMAUIUIKit.AppLayout.ViewModels;
using Syncfusion.Maui.Core;
using System.Reflection;

namespace EssentialMAUIUIKit.AppLayout.Views
{
    public partial class TemplatesView : ContentView
    {
        public TemplatesView(Category selectedCategory, Template selectedTemplate)
        {
            InitializeComponent();
            var bindingContext = (TemplatePageViewModel)this.BindingContext;
            this.chipView.ItemsSource = selectedCategory.Pages;
            bindingContext.SelectedCategory = selectedCategory;
            Template initialPage = selectedTemplate;
            this.chipView.SelectedItem = initialPage;
            var page = this.LoadPage(initialPage.PageName);
            this.CategoryTextlabel.Text = selectedCategory.Name;
            this.DescriptionTextlabel.Text = selectedCategory.Description;
            this.SampleGrid.Children.Add(page);
        }

        #region Methods

        private void ShowSettings(object sender, EventArgs e)
        {
        }

        private void BackButtonPressed(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }

        private void GotoCodeViewer(object sender, EventArgs e)
        {
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
#if WINDOWS
            this.chipScrollView.ScrollToAsync(sender as Element, ScrollToPosition.Center, true);
#endif
            Template? template = (Template?)this.chipView.SelectedItem;
            if (template == null)
            {
                return;
            }

            var page = this.LoadPage(template.PageName);
            this.SampleGrid.Children.Add(page);
        }

        public string? GetPageName()
        {
            Template? template = (Template?)this.chipView.SelectedItem;
            if (template == null)
            {
                return string.Empty;
            }

            return template.PageName?.Replace('.', '/') + ".xaml";
        }
    }

        #endregion
}