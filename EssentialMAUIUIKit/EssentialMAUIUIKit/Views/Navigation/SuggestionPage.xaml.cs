namespace EssentialMAUIUIKit.Views.Navigation
{
    public partial class SuggestionPage : ContentView
    {
        private readonly SuggestionViewModel viewModel;

        public SuggestionPage()
        {
            InitializeComponent();
            viewModel = new SuggestionViewModel();
            this.BindingContext = viewModel;
        }

        private void OnFollowButtonClicked(object sender, EventArgs e)
        {
            // Get the clicked button (it's a BindableObject, so we can access BindingContext directly)
            if (sender is BindableObject bindable)
            {
                // Get the binding context of the button (should be the SuggestionItem)
                if (bindable.BindingContext is SuggestionItem item && viewModel != null)
                {
                    // Call the toggle follow command
                    viewModel.ToggleFollowCommand.Execute(item);
                }
            }
        }

        private void OnRequestedBorderTapped(object sender, TappedEventArgs e)
        {
            // Get the tapped border (it's a BindableObject, so we can access BindingContext directly)
            if (sender is BindableObject bindable)
            {
                // Get the binding context of the border (should be the SuggestionItem)
                if (bindable.BindingContext is SuggestionItem item && viewModel != null)
                {
                    // Call the toggle follow command
                    viewModel.ToggleFollowCommand.Execute(item);
                }
            }
        }
    }
}