using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class FeedbackViewModel
    {
        public ObservableCollection<EssentialMAUIUIKit.Models.Review> FeedbackInfo { get; set; }

        public ObservableCollection<RatingInfo> RatingInfo { get; set; }

        public ICommand FilterCommand { get; }

        public ICommand WriteReviewCommand { get; }

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
            FilterCommand = new Command<string>(OnFilter);
            WriteReviewCommand = new Command(OnWriteReview);
            LoadData();
        }

        private void OnFilter(string? filter)
        {
            // Hook for the host application to filter the review list
            // (e.g. "Newest", "Highest"). Intentionally left empty in
            // the UI Kit sample.
        }

        private void OnWriteReview()
        {
            // Hook for the host application to open the write-a-review flow.
            // Intentionally left empty in the UI Kit sample.
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""feedbackInfo"": [
                {
                    ""customerName"": ""Jessica Park"",
                    ""comment"": ""The elastic waistband and soft fabric make it ideal for active children. The fun, vibrant pattern makes it a standout piece in any wardrobe. Machine washable and low maintenance. Suitable for both casual and semi-formal occasions."",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""Comfort, Style, and Durability Combined in One Perfect Outfit"",
                    ""customerImage"": ""ProfileImage5.png"",
                    ""rating"": 3
                },
                {
                    ""customerName"": ""Alice"",
                    ""comment"": ""One of the best things about this dress is the fabric. It’s made from a lightweight, breathable material that feels soft against the skin. Even on hot days, it kept me cool and comfortable. "",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""Breathable Fabric and Exceptional Comfort for Everyday Wear"",
                    ""customerImage"": ""ProfileImage3.png"",
                    ""rating"": 3
                },
                {
                    ""customerName"": ""John"",
                    ""comment"": ""Absolutely love them! Can't stop wearing!"",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""A Product So Good That I Keep Reaching for It Every Day"",
                    ""customerImage"": ""ProfileImage1.png"",
                    ""rating"": 2
                },
                {
                    ""customerName"": ""Jade"",
                    ""comment"": ""These boots are very much comfortable for wearing."",
                    ""customerReviewImages"": [""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""These Comfortable Boots Make Daily Wear Effortless"",
                    ""customerImage"": ""ProfileImage6.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Rebacca"",
                    ""comment"": ""Absolutely love them! Can't stop wearing!"",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""Excellent Quality and Comfort That Surpassed Expectations"",
                    ""customerImage"": ""ProfileImage10.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Sophia"",
                    ""comment"": ""Happy purchasing!"",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""A Purchase That Delivered Great Value and Satisfaction"",
                    ""customerImage"": ""ProfileImage13.png"",
                    ""rating"": 4
                },
                {
                    ""customerName"": ""Julie"",
                    ""comment"": ""Happy buying!"",
                    ""customerReviewImages"": [ ""review1.png"", ""review2.png"",  ""review3.png"" ],
                    ""reviewTitle"": ""Reliable Quality and a Shopping Experience Worth Repeating"",
                    ""customerImage"": ""ProfileImage8.png"",
                    ""rating"": 4
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var feedbackRoot = JsonSerializer.Deserialize<FeedbackRoot>(jsonData, options);
            var customerImages = new List<string>() { "ProfileImage5.png", "ProfileImage3.png", "ProfileImage1.png", "ProfileImage6.png", "ProfileImage10.png", "ProfileImage13.png", "ProfileImage8.png" };
            var customerReviewImages = new List<string>()
                                        {
                                            "review1.png",
                                            "review2.png",
                                            "review3.png"
                                        };
            var reviewedDates = new List<string>() { "3/1/2024", "12/1/2024", "23/2/2024", "5/3/2024", "14/3/2024", "30/3/2024", "10/4/2024" };

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
