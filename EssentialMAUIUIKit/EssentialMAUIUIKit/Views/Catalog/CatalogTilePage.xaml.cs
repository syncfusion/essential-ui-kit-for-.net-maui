using Syncfusion.Maui.Popup;
using Syncfusion.Maui.Toolkit.Buttons;
using System.Runtime.Versioning;
namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class CatalogTilePage : ContentView
    {
        public CatalogTilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to toggle the favourite state of a product when the favourite button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is not SfButton button)
            {
                return;
            }

            if (button.BindingContext is not EssentialMAUIUIKit.Models.Product product)
            {
                return;
            }

            product.IsFavourite = !product.IsFavourite;
            product.NotifyPropertyChanged(nameof(product.IsFavourite));
        }

        /// <summary>
        /// Method to open the filter popup when the filter button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFilterButtonClicked(object sender, EventArgs e)
        {
            if (sender is SfButton button)
            {
                this.filterPopup.ShowRelativeToView(button, PopupRelativePosition.AlignBottom);
            }
        }

        /// <summary>
        /// Method to open the sort popup when the sort button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSortButtonClicked(object sender, EventArgs e)
        {
            if (sender is SfButton button)
            {
                this.sortPopup.ShowRelativeToView(button, PopupRelativePosition.AlignBottom);
            }
        }

        /// <summary>
        /// Method to close the filter popup when the close button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterClose_Button_Clicked(object sender, EventArgs e)
        {
            this.filterPopup.IsOpen = false;
        }

        

        /// <summary>
        /// Method to close the sort popup when the close button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortClose_Button_Clicked(object sender, EventArgs e)
        {
            this.sortPopup.IsOpen = false;
        }

        private void On_StateChanged(object sender, Syncfusion.Maui.Buttons.StateChangedEventArgs e)
        {
            if(e.IsChecked == true)
            {
                this.sortPopup.IsOpen = false;
            }
        }
    }
}