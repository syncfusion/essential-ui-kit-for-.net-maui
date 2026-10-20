namespace EssentialMAUIUIKit.Views.Article
{
    public partial class MyArticlePage : ContentView
    {
        public MyArticlePage()
        {
            InitializeComponent();
        }



		private static async Task AnimateTapEffectAsync(VisualElement visualElement)
		{
			var originalBackgroundColor = visualElement.BackgroundColor;
			visualElement.BackgroundColor = Color.FromArgb("#E5E1E3");

			await visualElement.ScaleToAsync(0.92, 60, Easing.CubicOut);
			await visualElement.ScaleToAsync(1, 80, Easing.CubicIn);

			await Task.Delay(40);
			visualElement.BackgroundColor = originalBackgroundColor;
		}

		private async void IconTapped(object sender, EventArgs e)
		{
			if (sender is VisualElement icon)
			{
				await AnimateTapEffectAsync(icon);
			}
		}

		private async void OnItemTapped(object sender, TappedEventArgs e)
		{
			if (sender is Grid grid)
			{
				await grid.ScaleToAsync(0.97, 80, Easing.CubicOut);
				await grid.ScaleToAsync(1.0, 80, Easing.CubicIn);
			}
		}
	}
}