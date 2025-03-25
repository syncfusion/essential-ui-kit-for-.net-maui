using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class OnboardingViewModel : BindableObject
    {
        public List<OnBoardingModel> OnboardingItems { get; }
        
        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex != value)
                {
                    _selectedIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public OnboardingViewModel()
        {
            OnboardingItems = new List<OnBoardingModel>
            {
                new OnBoardingModel("onboardingimage1.png","Favorite food near you","Discover the foods from over 2345 restaurants"),
                new OnBoardingModel("onboardingimage2.png","Easy payment methods","Multiple payment modes for your convenience"),
                new OnBoardingModel("onboardingimage3.png","Deliver","Fast delivery to your home, office and wherever you are")
            };
        }
    }

    public class OnBoardingModel
    {
        public OnBoardingModel(string image, string title, string description)
        {
            Image =image;
            Title = title;
            Description = description;
        }

        private string? image;
        private string? title;
        private string? description;

        public string? Image
        {
            get { return image; }
            set { image = value; }
        }

        public string? Title
        {
            get { return title; }
            set { title = value; }
        }

        public string? Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
