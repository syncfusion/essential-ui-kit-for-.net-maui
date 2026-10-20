using Syncfusion.Maui.Picker;

namespace EssentialMAUIUIKit.Views.Dashboard
{
    public partial class HealthCarePage : ContentView
    {
        public HealthCarePage()
        {
            InitializeComponent();
            this.SizeChanged += OnPageSizeChanged;
            this.Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object? sender, EventArgs e)
        {
            // Apply the responsive layout once the page is fully measured.
            OnPageSizeChanged(sender, e);
        }

        private void OnPageSizeChanged(object? sender, EventArgs e)
        {
            if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone || this.Width <= 0)
            {
                return;
            }

            if ((DeviceInfo.Current.Idiom == DeviceIdiom.Tablet && this.Width <= 800) ||
                (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop && this.Width <= 1000))
            {
                // Compact (narrow) layout: collapse the Tracking column and
                // stack it underneath the Daily Tracker.
                Grid.SetColumn(TrackingGrid, 2);
                Grid.SetRow(TrackingGrid, 1);
                TrackingGrid.HorizontalOptions = LayoutOptions.Start;
                mainGrid.ColumnDefinitions[3].Width = new GridLength(0);
                borderLine.IsVisible = true;
                invHBorder.IsVisible = true;
            }
            else
            {
                // Wide layout: keep the three-column structure.
                Grid.SetColumn(TrackingGrid, 3);
                Grid.SetRow(TrackingGrid, 0);
                TrackingGrid.HorizontalOptions = LayoutOptions.End;
                mainGrid.ColumnDefinitions[3].Width = new GridLength(3, GridUnitType.Star);
                borderLine.IsVisible = false;
                invHBorder.IsVisible = false;
            }
        }

        private void DatePicker_Tapped(object? sender, EventArgs e)
        {
            this.datePicker.IsOpen = true;
        }

        private void OnDatePickerSelectionChanged(object? sender, DatePickerSelectionChangedEventArgs e)
        {
            if (BindingContext is HealthCareViewModel viewModel && e.NewValue.HasValue)
            {
                var selectedDate = e.NewValue.Value;
                var selectedDateText = selectedDate.ToString("dd MMM, yyyy");

                var dateLabel = (sender as SfDatePicker)?.Parent?.FindByName<Label>("dateLabel");
                if (dateLabel != null)
                {
                    dateLabel.Text = selectedDateText;
                }
            }
        }

        private void OnChipSelectionChanging(object? sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            // Access the ViewModel and call the function
            var viewModel = (HealthCareViewModel)BindingContext;
            viewModel.ChipSelectionChanged(e);
        }
    }
}