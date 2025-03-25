using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ProductDetailsViewModel
    {
        public Product? Product { get; set; }

        public ProductDetailsViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""name"": ""Full-Length Skirt"",
            ""summary"": ""This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days."",
            ""actualPrice"": 245,
            ""discountPercent"": 30,
            ""description"": ""Ankle-length skirt with high waistband. Lightweight, comfortable cotton construction with side zipper."",
            ""previewImages"": [
                ""Image1.png"",
                ""Image1.png"",
                ""Image1.png"",
                ""Image1.png"",
                ""Image1.png""
            ],
            ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ],
            ""detailPageReviews"": [
                {
                    ""profileimage"": ""ProfileImage10.png"",
                    ""customername"": ""Serina Williams"",
                    ""comment"": ""Greatest purchase I have ever made in my life."",
                    ""revieweddate"": ""29 Dec, 2019"",
                    ""rating"": 5,
                    ""images"": [
                        ""Image1.png"",
                        ""Image1.png"",
                        ""Image1.png"",
                        ""Image1.png""
                    ]
                },
                {
                    ""profileimage"": ""ProfileImage11.png"",
                    ""customername"": ""Alise Valasquez"",
                    ""comment"": ""Absolutely love them! Can't stop wearing!"",
                    ""revieweddate"": ""29 Dec, 2019"",
                    ""rating"": 3,
                    ""images"": [
                        ""Image1.png"",
                        ""Image1.png"",
                        ""Image1.png""
                    ]
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Product = JsonSerializer.Deserialize<Product>(jsonData, options);
            var previewImages = new List<string> { "Image1.png", "Image1.png", "Image1.png", "Image1.png", "Image1.png" };
            if (Product?.DetailPageReviews == null)
            {
                return;
            }

            Product.PreviewImages = previewImages;
            Product.DetailPageReviews[0].CustomerReviewImages = previewImages;
            Product.DetailPageReviews[1].CustomerReviewImages = previewImages;
            Product.DetailPageReviews[0].CustomerImage = "ProfileImage10.png";
            Product.DetailPageReviews[1].CustomerImage = "ProfileImage11.png";
        }
    }

    public class Product
    {
        private List<string>? previewImages;
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public decimal ActualPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string? Description { get; set; }
        public List<string>? PreviewImages
        {
            get
            {
                if (this.previewImages != null)
                {
                    for (var i = 0; i < this.previewImages.Count; i++)
                    {
                        this.previewImages[i] = this.previewImages[i].Contains(App.ImageServerPath) ? this.previewImages[i] : App.ImageServerPath + this.previewImages[i];
                    }
                }

                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
            }
        }

        public List<string>? SizeVariants { get; set; }
        public List<ProductDetailsModel>? DetailPageReviews { get; set; }
    }

    public class ProductDetailsModel
    {
        private string? customerImage;
        private List<string>? customerReviewImages;
        public string? ProfileImage { get; set; }
        public string? CustomerName { get; set; }
        public string? Comment { get; set; }
        public string? ReviewedDate { get; set; }
        public string CustomerImage
        {
            get { return App.ImageServerPath + this.customerImage; }
            set { this.customerImage = value; }
        }

        public List<string>? CustomerReviewImages
        {
            get
            {
                if (this.customerReviewImages != null)
                {
                    for (var i = 0; i < this.customerReviewImages.Count; i++)
                    {
                        this.customerReviewImages[i] = this.customerReviewImages[i].Contains(App.ImageServerPath) ? this.customerReviewImages[i] : App.ImageServerPath + this.customerReviewImages[i];
                    }
                }

                return this.customerReviewImages;
            }

            set
            {
                this.customerReviewImages = value;
            }
        }

        public int Rating { get; set; }
    }

}
