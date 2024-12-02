namespace EssentialMAUIUIKit.Views.History
{
    public partial class MyOrdersView : ContentView
    {
        public MyOrdersView()
        {
            InitializeComponent();
            BindingContext = this.viewModel;
        }
    }
}