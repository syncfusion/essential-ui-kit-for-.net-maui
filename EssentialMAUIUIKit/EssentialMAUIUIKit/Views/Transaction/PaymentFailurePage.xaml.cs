using System;
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Transaction
{
    public partial class PaymentFailurePage : ContentView
    {
        public PaymentFailurePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raised when the user taps the "Try Again" button. Host
        /// applications can subscribe to re-attempt the payment flow.
        /// </summary>
        public event EventHandler? TryAgainRequested;

        /// <summary>
        /// Raised when the user taps the "Continue Shopping" button.
        /// </summary>
        public event EventHandler? ContinueShoppingRequested;

        private void OnTryAgainClicked(object? sender, EventArgs e)
        {
            TryAgainRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnContinueShoppingClicked(object? sender, EventArgs e)
        {
            ContinueShoppingRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
