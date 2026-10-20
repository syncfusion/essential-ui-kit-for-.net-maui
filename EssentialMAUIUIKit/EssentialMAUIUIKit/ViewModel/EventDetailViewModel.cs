using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class EventDetailViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UserProfile>? Connections { get; set; }

        public ObservableCollection<RecommendedShow>? RecommendedShows { get; set; }

        public ObservableCollection<string>? HeaderImages { get; set; }

        public string EventTitle { get; set; } = string.Empty;

        public string EventCategory { get; set; } = string.Empty;

        public string EventDuration { get; set; } = string.Empty;

        public string EventPrice { get; set; } = string.Empty;

        public string EventDate { get; set; } = string.Empty;

        public string EventLanguage { get; set; } = string.Empty;

        public string EventLocation { get; set; } = string.Empty;

        public string EventAgeLimit { get; set; } = string.Empty;

        public string EventStartTime { get; set; } = string.Empty;

        private bool isFavorite;

        /// <summary>
        /// Gets or sets a value indicating whether the event is marked as
        /// favourite. The Phone hero action button on
        /// <see cref="Views.Detail.EventDetailPage"/> binds its glyph to
        /// <see cref="FavoriteIcon"/> (derived from this flag) and invokes
        /// <see cref="ToggleFavoriteCommand"/> on tap.
        /// </summary>
        public bool IsFavorite
        {
            get => isFavorite;
            set
            {
                if (isFavorite != value)
                {
                    isFavorite = value;
                    OnPropertyChanged(nameof(IsFavorite));
                    OnPropertyChanged(nameof(FavoriteIcon));
                }
            }
        }

        /// <summary>
        /// Gets the glyph that should be rendered for the favorite button.
        /// Outline glyph (xe71D) when not favorited, filled glyph (xe71E)
        /// when favorited. Exposed as a string (not bound through a converter)
        /// so that the <c>UIKitIcons</c> Private Use Area codepoint is used
        /// directly without any font-family mismatch.
        /// </summary>
        public string FavoriteIcon => isFavorite ? "\uE71E" : "\uE71D";

        /// <summary>
        /// Toggles <see cref="IsFavorite"/>. Triggered by the favorite
        /// action button on the Phone hero of EventDetailPage.
        /// </summary>
        public ICommand ToggleFavoriteCommand => new Command(ToggleFavorite);

        private void ToggleFavorite()
        {
            IsFavorite = !IsFavorite;
        }

        public EventDetailViewModel()
        {
            LoadData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadData()
        {

            HeaderImages = new ObservableCollection<string>
            {
                App.ImageServerPath + "Album1.png",
                App.ImageServerPath + "Album2.png",
                App.ImageServerPath + "Album3.png"
            };

            EventTitle = "Happy Ending - A Live Standup Show By\nNesan David";
            EventCategory = "COMEDY";
            EventDuration = "2H 30M";
            EventPrice = "\u20B9499 onwards";
            EventDate = "Sat 27 Jul - Thu 15 Aug, 2024";
            EventLanguage = "English, Tamil";
            EventLocation = "Music Academy, Chennai";
            EventAgeLimit = "12+ years";
            EventStartTime = "4:00 PM";

            Connections = new ObservableCollection<UserProfile>
            {
                new()
                {
                    ImagePath = "ProfileImage10.png",
                    Name = "Diana Jones",
                    Role = "Singer"
                },
                new()
                {
                    ImagePath = "ProfileImage11.png",
                    Name = "Christy",
                    Role = "Producer"
                },
                new()
                {
                    ImagePath = "ProfileImage12.png",
                    Name = "Roselin",
                    Role = "Organiser"
                },
                new()
                {
                    ImagePath = "ProfileImage13.png",
                    Name = "Emily John",
                    Role = "Production Head"
                },
                new()
                {
                    ImagePath = "ProfileImage14.png",
                    Name = "Mary William",
                    Role = "Singer"
                }
            };

            RecommendedShows = new ObservableCollection<RecommendedShow>
            {
                new()
                {
                    ImagePath = "comedyshow.png",
                    Title = "Comedy show",
                    Category="Comedy",
                    Rating = "4.6",
                    RatingCount = "18k ratings"
                },
                new()
                {
                    ImagePath = "justjokes.png",
                    Title = "Just Jokes",
                    Category="Comedy",
                    Rating = "4.2",
                    RatingCount = "12k ratings"
                },
                new()
                {
                    ImagePath = "comedygalatta.png",
                    Title = "Comedy galatta",
                    Category="Comedy",
                    Rating = "3.0",
                    RatingCount = "11k ratings"
                },
                new()
                {
                    ImagePath = "funguarantee.png",
                    Title = "Fun Gaurantee",
                    Category="Comedy",
                    Rating = "2.3",
                    RatingCount = "10k ratings"
                }
            };
        }
    }

    public class RecommendedShow
    {
        public string? ImagePath { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? Rating { get; set; }
        public string? RatingCount { get; set; }
    }
}
