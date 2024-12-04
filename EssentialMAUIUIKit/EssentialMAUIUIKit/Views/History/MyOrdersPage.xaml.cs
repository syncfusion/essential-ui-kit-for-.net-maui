namespace EssentialMAUIUIKit.Views.History
{
    public partial class MyOrdersPage : ContentView
    {
        public MyOrdersPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel;
        }
    }
}