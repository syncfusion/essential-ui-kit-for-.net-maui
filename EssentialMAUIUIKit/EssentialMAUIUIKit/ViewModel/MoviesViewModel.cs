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
                { ""moviename"": ""The Shawshank Redemption"", ""movieyear"": ""1994"", ""movierating"": 9.2 },
                { ""moviename"": ""The Godfather"", ""movieyear"": ""1972"", ""movierating"": 9.1 },
                { ""moviename"": ""The Godfather: Part II"", ""movieyear"": ""1974"", ""movierating"": 9.1 },
                { ""moviename"": ""The Dark Knight"", ""movieyear"": ""2008"", ""movierating"": 9.1 },
                { ""moviename"": ""12 Angry Men"", ""movieyear"": ""1957"", ""movierating"": 8.9 },
                { ""moviename"": ""Schindler's List"", ""movieyear"": ""1993"", ""movierating"": 8.9 },
                { ""moviename"": ""The Lord Of The Rings: The Return of the King"", ""movieyear"": ""2003"", ""movierating"": 8.9 },
                { ""moviename"": ""Pulp Fiction"", ""movieyear"": ""1994"", ""movierating"": 8.9 },
                { ""moviename"": ""The Good the Bad and the Ugly"", ""movieyear"": ""1966"", ""movierating"": 8.8 },
                { ""moviename"": ""Titanic"", ""movieyear"": ""1997"", ""movierating"": 7.8 },
                { ""moviename"": ""Spider-Man: Far From Home"", ""movieyear"": ""2019"", ""movierating"": 7.6 },
                { ""moviename"": ""Avatar"", ""movieyear"": ""2009"", ""movierating"": 7.8 },
                { ""moviename"": ""Avengers: Infinity War"", ""movieyear"": ""2018"", ""movierating"": 8.5 }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<MoviesData>(jsonData, options);

            if (data?.MoviesPageList == null)
            {
                return;
            }

            foreach (var movie in data.MoviesPageList)
            {
                MoviesList.Add(movie);
            }
        }
    }

    public class Movie
    {
        public string? MovieName { get; set; }
        public string? MovieYear { get; set; }
        public double MovieRating { get; set; }
    }

    public class MoviesData
    {
        public List<Movie>? MoviesPageList { get; set; }
    }
}
