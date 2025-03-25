using EssentialMAUIUIKit.Views.OnBoarding;
using Syncfusion.Maui.Core.Rotator;
using Syncfusion.Maui.DataForm;
using Syncfusion.Maui.Rotator;
using Syncfusion.Maui.Toolkit.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EssentialMAUIUIKit
{
    public class OnBoardingBehavior : Behavior<OnboardingPage>
    {
        /// <summary>
        /// The rotator.
        /// </summary>
        private SfRotator? rotator;

        /// <summary>
        /// The submit button.
        /// </summary>
        private SfButton? skipButton;

        /// <summary>
        /// The submit button.
        /// </summary>
        private SfButton? nextButton;

        protected override void OnAttachedTo(OnboardingPage bindable)
        {
            base.OnAttachedTo(bindable);

            this.skipButton = (SfButton?)bindable.Content.FindByName("skipButton");
            if (this.skipButton != null)
            {
                this.skipButton.Clicked += SkipButton_Clicked;
            }

            this.nextButton = (SfButton?)bindable.Content.FindByName("nextButton");
            if (this.nextButton != null)
            {
                this.nextButton.Clicked += NextButton_Clicked;
            }

            this.rotator = (SfRotator?)bindable.Content.FindByName("rotator");
            if (this.rotator != null)
            {
                this.rotator.SelectedIndexChanged += Rotator_SelectedIndexChanged;
            }
        }

        private void Rotator_SelectedIndexChanged(object? sender, Syncfusion.Maui.Core.Rotator.SelectedIndexChangedEventArgs e)
        {
            if (this.nextButton == null || this.skipButton == null || this.rotator == null)
                return;

            int itemCount = this.rotator.ItemsSource?.Cast<object>().Count() ?? 0;

            if (e.Index == itemCount - 1)
            {
                this.nextButton.Text = "Done";
                this.skipButton.IsVisible = false;
            }
            else
            {
                this.nextButton.Text = "Next";
                this.skipButton.IsVisible = true;
            }
        }

        private void NextButton_Clicked(object? sender, EventArgs e)
        {
            if (this.rotator == null || this.skipButton == null || this.nextButton == null || this.nextButton.Text == "Done")
                return;

            this.rotator.SelectedIndex++;
            int currentIndex = this.rotator.SelectedIndex;
            int itemCount = this.rotator.ItemsSource?.Cast<object>().Count() ?? 0;

            if (currentIndex < itemCount - 1)
            {
                this.nextButton.Text = "Next";
                this.skipButton.IsVisible = true;
            }
            else
            {
                // If it's the last item, change to 'Done'
                this.nextButton.Text = "Done";
                this.skipButton.IsVisible = false;
                // You can navigate away or complete the onboarding here
            }
        }

        private void SkipButton_Clicked(object? sender, EventArgs e)
        {
            // Actions to done on skip
        }

        protected override void OnDetachingFrom(OnboardingPage bindable)
        {
            base.OnDetachingFrom(bindable);

            this.rotator = (SfRotator?)bindable.Content.FindByName("rotator");
            if (this.rotator != null)
            {
                this.rotator.SelectedIndexChanged -= Rotator_SelectedIndexChanged;
            }

            this.skipButton = (SfButton?)bindable.Content.FindByName("skipButton");
            if (this.skipButton != null)
            {
                this.skipButton.Clicked -= SkipButton_Clicked;
            }

            this.nextButton = (SfButton?)bindable.Content.FindByName("nextButton");
            if (this.nextButton != null)
            {
                this.nextButton.Clicked -= NextButton_Clicked;
            }
        }
    }
}
