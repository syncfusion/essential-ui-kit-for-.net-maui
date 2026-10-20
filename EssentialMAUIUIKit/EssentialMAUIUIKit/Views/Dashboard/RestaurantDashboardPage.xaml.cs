namespace EssentialMAUIUIKit.Views.Dashboard;

public partial class RestaurantDashboardPage : ContentView
{
	private RestaurantDashboardViewModel? viewModel;

	public RestaurantDashboardPage()
	{
		InitializeComponent();
		this.Loaded += OnPageLoaded;
	}

    private async void ProfileButton_Tapped(object sender, TappedEventArgs e)
    {
        // Click effect: shrink then restore
        await ProfileAvatarBorder.ScaleToAsync(0.88, length: 80, easing: Easing.CubicOut);
        await ProfileAvatarBorder.ScaleToAsync(1.0, length: 120, easing: Easing.CubicIn);
    }

    private void OnPageLoaded(object? sender, EventArgs e)
	{
		viewModel = this.BindingContext as RestaurantDashboardViewModel;
	}

	private void OnMenuItemPointerEntered(object? sender, PointerEventArgs e)
	{
		// Get the Border control that triggered the event
		if (sender is Border border)
		{
			// Get the data context (RestaurantDashboardMenuItem)
			if (border.BindingContext is RestaurantDashboardMenuItem menuItem)
			{
				// Set IsHovered to true to show the overlay
				menuItem.IsHovered = true;
			}
		}
	}

	private void OnMenuItemPointerExited(object? sender, PointerEventArgs e)
	{
		// Get the Border control that triggered the event
		if (sender is Border border)
		{
			// Get the data context (RestaurantDashboardMenuItem)
			if (border.BindingContext is RestaurantDashboardMenuItem menuItem)
			{
				// Set IsHovered to false to hide the overlay
				menuItem.IsHovered = false;
			}
		}
	}
}