using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Views.Feedback;
using Syncfusion.Maui.Buttons;
using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit
{
    public class ReviewBehavior : Behavior<ReviewPage>
    {
        /// <summary>
        /// The data form
        /// </summary>
        private SfDataForm? reviewForm;

        /// <summary>
        /// The submit button
        /// </summary>
        private SfButton? submitButton;

        protected override void OnAttachedTo(ReviewPage bindable)
        {
            base.OnAttachedTo(bindable);
            ReviewPage? reviewPage = bindable as ReviewPage;
            if (reviewPage == null)
            {
                return;
            }

            this.reviewForm = (SfDataForm)reviewPage.Content.FindByName("reviewForm");
            if (this.reviewForm != null)
            {
                reviewForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)reviewPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked += OnAddButtonClicked;
            }
        }

        protected override void OnDetachingFrom(ReviewPage bindable)
        {
            base.OnDetachingFrom(bindable);
            ReviewPage? reviewPage = bindable as ReviewPage;
            if (reviewPage == null)
            {
                return;
            }

            this.reviewForm = (SfDataForm)reviewPage.Content.FindByName("reviewForm");
            if (this.reviewForm != null)
            {
                reviewForm.ItemsSourceProvider = new ItemsSourceProvider();
            }

            this.submitButton = (SfButton)reviewPage.Content.FindByName("submitButton");
            if (this.submitButton != null)
            {
                this.submitButton.Clicked -= OnAddButtonClicked;
            }
        }

        private void OnAddButtonClicked(object? sender, EventArgs e)
        {
            this.reviewForm?.Validate();
        }
    }
}
