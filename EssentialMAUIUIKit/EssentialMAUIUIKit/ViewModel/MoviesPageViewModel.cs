using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class MoviesPageViewModel
    {
        public ObservableCollection<RotatorMovie> RotatorMoviesList { get; set; }
        public ObservableCollection<ShowingMovie> ShowingMoviesList { get; set; }
        public ObservableCollection<TrailerMovie> TrailerMoviesList { get; set; }
        public ObservableCollection<UpcomingMovie> UpcomingMoviesList { get; set; }

        public MoviesPageViewModel()
        {
            RotatorMoviesList = new ObservableCollection<RotatorMovie>();
            ShowingMoviesList = new ObservableCollection<ShowingMovie>();
            TrailerMoviesList = new ObservableCollection<TrailerMovie>();
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
                { ""moviename"": ""The Lion King"", ""image"": ""Lion+King.png"", ""movierating"": 5 },
                { ""moviename"": ""Captain Marvel"", ""image"": ""Captain+Marvel.png"", ""movierating"": 5 },
                { ""moviename"": ""The Irishman"", ""image"": ""The+Irishman.png"", ""movierating"": 5 }
            ],
            ""trailerMoviesList"": [
                { ""moviename"": ""Toy Story 4"", ""image"": ""Toy+Story+4.png"" },
                { ""moviename"": ""Star Wars: The Rise of Skywalker"", ""image"": ""Star+Wars.png"" },
                { ""moviename"": ""The Aeronauts"", ""image"": ""The+Aeronauts.png"" }
            ],
            ""upcomingMoviesList"": [
                { ""moviename"": ""Aladdin"", ""image"": ""Aladdin.png"", ""movierating"": 5 },
                { ""moviename"": ""Avengers: Endgame"", ""image"": ""Avengers+End+Game.png"", ""movierating"": 5 },
                { ""moviename"": ""Joker"", ""image"": ""Joker.png"", ""movierating"": 5 }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<MoviesPageData>(jsonData, options);
            var rotatorMovieImages = new List<string>() { "BannerImage.png", "BanarImage2.jpg", "BanarImage3.jpg", "BanarImage4.jpeg", "BanarImage5.jpg" };
            var showingMovieImages = new List<string>() { "Lion+King.png", "Captain+Marvel.png", "The+Irishman.png" };
            var trailerMovieImages = new List<string>() { "Toy+Story+4.png", "Star+Wars.png", "The+Aeronauts.png" };
            var upcomingMovieImages = new List<string>() { "Aladdin.png", "Avengers+End+Game.png", "Joker.png" };

            if (data?.RotatorMoviesList == null || data?.ShowingMoviesList == null || data?.TrailerMoviesList == null || data?.UpcomingMoviesList == null)
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

            for (int i = 0; i < data.TrailerMoviesList.Count; i++)
            {
                data.TrailerMoviesList[i].Image = trailerMovieImages[i];
                TrailerMoviesList.Add(data.TrailerMoviesList[i]);
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
        public List<TrailerMovie>? TrailerMoviesList { get; set; }
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
        public int Movierating { get; set; }
    }

    public class TrailerMovie
    {
        private string? image;
        public string Image
        {
            get { return App.ImageServerPath + image; }
            set { image = value; }
        }

        public string? Moviename { get; set; }
    }

    public class UpcomingMovie
    {
        private string? image;
        public string Image
        {
            get { return App.ImageServerPath + image; }
            set { image = value; }
        }

        public string? Moviename { get; set; }
        public int Movierating { get; set; }
    }
}
