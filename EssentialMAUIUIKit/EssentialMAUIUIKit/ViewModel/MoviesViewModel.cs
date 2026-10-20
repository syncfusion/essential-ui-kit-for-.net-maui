using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class MoviesViewModel
    {
        public ObservableCollection<Movie> MoviesList { get; set; }

        public MoviesViewModel()
        {
            MoviesList = new ObservableCollection<Movie>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""moviesPageList"": [
                { ""moviename"": ""The Godfather"", ""movieyear"": ""1994"", ""movierating"": 4.6 },
                { ""moviename"": ""The Dark Knight"", ""movieyear"": ""1997"", ""movierating"": 4.3 },
                { ""moviename"": ""12 Angry Men"", ""movieyear"": ""2002"", ""movierating"": 3.5 },
                { ""moviename"": ""Pulp Fiction"", ""movieyear"": ""2004"", ""movierating"": 4.5 },
                { ""moviename"": ""Titanic"", ""movieyear"": ""2005"", ""movierating"": 4.4 },
                { ""moviename"": ""Avatar"", ""movieyear"": ""1998"", ""movierating"": 4.6 },
                { ""moviename"": ""Avengers"", ""movieyear"": ""2001"", ""movierating"": 2.4 },
                { ""moviename"": ""Superman"", ""movieyear"": ""2023"", ""movierating"": 5.0 }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<MoviesData>(jsonData, options);

            var images = new List<string>
            {
                "movie_1.jpg",
                "movie_2.jpg",
                "movie_3.jpg",
                "movie_4.jpg",
                "movie_5.jpg",
                "movie_6.jpg",
                "movie_7.jpg",
                "movie_8.jpg"
            };

            if (data?.MoviesPageList == null)
            {
                return;
            }

            for (int i = 0; i < data.MoviesPageList.Count; i++)
            {
                data.MoviesPageList[i].MovieImage = images[i];
                MoviesList.Add(data.MoviesPageList[i]);
            }
        }
    }

    public class Movie
    {
        private string? movieImage;

        public string? MovieName { get; set; }
        public string? MovieYear { get; set; }
        public double MovieRating { get; set; }

        public string? MovieImage
        {
            get { return movieImage; }
            set { movieImage = value; }
        }
    }

    public class MoviesData
    {
        public List<Movie>? MoviesPageList { get; set; }
    }
}
