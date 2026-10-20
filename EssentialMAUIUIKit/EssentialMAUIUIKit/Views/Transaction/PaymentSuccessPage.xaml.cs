using System;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Transaction
{
    public partial class PaymentSuccessPage : ContentView
    {
        public PaymentSuccessPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raised when the user taps the "Order Details" button. Host
        /// applications can subscribe to wire up navigation to an
        /// order details page without changing this sample component.
        /// </summary>
        public event EventHandler? OrderDetailsRequested;

        /// <summary>
        /// Raised when the user taps the "Continue Shopping" button.
        /// </summary>
        public event EventHandler? ContinueShoppingRequested;

        private void OnOrderDetailsClicked(object? sender, EventArgs e)
        {
            OrderDetailsRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnContinueShoppingClicked(object? sender, EventArgs e)
        {
            ContinueShoppingRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
