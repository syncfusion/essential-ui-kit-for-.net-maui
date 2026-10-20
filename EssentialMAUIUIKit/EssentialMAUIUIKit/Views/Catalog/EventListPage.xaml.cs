using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class EventListPage : ContentView
    {
        public EventListPage()
        {
            InitializeComponent();
        }

        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is not SfButton button)
            {
                return;
            }

            if (button.BindingContext is not EssentialMAUIUIKit.Models.Catalog.EventList @event)
            {
                return;
            }

            @event.IsPopular = !@event.IsPopular;
            @event.NotifyPropertyChanged(nameof(@event.IsPopular));
        }

        private void tabView_TabItemTapped(object sender, Syncfusion.Maui.Toolkit.TabView.TabItemTappedEventArgs e)
        {
            bool isDarkTheme = Application.Current?.RequestedTheme == AppTheme.Dark;

            Color unSelectedColor = isDarkTheme ? Colors.White : Colors.Black;
            Color selectedColor = isDarkTheme ? Colors.Black : Colors.White;

            // Reset all tabs
            tabItem1.TextColor = unSelectedColor;
            tabItem2.TextColor = unSelectedColor;
            tabItem3.TextColor = unSelectedColor;

            // Highlight selected tab
            if (e.TabItem != null)
            {
                e.TabItem.TextColor = selectedColor;
            }
        }
    }
}