using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.Calendar;

namespace EssentialMAUIUIKit.Views.Detail
{
    public partial class RoomBookingPage : ContentView
    {
        public RoomBookingPage()
        {
            InitializeComponent();
        }

        private void SfComboBox_Opened(object sender, EventArgs e)
        {
            if (sender is Syncfusion.Maui.Inputs.SfComboBox comboBox)
            {
                comboBox.IsDropDownOpen = true;
            }
        }

        private void SfComboBox_Closed(object sender, EventArgs e)
        {
            if (BindingContext is not RoomBookingPageViewModel vm)
            {
                return;
            }

            vm.IsDropDownOpen = false;

            // Close the calendar dropdown in both code paths so a phone/desktop
            // instance that wasn't the original sender still hides cleanly.
            sfComboBox.IsDropDownOpen = false;
            sfComboBoxMobile.IsDropDownOpen = false;
        }

        private void SfCalendar_ActionButtonClicked(object sender, Syncfusion.Maui.Toolkit.Calendar.CalendarSubmittedEventArgs e)
        {
            if (BindingContext is not RoomBookingPageViewModel vm || vm.RoomDetail == null)
            {
                return;
            }

            if (e.Value is CalendarDateRange dateRange)
            {
                vm.RoomDetail.SelectedRanges = dateRange.EndDate == null
                    ? $"{dateRange.StartDate:dd MMM yyyy}"
                    : $"{dateRange.StartDate:dd MMM yyyy} - {dateRange.EndDate:dd MMM yyyy}";

#if WINDOWS || MACCATALYST
                sfComboBox.Text = vm.RoomDetail.SelectedRanges;
                sfComboBox.IsDropDownOpen = false;
#else
                sfComboBoxMobile.Text = vm.RoomDetail.SelectedRanges;
                sfComboBoxMobile.IsDropDownOpen = false;
#endif
            }
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is RoomBookingPageViewModel vm)
            {
                vm.IsFavourite = !vm.IsFavourite;
            }
        }
    }
}