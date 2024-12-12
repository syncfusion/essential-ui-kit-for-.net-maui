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
            SfButton? button = sender as SfButton;
            var @event = button?.BindingContext as EssentialMAUIUIKit.Models.Catalog.EventList;
            if (@event != null)
            {
                @event.IsPopular = !@event.IsPopular;
            }
        }
    }
}