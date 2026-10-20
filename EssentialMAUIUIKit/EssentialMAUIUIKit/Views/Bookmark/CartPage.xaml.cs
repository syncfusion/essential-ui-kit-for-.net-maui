using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Bookmark
{
    /// <summary>
    /// Code-behind for the Cart page. Quantity changes are
    /// driven by commands on the bound <see cref="Models.Product"/>
    /// instance, so this file no longer needs to walk the
    /// visual tree of the data template to wire click events.
    /// </summary>
    public partial class CartPage : ContentView
    {
        public CartPage()
        {
            InitializeComponent();
        }
    }
}