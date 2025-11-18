namespace EssentialMAUIUIKit.Views.OnBoarding;

public partial class OnboardingPage : ContentView
{
    public OnboardingPage()
    {
        InitializeComponent();
    }

    private async void ContentLoaded(object sender, EventArgs e)
    {
        if (sender is VisualElement element)
        {
            // Set initial states
            element.Opacity = 0;
            element.Scale = 0;

            // Perform fade and scale animations
            await Task.WhenAll(
                element.FadeToAsync(1, 2000, Easing.CubicInOut),
                element.ScaleToAsync(1, 2000, Easing.CubicInOut)
            );
        }
    }
}