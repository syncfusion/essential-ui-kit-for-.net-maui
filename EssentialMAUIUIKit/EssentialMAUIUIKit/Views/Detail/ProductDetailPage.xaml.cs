using EssentialMAUIUIKit;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.Chips;

namespace EssentialMAUIUIKit.Views.Detail
{
    public partial class ProductDetailPage : ContentView
    {
        public ProductDetailPage()
        {
            InitializeComponent();
            // The thumbnails selection is owned by ProductDetailsViewModel
            // (the first preview is marked IsSelected = true at construction).
        }

        /// <summary>
        /// Handles selection changes from the size <see cref="SfChipGroup"/>.
        /// The TwoWay binding on <c>SelectedItem</c> alone is unreliable on
        /// Phone because the parent <c>ScrollView</c> can capture the touch
        /// as a pan-start gesture before the chip's tap recogniser fires.
        /// Forwarding the control's <c>SelectionChanged</c> event into the
        /// ViewModel here guarantees the selection is committed regardless
        /// of which platform fired the event. This is the same pattern used
        /// in <see cref="EssentialMAUIUIKit.Views.Dashboard.DailyCaloriesReportPage"/>.
        /// </summary>
        private void OnSizeChipSelectionChanged(object sender, Syncfusion.Maui.Toolkit.Chips.SelectionChangedEventArgs e)
        {
            if (BindingContext is not ProductDetailsViewModel vm)
            {
                return;
            }

            if (e.AddedItem is SizeItem newlySelected)
            {
                vm.SelectedSize = newlySelected;
            }
            else if (e.RemovedItem is SizeItem && vm.SelectedSize is { } current)
            {
                // The user tapped the already-selected chip to deselect it
                // (SfChipGroup Choice mode supports this). Re-apply the
                // current selection so IsSelected stays in sync with the
                // DataTrigger-driven stroke colour.
                vm.SelectedSize = current;
            }
        }

        /// <summary>
        /// Method to toggle the favourite state of the current product when the
        /// favourite icon button is tapped. The button's glyph and colour are
        /// driven by the <see cref="ProductImage.IsFavourite"/> flag through the
        /// BooleanToStringConverter (parameter 1) and BooleanToColorConverter
        /// (parameter 4) registered in the page resources.
        /// </summary>
        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            SfButton? button = sender as SfButton;
            var product = button?.BindingContext as EssentialMAUIUIKit.ProductImage;
            if (product != null)
            {
                product.IsFavourite = !product.IsFavourite;
            }
        }

        private void thumbnailsListView_ItemTapped(
            object sender,
            Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            if (e.DataItem is not ProductImage selectedItem)
            {
                return;
            }

            if (BindingContext is not ProductDetailsViewModel vm || vm.Product?.PreviewImages is not { } previewImages)
            {
                return;
            }

            foreach (var item in previewImages)
            {
                item.IsSelected = item == selectedItem;
            }
        }
    }
}
