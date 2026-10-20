using EssentialMAUIUIKit.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ArticleDetailViewModel : INotifyPropertyChanged
    {
        private bool isFavourite;

        public bool IsFavourite
        {
            get { return this.isFavourite; }
            set
            {
                this.isFavourite = value;
                this.OnPropertyChanged();
            }
        }

        public void RefreshFavouriteTheme()
        {
            this.OnPropertyChanged(nameof(this.IsFavourite));
        }

        public Articles? Articles { get; set; }

        public ObservableCollection<Story> RelatedDetailStories { get; } = new();

        public ArticleDetailViewModel()
        {
            LoadData();
            LoadRelatedDetailStories();
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
                ""subTitle1"": ""Procedure for Writing Out Your Ideas"",
                ""subTitle2"": ""Related Articles"",
                ""articleImage"": ""ArticleImage2.png"",
                ""articleCategory"": ""ENVIRONMENT"",
                ""articleConclusion"": ""The future of agriculture lies in our ability to innovate and adapt. By embracing sustainable practices and technologies, communities can preserve resources for future generations while improving productivity and quality of life."",
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
                ]
            }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Articles = JsonSerializer.Deserialize<Articles>(jsonData, options);
            var images = new List<string> { "ArticleImage2.png", "ArticleImage2.png", "ArticleImage3.png", "ArticleImage4.png", "ArticleImage5.png", "ArticleImage6.png" };
            var profileImages = new List<string> { "ProfileImage1.png", "ProfileImage3.png" };
            if (Articles == null)
            {
                return;
            }

            for (int i = 0; i < Articles.RelatedStories?.Count && i < images.Count; i++)
            {
                var article = Articles.RelatedStories[i];
                article.ImagePath = images[i];
            }

            for (int i = 0; i < Articles.Reviews?.Count && i < profileImages.Count; i++)
            {
                var review = Articles.Reviews[i];
                review.CustomerImage = profileImages[i];
            }
        }

        private void LoadRelatedDetailStories()
        {
            RelatedDetailStories.Add(new Story
            {
                ImagePath = "ArticleImage3.png",
                Title = "URBAN ECOLOGY",
                Name = "Holistic Approach to UI Design",
                Author = "John Doe",
                Date = "Apr 16",
                AverageReadingTime = "5 mins read"
            });

            RelatedDetailStories.Add(new Story
            {
                ImagePath = "ArticleImage4.png",
                Title = "EFFICIENCY",
                Name = "Guiding Your Flock to Success",
                Author = "Mark Spencer",
                Date = "May 12",
                AverageReadingTime = "6 mins read"
            });

            RelatedDetailStories.Add(new Story
            {
                ImagePath = "ArticleImage5.png",
                Title = "NEW ARRIVAL",
                Name = "The Impact of Green Spaces on City Life",
                Author = "Elena Rodriguez",
                Date = "May 12",
                IsTrending = true,
                AverageReadingTime = "10 mins read"
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}