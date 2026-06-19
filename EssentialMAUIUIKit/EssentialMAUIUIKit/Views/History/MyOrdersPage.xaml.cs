namespace EssentialMAUIUIKit.Views.History
{
	public partial class MyOrdersPage : ContentView
	{
		public MyOrdersPage()
		{
			InitializeComponent();
			BindingContext = this.viewModel;


			chipView.SelectedItem = viewModel.Tabs[0];

		}

		private void chipView_ChipClicked(object sender, EventArgs e)
		{
			var vm = BindingContext as OrdersViewModel;

			if (vm == null) return;

			var selected = chipView.SelectedItem;

			if (selected == null) return;

			vm.SelectedTab = selected.ToString();

		}
	}
}