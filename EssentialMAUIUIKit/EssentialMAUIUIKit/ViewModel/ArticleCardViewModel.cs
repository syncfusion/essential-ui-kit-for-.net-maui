using System.Collections.ObjectModel;
using System.Text.Json;
using EssentialMAUIUIKit.Models;

namespace EssentialMAUIUIKit
{
    public class ArticleCardViewModel
    {
        public ObservableCollection<Story> Articles { get; set; }

        public ArticleCardViewModel()
        {
            Articles = new ObservableCollection<Story>();
            PopulateData();
        }

        private void PopulateData()
        {
            string jsonData = @"
        {
          ""articles"": [
            {
              ""name"": ""Better Brainstorming by Hand"",
              ""author"": ""John Doe"",
              ""date"": ""Apr 16"",
              ""averageReadingTime"": ""5 min read"",
              ""itemImage"": ""ArticleParallaxHeaderImage.png"",
              ""bookmarkedCount"": 157,
              ""favouritesCount"": 100,
              ""sharedCount"": 170
            },
            {
              ""name"": ""Holistic Approach to UI Design"",
              ""author"": ""John Doe"",
              ""date"": ""Apr 28"",
              ""averageReadingTime"": ""5 min read"",
              ""itemImage"": ""Event-Image.png"",
              ""bookmarkedCount"": 123,
              ""favouritesCount"": 60,
              ""sharedCount"": 100
            },
            {
              ""name"": ""Learning to Reset"",
              ""author"": ""John Doe"",
              ""date"": ""Aug 16"",
              ""averageReadingTime"": ""5 min read"",
              ""itemImage"": ""ArticleImage2.png"",
              ""bookmarkedCount"": 213,
              ""favouritesCount"": 250,
              ""sharedCount"": 210
            },
            {
              ""name"": ""Music"",
              ""author"": ""John Doe"",
              ""date"": ""Aug 25"",
              ""averageReadingTime"": ""5 min read"",
              ""itemImage"": ""ArticleImage7.jpg"",
              ""bookmarkedCount"": 263,
              ""favouritesCount"": 350,
              ""sharedCount"": 300
            },
            {
              ""name"": ""Guiding Your Flock to Success"",
              ""author"": ""John Doe"",
              ""date"": ""Apr 16"",
              ""averageReadingTime"": ""5 min read"",
              ""itemImage"": ""ArticleImage4.png"",
              ""bookmarkedCount"": 113,
              ""favouritesCount"": 90,
              ""sharedCount"": 190
            }
          ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<Dictionary<string, ObservableCollection<Story>>>(jsonData, options);
            if (data == null)
            {
                return;
            }

            var articles = data["articles"];
            var images = new List<string> { "ArticleParallaxHeaderImage.png", "Event-Image.png", "ArticleImage2.png", "ArticleImage7.jpg", "ArticleImage4.png" };
            for (int i = 0; i < articles.Count; i++)
            {
                var article = articles[i];
                article.ImagePath = images[i];
                Articles.Add(article);
            }
        }
    }
}
