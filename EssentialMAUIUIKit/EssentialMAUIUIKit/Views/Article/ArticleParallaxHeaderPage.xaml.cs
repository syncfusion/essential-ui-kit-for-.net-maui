using EssentialMAUIUIKit.Converters;
using EssentialMAUIUIKit.Models;
using Syncfusion.Maui.Toolkit.Buttons;

namespace EssentialMAUIUIKit.Views.Article
{
    public partial class ArticleParallaxHeaderPage : ContentView
    {
        public ArticleParallaxHeaderPage()
        {
            InitializeComponent();
			BooleanToColorConverter.ThemeChanged += OnThemeChanged;
        }

		private void OnThemeChanged()
		{
			if (BindingContext is ArticleViewModel articleViewModel)
			{
				articleViewModel.RefreshFavouriteTheme();

				if (articleViewModel.Articles?.RelatedStories != null)
				{
					foreach (var story in articleViewModel.Articles.RelatedStories)
					{
						story.NotifyPropertyChanged(nameof(story.IsFavourite));
					}
				}
			}

			if (BindingContext is ArticleViewModel viewModel && viewModel.RelatedDetailStories != null)
			{
				foreach (var story in viewModel.RelatedDetailStories)
				{
					story.NotifyPropertyChanged(nameof(story.IsFavourite));
				}
			}
		}

		protected override void OnParentSet()
		{
			base.OnParentSet();

			if (Parent == null)
			{
				BooleanToColorConverter.ThemeChanged -= OnThemeChanged;
			}
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

        private async void SfButton_Clicked(object sender, EventArgs e)
        {
			if (sender is VisualElement buttonElement)
			{
                await AnimateTapEffectAsync(buttonElement);
			}

			if (sender is SfButton sfButton && sfButton.BindingContext is EssentialMAUIUIKit.Models.Story story)
			{
				story.IsBookmarked = !story.IsBookmarked;
			}
		}

        private async void IconTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement icon)
            {
				await AnimateTapEffectAsync(icon);
			}
        }

        private async void FavouriteTapped(object sender, EventArgs e)
        {
			if (sender is VisualElement buttonElement)
			{
                await AnimateTapEffectAsync(buttonElement);
			}

			if (sender is SfButton sfButton && sfButton.BindingContext is EssentialMAUIUIKit.Models.Story story)
			{
				story.IsFavourite = !story.IsFavourite;
			}
			else if (BindingContext is ArticleViewModel viewModel)
			{
				viewModel.IsFavourite = !viewModel.IsFavourite;
			}
		}

		private void ArticleScrollView_Scrolled(object sender, ScrolledEventArgs e)
		{
			var sv = (ScrollView)sender;

			double maxScroll = sv.ContentSize.Height - sv.Height;

			if (maxScroll <= 0)
				return;

			ReadingProgressBar.Progress =
				(e.ScrollY / maxScroll) * 100;
		}

		private async void OnItemTapped(object sender, TappedEventArgs e)
		{
			if (sender is StackLayout layout)
			{
				await layout.ScaleToAsync(0.97, 80, Easing.CubicOut);
				await layout.ScaleToAsync(1.0, 80, Easing.CubicIn);
			}
		}
	}
}