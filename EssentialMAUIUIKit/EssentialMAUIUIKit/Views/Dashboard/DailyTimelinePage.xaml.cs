using Syncfusion.Maui.Picker;

namespace EssentialMAUIUIKit.Views.Dashboard;

public partial class DailyTimelinePage : ContentView
{
	public DailyTimelinePage()
	{
		InitializeComponent();
	}

    private void OnDatePickerSelectionChanged(object? sender, DatePickerSelectionChangedEventArgs e)
    {
        if (BindingContext is StockOverviewViewModel viewModel && e.NewValue.HasValue)
        {
            viewModel.SelectedDate = e.NewValue.Value;
        }
    }

    private void DatePicker_Tapped(object sender, TappedEventArgs e)
    {
        this.datePicker.IsOpen = true;
    }
}