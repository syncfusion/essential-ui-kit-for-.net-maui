using Syncfusion.Maui.Core;
using Syncfusion.Maui.Picker;

namespace EssentialMAUIUIKit.Views.Dashboard
{
    public partial class StockOverviewPage : ContentView
    {
        public StockOverviewPage()
        {
            this.BindingContext = new StockOverviewViewModel();
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }

        private void OnChipChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            if (e.AddedItem != null)
            {
                string? selectedChip = e.AddedItem.ToString();
                if (BindingContext is StockOverviewViewModel viewModel)
                {
                    // Update ViewModel property based on selected chip
                    viewModel.UpdateSelectedChipData(selectedChip);
                }
            }
        }
        private void OnDatePickerSelectionChanged(object? sender, DatePickerSelectionChangedEventArgs e)
        {
            if (BindingContext is StockOverviewViewModel viewModel && e.NewValue.HasValue)
            {
                viewModel.SelectedDate = e.NewValue.Value;
            }
        }

        private void OnSizeChanged(object? sender, EventArgs e)
        {
            if (sender is not null)
            {
                var maximumChartHeight = 580;
                var viewModel = (StockOverviewViewModel)BindingContext;
                if (Application.Current != null)
                {
                    viewModel.InvestmentsLayoutHeight = Application.Current.Windows[0].Height - 280 > maximumChartHeight ? Application.Current.Windows[0].Height - 280 : maximumChartHeight;
                }
            }
        }

        private void DatePicker_Tapped(object sender, TappedEventArgs e)
        {
            this.datePicker.IsOpen = true;
        }
    }
}