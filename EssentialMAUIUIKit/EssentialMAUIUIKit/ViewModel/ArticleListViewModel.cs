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
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Aug 16, 2023"",
                    ""name"": ""Learning to Reset"",
                    ""description"": ""Discover techniques for resetting routines and improving focus in daily work.""
                },
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Apr 16, 2023"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""description"": ""A holistic view of UI design that balances aesthetics and usability.""
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""May 24, 2023"",
                    ""name"": ""Guiding Your Flock to Success"",
                    ""description"": ""Leadership tips to help your team reach collective goals with empathy.""
                },
                {
                    ""itemImage"": ""ArticleImage5.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Apr 16, 2023"",
                    ""name"": ""Be a Nurturing, Fierce Team Leader"",
                    ""description"": ""Strategies for being both supportive and results-driven as a leader.""
                },
                {
                    ""itemImage"": ""ArticleImage6.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 min read"",
                    ""date"": ""Dec 11, 2023"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""description"": ""Examples of integrating design systems for consistent product experiences.""
                }
            ],
            ""latestStories"": [
                {
                    ""itemImage"": ""ArticleImage2.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Apr 16, 2023"",
                    ""name"": ""Learning to Reset"",
                    ""description"": ""Discover techniques for resetting routines and improving focus in daily work.""
                },
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""May 26, 2023"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""description"": ""A holistic view of UI design that balances aesthetics and usability.""
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Apr 10, 2023"",
                    ""name"": ""Guiding Your Flock to Success"",
                    ""description"": ""Leadership tips to help your team reach collective goals with empathy.""
                },
                {
                    ""itemImage"": ""ArticleImage5.png"",
                    ""author"": ""John Doe"",
                    ""averageReadingTime"": ""5 mins read"",
                    ""date"": ""Apr 16, 2023"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""description"": ""Examples of integrating design systems for consistent product experiences.""
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

            for (int i = 0; i < data.FeaturedStories?.Count && i < featuredStoryImages.Count; i++)
            {
                var story = data.FeaturedStories[i];
                story.ImagePath = featuredStoryImages[i];
                FeaturedStories.Add(story);
            }

            for (int i = 0; i < data.LatestStories?.Count && i < latestStoryImages.Count; i++)
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
