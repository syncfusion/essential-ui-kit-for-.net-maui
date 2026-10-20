using System;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Toolkit.Buttons;
using Syncfusion.Maui.Toolkit.Popup;

namespace EssentialMAUIUIKit.Views.Detail
{
    public partial class ArticleDetailPage : ContentView
    {
        public ArticleDetailPage()
        {
            InitializeComponent();
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            if (sender is SfButton button && button.BindingContext is EssentialMAUIUIKit.Models.Story story)
            {
                story.IsBookmarked = !story.IsBookmarked;
            }
        }

        private void FavouriteButton_Clicked(object sender, EventArgs e)
        {
            if (sender is SfButton button && button.BindingContext is EssentialMAUIUIKit.Models.Story story)
            {
                story.IsFavourite = !story.IsFavourite;
            }
        }
        private void ResearchTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                researchPopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }

        private void HomeTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                homePopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }

        private void DraftTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                draftPopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }

        private void MoreClicked(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                homePopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottomLeft, 10, 10);
            }
        }
    }
}