namespace EssentialMAUIUIKit.Views.Feedback
{
    public partial class ReviewPage : ContentView
    {
        public ReviewPage()
        {
            InitializeComponent();
            // ProductImage source is owned by ReviewViewModel.ProductImageUrl.
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            if (BindingContext is ReviewViewModel vm)
            {
                if (string.IsNullOrWhiteSpace(vm.ReviewInfo?.Review))
                {
                    // Validation gate: the host application can replace this
                    // with a DisplayAlert or Snackbar in their own build.
                    return;
                }

                // Hook for the host application to persist the review.
                // Intentionally left empty in the UI Kit sample.
            }
        }
    }
}