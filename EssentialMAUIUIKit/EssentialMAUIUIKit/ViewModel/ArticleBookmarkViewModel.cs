using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ArticleBookmarkViewModel
    {
        public ObservableCollection<Story> LatestStories { get; set; }

        public ArticleBookmarkViewModel()
        {
            LatestStories = new ObservableCollection<Story>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""latestStories"": [
                {
                    ""itemImage"": ""ArticleImage2.png"",
                    ""name"": ""Learning to Reset"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 16"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 18"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""name"": ""Guiding Your Flock to Success"",
                    ""author"": ""John Doe"",
                    ""date"": ""May 10"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage5.png"",
                    ""name"": ""Be a Fierce Team Leader"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 16"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage6.png"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 10"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage7.jpg"",
                    ""name"": ""Guiding Your Flock to Success"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 16"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                },
                {
                    ""itemImage"": ""ArticleImage8.jpg"",
                    ""name"": ""Be a Fierce Team Leader"",
                    ""author"": ""John Doe"",
                    ""date"": ""May 05"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""isBookmarked"": true
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<Dictionary<string, ObservableCollection<Story>>>(jsonData, options);
            if (data == null)
            {
                return;
            }

            var stories = data["latestStories"];
            var images = new List<string> { "ArticleImage2.png", "ArticleImage3.png", "ArticleImage4.png", "ArticleImage5.png", "ArticleImage6.png", "ArticleImage7.jpg", "ArticleImage8.jpg" };
            for (int i = 0; i < stories.Count; i++)
            {
                var story = stories[i];
                story.ImagePath = images[i];
                LatestStories.Add(story);
            }
        }
    }
}
