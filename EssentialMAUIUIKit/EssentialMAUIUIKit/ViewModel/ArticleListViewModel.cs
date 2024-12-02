using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ArticleListViewModel
    {
        public ObservableCollection<Story> FeaturedStories { get; set; }
        public ObservableCollection<Story> LatestStories { get; set; }

        public ArticleListViewModel()
        {
            FeaturedStories = new ObservableCollection<Story>();
            LatestStories = new ObservableCollection<Story>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""featuredStories"": [
                {
                    ""itemImage"": ""ArticleImage2.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Aug 2010"",
                    ""name"": ""Learning to Reset""
                },
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Apr 16"",
                    ""name"": ""Holistic Approach to UI Design""
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""May 2012"",
                    ""name"": ""Guiding Your Flock to Success""
                },
                {
                    ""itemImage"": ""ArticleImage5.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Apr 16"",
                    ""name"": ""Be a Nurturing, Fierce Team Leader""
                },
                {
                    ""itemImage"": ""ArticleImage6.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Dec 2013"",
                    ""name"": ""Holistic Approach to UI Design""
                }
            ],
            ""latestStories"": [
                {
                    ""itemImage"": ""ArticleImage2.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Apr 16"",
                    ""name"": ""Learning to Reset""
                },
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""May 26"",
                    ""name"": ""Holistic Approach to UI Design""
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Apr 10"",
                    ""name"": ""Guiding Your Flock to Success""
                },
                {
                    ""itemImage"": ""ArticleImage5.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Apr 16"",
                    ""name"": ""Holistic Approach to UI Design""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ArticlesData>(jsonData, options);
            var featuredStoryImages = new List<string> { "ArticleImage2.png", "ArticleImage3.png", "ArticleImage4.png", "ArticleImage5.png", "ArticleImage6.png" };
            var latestStoryImages = new List<string> { "ArticleImage2.png", "ArticleImage3.png", "ArticleImage4.png", "ArticleImage5.png" };

            if (data == null)
            {
                return;
            }

            for (int i = 0; i < data.FeaturedStories?.Count; i++)
            {
                var story = data.FeaturedStories[i];
                story.ImagePath = featuredStoryImages[i];
                FeaturedStories.Add(story);
            }

            for (int i = 0; i < data.LatestStories?.Count; i++)
            {
                var story = data.LatestStories[i];
                story.ImagePath = latestStoryImages[i];
                LatestStories.Add(story);
            }
        }
    }

    public class ArticlesData
    {
        public List<Story>? FeaturedStories { get; set; }
        public List<Story>? LatestStories { get; set; }
    }

}
