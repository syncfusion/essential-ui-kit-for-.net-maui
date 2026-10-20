using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Bookmark
{
    /// <summary>
    /// Code-behind for the Wishlist page. The view reuses the
    /// cart view model because the wishlist surfaces the same
    /// product cards; the binding-only behaviour keeps this
    /// file small and free of fragile template traversal.
    /// </summary>
    public partial class WishlistPage : ContentView
    {
        public WishlistPage()
        {
            InitializeComponent();
        }
    }
}