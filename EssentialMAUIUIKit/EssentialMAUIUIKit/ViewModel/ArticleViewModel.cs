using EssentialMAUIUIKit.Models;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ArticleViewModel
    {
        public Articles? Articles { get; set; }

        public ArticleViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""articleName"": ""Better Brainstorming by Hand"",
            ""articleParallaxHeaderImage"": ""ArticleParallaxHeaderImage.png"",
            ""articleSubImage"": ""BlogDetail.png"",
            ""articleAuthor"": ""John Doe"",
            ""articleDate"": ""Apr 16"",
            ""articleReadingTime"": ""5 mins read"",
            ""articleContent"": ""Organizing projects is now predominantly a digital endeavor. Physical whiteboards have given way to electronic Gantt charts. Pocket calendars have yielded to smartphone scheduling apps. Even the most popular tool of the most ferocious organizers\u002Dthe sticky note\u002Dnow has a digital counterpart. Despite this digitization, one shouldn\u0027t lose sight of the usefulness of articulating ideas on paper. Handwriting is still the most viable means for bringing ideas and concepts into the physical world for organizing and comparing.This isn\u0027t to say you should remain in the archaic world of markers and pens; rather, handwriting should be harnessed as the initial step in understanding a project\u002Da free association of all the ideas that pop into your head. After organizing and reorganizing your thoughts on paper, moving them into the digital realm as tasks, reminders, and schedules serves as the final refinement of what you\u0027re trying to accomplishment and how you plan to accomplish it."",
            ""subTitle1"": ""Procedure for writing out your ideas"",
            ""subTitle2"": ""RELATED STORIES"",
            ""articleImage"": ""ArticleImage2.png"",
            ""relatedStories"": [
                {
                    ""itemImage"": ""ArticleImage3.png"",
                    ""name"": ""Holistic Approach to UI Design"",
                    ""author"": ""John Doe"",
                    ""date"": ""Apr 16"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""ArticleImage4.png"",
                    ""name"": ""Guiding Your Flock to Success"",
                    ""author"": ""John Doe"",
                    ""date"": ""May 12"",
                    ""averageReadingTime"": ""5 mins read""
                }
            ],
            ""contentList"": [
                {
                    ""description"": ""Write a one or two sentence summary of the goal or project you want to complete.""
                },
                {
                    ""description"": ""Then write every idea you associate with the goal or project on separate pieces of paper sticky notes are ideal. Don\u0027t self edit at this point, write everything that comes to mind.""
                },
                {
                    ""description"": ""Spread all the pieces of paper onto a table, a desk, a bed, or even the floor.""
                },
                {
                    ""description"": ""Sort the ideas by category some will be tasks to do, others will be equipment or training you need.""
                },
                {
                    ""description"": ""Organize the categories from top to bottom according to the sequence in which they need to occur. This will help you remove items that are redundant and identify items that need to be added.""
                },
                {
                    ""description"": ""Now you are ready to enter the items in an organized fashion into your project management software""
                }
            ],
""reviews"": [
                {
                    ""profileimage"": ""ProfileImage1.png"",
                    ""customername"": ""Jhon Deo"",
                    ""comment"": ""Greatest article I have ever read in my life."",
                    ""revieweddate"": ""29 Dec, 2019""
                },
                {
                    ""profileimage"": ""ProfileImage3.png"",
                    ""customername"": ""David Son"",
                    ""comment"": ""Absolutely love them! Can't stop reading!"",
                    ""revieweddate"": ""29 Dec, 2019""
                }
            ],
            ""articleList"": [
                {
                    ""itemImage"": ""Book1.png"",
                    ""author"": ""Rahul Rai"",
                    ""date"": ""Apr 16, 2020"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book2.png"",
                    ""author"": ""Ed Freitas"",
                    ""date"": ""Jan 26, 2023"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book3.png"",
                    ""author"": ""James McCaffrey"",
                    ""date"": ""Aug 21, 2017"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book4.png"",
                    ""author"": ""Jason Cannon"",
                    ""date"": ""Dec 10, 2018"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book5.png"",
                    ""author"": ""Eric Stitt"",
                    ""date"": ""May 20, 2021"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book6.png"",
                    ""author"": ""Jose Roberto"",
                    ""date"": ""Mar 13, 2015"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book7.png"",
                    ""author"": ""Lucia Da Silva"",
                    ""date"": ""Sep 16, 2021"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book8.png"",
                    ""author"": ""Ryan Hudson"",
                    ""date"": ""Nov 06, 2012"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book9.png"",
                    ""author"": ""Marko Svaljek"",
                    ""date"": ""Oct 30, 2009"",
                    ""averageReadingTime"": ""5 mins read""
                },
                {
                    ""itemImage"": ""Book10.png"",
                    ""author"": ""Frederik Dietz"",
                    ""date"": ""Jan 05, 2017"",
                    ""averageReadingTime"": ""5 mins read""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Articles = JsonSerializer.Deserialize<Articles>(jsonData, options);
            var images = new List<string> { "ArticleImage2.png", "ArticleImage2.png", "ArticleImage3.png", "ArticleImage4.png", "ArticleImage5.png", "ArticleImage6.png" };
            var profileImages = new List<string> { "ProfileImage1.png", "ProfileImage3.png" };
            var articleImages = new List<string> { "Book1.png", "Book2.png", "Book3.png", "Book4.png", "Book5.png", "Book6.png", "Book7.png", "Book8.png", "Book9.png", "Book10.png" };
            if (Articles == null)
            {
                return;
            }

            for (int i = 0; i < Articles.RelatedStories?.Count; i++)
            {
                var article = Articles.RelatedStories[i];
                article.ImagePath = images[i];
            }

            for (int i = 0; i < Articles.Reviews?.Count; i++)
            {
                var review = Articles.Reviews[i];
                review.CustomerImage = profileImages[i];
            }

            for (int i = 0; i < Articles.ArticleList?.Count; i++)
            {
                var article = Articles.ArticleList[i];
                article.ImagePath = articleImages[i];
            }
        }
    }

    public class Articles
    {
        private string? articleParallaxHeaderImage;
        private string? articleSubImage;
        private string? articleImage;
        public string? ArticleName { get; set; }
        public string? ArticleParallaxHeaderImage
        {
            get { return App.ImageServerPath + articleParallaxHeaderImage; }
            set { articleParallaxHeaderImage = value; }
        }

        public string ArticleSubImage
        {
            get { return App.ImageServerPath + articleSubImage; }
            set { articleSubImage = value; }
        }

        public string? ArticleAuthor { get; set; }
        public string? ArticleDate { get; set; }
        public string? ArticleReadingTime { get; set; }
        public string? ArticleContent { get; set; }
        public string? SubTitle1 { get; set; }
        public string? SubTitle2 { get; set; }
        public string ArticleImage
        {
            get { return App.ImageServerPath + articleImage; }
            set { articleImage = value; }
        }

        public List<Story>? RelatedStories { get; set; }
        public List<Content>? ContentList { get; set; }

        public List<EssentialMAUIUIKit.Models.Review>? Reviews { get; set; }

        public List<Story>? ArticleList { get; set; }
    }

    public class Content
    {
        public string? Description { get; set; }
    }

}
