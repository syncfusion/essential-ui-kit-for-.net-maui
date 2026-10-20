namespace EssentialMAUIUIKit.Views.History
{
	public partial class MyOrdersPage : ContentView
	{
		public MyOrdersPage()
		{
			InitializeComponent();

			Loaded += MyOrdersPage_Loaded;

		}

		private void MyOrdersPage_Loaded(object? sender, EventArgs e)
		{
			Loaded -= MyOrdersPage_Loaded;

			if (BindingContext is not OrdersViewModel vm || vm.Tabs == null || vm.Tabs.Count == 0)
			{
				return;
			}

			chipView.SelectedItem = vm.Tabs[0];
		}

		private void chipView_ChipClicked(object sender, EventArgs e)
		{
			if (BindingContext is not OrdersViewModel vm)
			{
				return;
			}

			var selected = chipView.SelectedItem;

			if (selected == null) return;

			string? tab = selected.ToString();
			if (tab != null)
			{
				vm.SelectedTab = tab;
			}

		}
	}
}