using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class TravelPlannerPage : ContentView
    {
        public TravelPlannerPage()
        {
            InitializeComponent();
        }

        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is not SfButton button)
            {
                return;
            }

            if (button.BindingContext is not EssentialMAUIUIKit.Models.Catalog.Travel travel)
            {
                return;
            }

            travel.IsFavourite = !travel.IsFavourite;
            travel.NotifyPropertyChanged(nameof(travel.IsFavourite));
        }
    }
}