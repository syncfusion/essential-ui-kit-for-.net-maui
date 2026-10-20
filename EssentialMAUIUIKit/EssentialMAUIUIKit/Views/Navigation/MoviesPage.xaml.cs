namespace EssentialMAUIUIKit.Views.Navigation
{
    public partial class MoviesPage : ContentView
    {
        public MoviesPage()
        {
            InitializeComponent();
        }

        private async void OnMoviePointerEntered(object sender, PointerEventArgs e)
        {
            try
            {
                if (sender is View view)
                {
                    await Task.WhenAll(
                        view.ScaleToAsync(
                            scale: 1.08,
                            length: 150,
                            easing: Easing.CubicOut),

                        view.FadeToAsync(
                            opacity: 0.85,
                            length: 150,
                            easing: Easing.CubicOut)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pointer entered error: {ex.Message}");
            }
        }

        private async void OnMoviePointerExited(object sender, PointerEventArgs e)
        {
            try
            {
                if (sender is View view)
                {
                    await Task.WhenAll(
                        view.ScaleToAsync(
                            scale: 1.0,
                            length: 150,
                            easing: Easing.CubicOut),

                        view.FadeToAsync(
                            opacity: 1.0,
                            length: 150,
                            easing: Easing.CubicOut)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pointer exited error: {ex.Message}");
            }
        }

        private async void OnMoviePointerPressed(object sender, PointerEventArgs e)
        {
            try
            {
                if (sender is View view)
                {
                    await Task.WhenAll(
                        view.ScaleToAsync(
                            scale: 1.08,
                            length: 150,
                            easing: Easing.CubicOut),

                        view.FadeToAsync(
                            opacity: 0.85,
                            length: 150,
                            easing: Easing.CubicOut)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pointer pressed error: {ex.Message}");
            }
        }

        private async void OnMoviePointerReleased(object sender, PointerEventArgs e)
        {
            try
            {
                if (sender is View view)
                {
                    await Task.WhenAll(
                        view.ScaleToAsync(
                            scale: 1.0,
                            length: 150,
                            easing: Easing.CubicOut),

                        view.FadeToAsync(
                            opacity: 1.0,
                            length: 150,
                            easing: Easing.CubicOut)
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pointer released error: {ex.Message}");
            }
        }
    }
}