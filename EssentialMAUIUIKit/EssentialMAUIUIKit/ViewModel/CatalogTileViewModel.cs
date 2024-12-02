using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class CatalogTileViewModel
    {
        public ObservableCollection<CatalogProductInfo> Products { get; set; }

        public CatalogTileViewModel()
        {
            Products = new ObservableCollection<CatalogProductInfo>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""products"": [
                {
                    ""id"": ""1"",
                    ""previewimage"": ""Image1.png"",
                    ""name"": ""Full-Length Skirt"",
                    ""summary"": ""This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days."",
                    ""description"": ""This plaid, cotton skirt will keep you warm in the air-conditioned office or outside on cooler days."",
                    ""actualprice"": ""220"",
                    ""discountpercent"": ""15"",
                    ""overallrating"": ""5"",
                    ""previewimages"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
                    ""reviews"": [
                        {
                            ""profileimage"": ""ProfileImage10.png"",
                            ""customername"": ""Serina Williams"",
                            ""comment"": ""Greatest purchase I have ever made in my life."",
                            ""rating"": ""5"",
                            ""images"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
                            ""revieweddate"": ""2019-12-29""
                        },
                        {
                            ""profileimage"": ""ProfileImage11.png"",
                            ""customername"": ""Alise Valasquez"",
                            ""comment"": ""Absolutely love them! Can't stop wearing!"",
                            ""rating"": ""5"",
                            ""images"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
                            ""revieweddate"": ""2019-12-29""
                        }
                    ],
                    ""quantities"": [ ""1"", ""2"", ""3"" ],
                    ""totalquantity"": 0,
                    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
                },
                {
                    ""id"": ""2"",
                    ""previewimage"": ""Image2.png"",
                    ""name"": ""Peasant Blouse"",
                    ""summary"": ""Look your best this fall in this V-neck, pleated peasant blouse with full sleeves. Comes in white, chocolate, forest green, and more."",
                    ""description"": ""Look your best this fall in this V-neck, pleated peasant blouse with full sleeves. Comes in white, chocolate, forest green, and more."",
                    ""actualprice"": ""285"",
                    ""discountpercent"": ""30"",
                    ""overallrating"": ""4"",
                    ""previewimages"": [ ""Image2.png"", ""Image2.png"", ""Image2.png"", ""Image2.png"", ""Image2.png"" ],
                    ""reviews"": [],
                    ""quantities"": [ ""1"", ""2"", ""3"" ],
                    ""totalquantity"": 0,
                    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
                },
                {
                    ""id"": ""3"",
                    ""previewimage"": ""Image3.png"",
                    ""name"": ""High-Waisted Skirt"",
                    ""summary"": ""Available in khaki, taupe, and dove gray, this high-waisted, cotton skirt hits just below the knees."",
                    ""description"": ""Available in khaki, taupe, and dove gray, this high-waisted, cotton skirt hits just below the knees."",
                    ""actualprice"": ""220"",
                    ""discountpercent"": ""15"",
                    ""overallrating"": ""5"",
                    ""previewimages"": [ ""Image3.png"", ""Image3.png"", ""Image3.png"", ""Image3.png"", ""Image3.png"" ],
                    ""reviews"": [],
                    ""quantities"": [ ""1"", ""2"", ""3"" ],
                    ""totalquantity"": 0,
                    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
                },
                {
                    ""id"": ""4"",
                    ""previewimage"": ""Image4.png"",
                    ""name"": ""Leather Backpack"",
                    ""summary"": ""This cute miniature pack has adjustable straps, allowing it to be carried on your back, or as a purse. The genuine leather comes in cream, black, mahogany, and wine."",
                    ""description"": ""This cute miniature pack has adjustable straps, allowing it to be carried on your back, or as a purse. The genuine leather comes in cream, black, mahogany, and wine."",
                    ""actualprice"": ""285"",
                    ""discountpercent"": ""30"",
                    ""overallrating"": ""4"",
                    ""previewimages"": [ ""Image4.png"", ""Image4.png"", ""Image4.png"", ""Image4.png"", ""Image4.png"" ],
                    ""reviews"": [],
                    ""quantities"": [ ""1"", ""2"", ""3"" ],
                    ""totalquantity"": 0,
                    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
                },
                {
                    ""id"": ""5"",
                    ""previewimage"": ""Image5.png"",
                    ""name"": ""Sweetheart Dress"",
                    ""summary"": ""Be bold in red with this fashionable, yet comfortable dress. Three-quarter-length sleeves are perfect for the in-between weather of autumn."",
                    ""description"": ""Be bold in red with this fashionable, yet comfortable dress. Three-quarter-length sleeves are perfect for the in-between weather of autumn."",
                    ""actualprice"": ""220"",
                    ""discountpercent"": ""15"",
                    ""overallrating"": ""5"",
                    ""previewimages"": [ ""Image5.png"", ""Image5.png"", ""Image5.png"", ""Image5.png"", ""Image5.png"" ],
                    ""reviews"": [],
                    ""quantities"": [ ""1"", ""2"", ""3"" ],
                    ""totalquantity"": 0,
                    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ProductData>(jsonData, options);
            if (data?.Products == null)
            {
                return;
            }

            foreach (var product in data.Products)
            {
                Products.Add(product);
            }
        }
    }

    public class CatalogProductInfo
    {
        public string? Id { get; set; }
        public string? PreviewImage { get; set; }
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ActualPrice { get; set; }
        public string? DiscountPercent { get; set; }
        public string? OverallRating { get; set; }
        public List<string>? PreviewImages { get; set; }
        public List<CatelogTileReview>? Reviews { get; set; }
        public List<string>? Quantities { get; set; }
        public int TotalQuantity { get; set; }
        public List<string>? SizeVariants { get; set; }
    }

    public class ProductData
    {
        public List<CatalogProductInfo>? Products { get; set; }
    }

    public class CatelogTileReview
    {
        public string? ProfileImage { get; set; }
        public string? CustomerName { get; set; }
        public string? Comment { get; set; }
        public string? ReviewedDate { get; set; }
        public string? CustomerImage { get; set; }
        public List<string>? CustomerReviewImages { get; set; }
        public string? Rating { get; set; }
    }

}
