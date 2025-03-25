namespace EssentialMAUIUIKit.Views.Dashboard
{
    public partial class HealthCarePage : ContentView
    {
        public HealthCarePage()
        {
            InitializeComponent();
        }

        private void OnChipSelectionChanging(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            // Access the ViewModel and call the function
            var viewModel = (HealthCareViewModel)BindingContext;
            viewModel.ChipSelectionChanged(e);
        }
    }
}