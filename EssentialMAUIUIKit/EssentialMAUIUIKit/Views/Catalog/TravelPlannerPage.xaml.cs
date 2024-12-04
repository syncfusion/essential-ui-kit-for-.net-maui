using Syncfusion.Maui.Buttons;

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
            SfButton? button = sender as SfButton;
            var travel = button?.BindingContext as EssentialMAUIUIKit.Models.Catalog.Travel;
            if (travel != null)
            {
                travel.IsFavourite = !travel.IsFavourite;
            }
        }
    }
}