namespace EssentialMAUIUIKit.Views.Dashboard
{
    public partial class DailyCaloriesReportPage : ContentView
    {
        public DailyCaloriesReportPage()
        {
            InitializeComponent();
        }

        private void OnChipSelectionChanging(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            // Access the ViewModel and call the function
            var viewModel = (DailyCaloriesReportViewModel)BindingContext;
            viewModel.ChipSelectionChanged(e);
        }
    }
}