using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Transaction
{
    public partial class MyCardsPage : ContentView
    {
        public MyCardsPage()
        {
            // Mock data is now loaded in the MyCardsViewModel constructor
            // (via TransactionMockDataService), so this page stays declarative
            // and does not embed any JSON payloads in the code-behind.
            InitializeComponent();
        }

        private async void OnDebitCardTapped(object sender, TappedEventArgs e)
        {
            if (sender is Border border)
            {
                await border.ScaleToAsync(0.97, 80, Easing.CubicOut);
                await border.ScaleToAsync(1.0, 80, Easing.CubicIn);
            }
        }
    }
}
