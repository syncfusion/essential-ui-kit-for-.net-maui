using Microsoft.Maui.Controls;

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
                element.FadeTo(1, 2000, Easing.CubicInOut),
                element.ScaleTo(1, 2000, Easing.CubicInOut)
            );
        }
    }
}