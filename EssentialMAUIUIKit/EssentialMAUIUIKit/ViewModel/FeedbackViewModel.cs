using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class FeedbackViewModel
    {
        public ObservableCollection<EssentialMAUIUIKit.Models.Review> FeedbackInfo { get; set; }

        public ObservableCollection<RatingInfo> RatingInfo { get; set; }

        public FeedbackViewModel()
        {
            FeedbackInfo = new ObservableCollection<EssentialMAUIUIKit.Models.Review>();
            RatingInfo = new ObservableCollection<RatingInfo>()
            {
                new RatingInfo(){StarText="5 Star", RatingValue = 80},
                new RatingInfo(){StarText="4 Star", RatingValue = 73},
                new RatingInfo(){StarText="3 Star", RatingValue = 54},
                new RatingInfo(){StarText="2 Star", RatingValue = 21},
                new RatingInfo(){StarText="1 Star", RatingValue = 32},
            };
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""feedbackInfo"": [
                {
                    ""customerName"": ""Jessica Park"",
                    ""comment"": ""These boots are stunning and I look stunning in them."",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage5.png"",
                    ""rating"": 3
                },
                {
                    ""customerName"": ""Alice"",
                    ""comment"": ""Greatest purchase I have ever made in my life. No lie."",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage3.png"",
                    ""rating"": 3
                },
                {
                    ""customerName"": ""John"",
                    ""comment"": ""Absolutely love them! Can't stop wearing!"",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage1.png"",
                    ""rating"": 2
                },
                {
                    ""customerName"": ""Lisa"",
                    ""comment"": ""These boots are very much comfortable for wearing."",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage6.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Rebacca"",
                    ""comment"": ""Absolutely love them! Can't stop wearing!"",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage10.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Jessica Park"",
                    ""comment"": ""Happy purchasing!"",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"", ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage13.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Alice"",
                    ""comment"": ""Happy buying!"",
                    ""images"": [ ""ReviewShoe.png"", ""ReviewShoe.png"", ""ReviewShoe.png"", ""ReviewShoe.png"" ],
                    ""customerImage"": ""ProfileImage8.png"",
                    ""rating"": 4
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var feedbackRoot = JsonSerializer.Deserialize<FeedbackRoot>(jsonData, options);
            var customerImages = new List<string>() { "ProfileImage5.png", "ProfileImage3.png", "ProfileImage1.png", "ProfileImage6.png", "ProfileImage10.png", "ProfileImage13.png", "ProfileImage8.png" };
            var reviewedDates = new List<string>() { "03 Jan, 2024", "12 Jan, 2024", "23 Feb, 2024", "05 Mar, 2024", "14 Mar, 2024", "30 Mar, 2024", "10 Apr, 2024" };

            if (feedbackRoot?.FeedbackInfo == null)
            {
                return;
            }

            for (int i = 0; i < feedbackRoot?.FeedbackInfo.Count; i++)
            {
                feedbackRoot.FeedbackInfo[i].CustomerImage = customerImages[i];
                feedbackRoot.FeedbackInfo[i].ReviewedDate = reviewedDates[i];
                FeedbackInfo.Add(feedbackRoot.FeedbackInfo[i]);
            }
        }
    }

    public class FeedbackRoot
    {
        public List<EssentialMAUIUIKit.Models.Review>? FeedbackInfo { get; set; }
    }

    public class RatingInfo 
    {
        public string? StarText { get; set; }

        public int RatingValue { get; set; }
    }

}
