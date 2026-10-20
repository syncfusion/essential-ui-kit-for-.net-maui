using Syncfusion.Maui.Picker;

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

        private void DatePicker_Tapped(object? sender, EventArgs e)
        {
            this.datePicker.IsOpen = true;
        }

        private void OnDatePickerSelectionChanged(object? sender, DatePickerSelectionChangedEventArgs e)
        {
            if (BindingContext is DailyCaloriesReportViewModel viewModel && e.NewValue.HasValue)
            {
                var selectedDate = e.NewValue.Value;
                var selectedDateText = selectedDate.ToString("dd MMM yyyy");

                var dateLabel = (sender as SfDatePicker)?.Parent?.FindByName<Label>("pickerLabel");
                if (dateLabel != null)
                {
                    dateLabel.Text = selectedDateText;
                }
            }
        }
    }
}