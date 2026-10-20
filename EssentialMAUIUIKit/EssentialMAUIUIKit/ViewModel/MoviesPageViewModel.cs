using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class MoviesPageViewModel
    {

        private string selectedLanguage = "English";

        public string SelectedLanguage
        {
            get => selectedLanguage;
            set { selectedLanguage = value; }
        }

        public ObservableCollection<string> Languages { get; set; }
        public ObservableCollection<RotatorMovie> RotatorMoviesList { get; set; }
        public ObservableCollection<ShowingMovie> ShowingMoviesList { get; set; }
        public ObservableCollection<UpcomingMovie> UpcomingMoviesList { get; set; }

        public MoviesPageViewModel()
        {
            Languages = new ObservableCollection<string> { "English", "Japanese", "German", "Korean", "Italian" };
            RotatorMoviesList = new ObservableCollection<RotatorMovie>();
            ShowingMoviesList = new ObservableCollection<ShowingMovie>();
            UpcomingMoviesList = new ObservableCollection<UpcomingMovie>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""rotatorMoviesList"": [
                { ""image"": ""BannerImage.png"" },
                { ""image"": ""BanarImage2.jpg"" },
                { ""image"": ""BanarImage3.jpg"" },
                { ""image"": ""BanarImage4.jpeg"" },
                { ""image"": ""BanarImage5.jpg"" }
            ],
            ""showingMoviesList"": [
                { ""moviename"": ""Aladdin"", ""image"": ""Aladdin.png"", ""movierating"":4.2, ""MoviesVotes"": ""14K votes"" },
                { ""moviename"": ""Avengers: Endgame"", ""image"": ""Avengers+End+Game.png"", ""movierating"": 4.6, ""MoviesVotes"": ""11K votes"" },
                { ""moviename"": ""Joker"", ""image"": ""Joker.png"", ""movierating"": 4.7, ""MoviesVotes"": ""16K votes"" },
                { ""moviename"": ""The Lion King"", ""image"": ""Lion+King.png"", ""movierating"": 4.3, ""MoviesVotes"": ""22K votes"" },
                { ""moviename"": ""Captain Marvel"", ""image"": ""Captain+Marvel.png"", ""movierating"": 3.9, ""MoviesVotes"": ""17K votes"" },
                { ""moviename"": ""The Irishman"", ""image"": ""The+Irishman.png"", ""movierating"": 4.8, ""MoviesVotes"": ""27K votes"" }
                
            ],
            ""upcomingMoviesList"": [
                { ""moviename"": ""Blade Runner 2049"", ""image"": ""blade_runner.png"", ""movierating"":4.6, ""MoviesVotes"": ""19K votes"" },
                { ""moviename"": ""Avatar"", ""image"": ""avatar.png"", ""movierating"": 4.2, ""MoviesVotes"": ""32K votes"" },
                { ""moviename"": ""Maze Runner"", ""image"": ""maze_runner.png"", ""movierating"": 4.0, ""MoviesVotes"": ""12K votes"" },
                { ""moviename"": ""Deadpool & Wolverine"", ""image"": ""deadpool_wolverine.png"", ""movierating"": 4.6, ""MoviesVotes"": ""27K votes""},
                { ""moviename"": ""No Time To Die"", ""image"": ""no_time_to_die.png"", ""movierating"": 4.2, ""MoviesVotes"": ""17K votes"" },
                { ""moviename"": ""It ends with us"", ""image"": ""ends_with_us.png"", ""movierating"": 4.6, ""MoviesVotes"": ""15K votes"" }
                
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<MoviesPageData>(jsonData, options);
            var rotatorMovieImages = new List<string>() { "BannerImage.png", "BanarImage2.jpg", "BanarImage3.jpg", "BanarImage4.jpeg", "BanarImage5.jpg" };
            var showingMovieImages = new List<string>() { "Aladdin.png", "Avengers+End+Game.png", "Joker.png", "Lion+King.png", "Captain+Marvel.png", "The+Irishman.png" };
            var upcomingMovieImages = new List<string>() { "blade_runner.png", "avatar.png", "maze_runner.png", "deadpool_wolverine.png", "no_time_to_die.png", "ends_with_us.png" };

            if (data?.RotatorMoviesList == null || data?.ShowingMoviesList == null || data?.UpcomingMoviesList == null)
            {
                return;
            }

            for (int i = 0; i < data.RotatorMoviesList.Count; i++)
            {
                data.RotatorMoviesList[i].Image = rotatorMovieImages[i];
                RotatorMoviesList.Add(data.RotatorMoviesList[i]);
            }

            for (int i = 0; i < data.ShowingMoviesList.Count; i++)
            {
                data.ShowingMoviesList[i].Image = showingMovieImages[i];
                ShowingMoviesList.Add(data.ShowingMoviesList[i]);
            }

            for (int i = 0; i < data.UpcomingMoviesList.Count; i++)
            {
                data.UpcomingMoviesList[i].Image = upcomingMovieImages[i];
                UpcomingMoviesList.Add(data.UpcomingMoviesList[i]);
            }
        }
    }

    public class MoviesPageData
    {
        public List<RotatorMovie>? RotatorMoviesList { get; set; }
        public List<ShowingMovie>? ShowingMoviesList { get; set; }
        public List<UpcomingMovie>? UpcomingMoviesList { get; set; }
    }

    public class RotatorMovie
    {
        private string? image;
        public string Image
        {
            get { return App.ImageServerPath + image; }
            set { image = value; }
        }
    }

    public class ShowingMovie
    {
        private string? image;
        public string Image
        {
            get { return App.ImageServerPath + image; }
            set { image = value; }
        }
        public string? Moviename { get; set; }
        public double Movierating { get; set; }
        public string? MoviesVotes { get; set; }
    }

    public class UpcomingMovie
    {
        public string? Image { get; set; }
        public string? Moviename { get; set; }
        public double Movierating { get; set; }
        public string? MoviesVotes { get; set; }
    }
}
