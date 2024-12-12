using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class CatalogListPage : ContentView
    {
        public CatalogListPage()
        {
            InitializeComponent();
        }

        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            SfButton? button = sender as SfButton;
            var product = button?.BindingContext as EssentialMAUIUIKit.Models.Product;
            if (product != null)
            {
                product.IsFavourite = !product.IsFavourite;
            }
        }

    }
}