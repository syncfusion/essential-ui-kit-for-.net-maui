namespace EssentialMAUIUIKit.Views.History
{
    public partial class TransactionHistoryPage : ContentView
    {
        public TransactionHistoryPage()
        {
            InitializeComponent();
            BindingContext = this.viewModel;
        }
    }
}