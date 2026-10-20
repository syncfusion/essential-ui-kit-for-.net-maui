using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class CartPageViewModel
    {
        public List<EssentialMAUIUIKit.Models.Product> Products { get; set; }

        public CartPageViewModel()
        {
            Products = new List<EssentialMAUIUIKit.Models.Product>();
            LoadFromJson();
        }

        // Method to load data from JSON
        public void LoadFromJson()
        {
            string jsonData = @"
{
    ""products"": [
  {
    ""id"": 1,
    ""previewimage"": ""Image1.png"",
    ""name"": ""Full-Length Skirt"",
    ""summary"": ""Plaid cotton skirt for cooler days."",
    ""description"": ""Plaid cotton skirt for cooler days."",
    ""actualprice"": 90,
    ""discountpercent"": 15,
    ""overallrating"": 5,
    ""previewimages"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
    ""reviews"": [
      {
        ""profileimage"": ""ProfileImage10.png"",
        ""customername"": ""Serina Williams"",
        ""comment"": ""Greatest purchase I have ever made in my life."",
        ""rating"": 5,
        ""images"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
        ""revieweddate"": ""2019-12-29""
      },
      {
        ""profileimage"": ""ProfileImage11.png"",
        ""customername"": ""Alise Valasquez"",
        ""comment"": ""Absolutely love them! Can't stop wearing!"",
        ""rating"": 5,
        ""images"": [ ""Image1.png"", ""Image1.png"", ""Image1.png"" ],
        ""revieweddate"": ""2019-12-29""
      }
    ],
    ""quantities"": [ ""1"", ""2"", ""3"" ],
    ""totalquantity"": 0,
    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
  },
  {
    ""id"": 2,
    ""previewimage"": ""Image2.png"",
    ""name"": ""Peasant Blouse"",
    ""summary"": ""V-neck pleated blouse with full sleeves."",
    ""description"": ""V-neck pleated blouse with full sleeves."",
    ""actualprice"": 95,
    ""discountpercent"": 15,
    ""overallrating"": 4,
    ""previewimages"": [ ""Image2.png"", ""Image2.png"", ""Image2.png"", ""Image2.png"", ""Image2.png"" ],
    ""reviews"": [],
    ""quantities"": [ ""1"", ""2"", ""3"" ],
    ""totalquantity"": 0,
    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
  },
  {
    ""id"": 3,
    ""previewimage"": ""Image3.png"",
    ""name"": ""High-Waisted Skirt"",
    ""summary"": ""Cotton skirt in khaki, taupe, gray."",
    ""description"": ""Cotton skirt in khaki, taupe, gray."",
    ""actualprice"": 98,
    ""discountpercent"": 15,
    ""overallrating"": 5,
    ""previewimages"": [ ""Image3.png"", ""Image3.png"", ""Image3.png"", ""Image3.png"", ""Image3.png"" ],
    ""reviews"": [],
    ""quantities"": [ ""1"", ""2"", ""3"" ],
    ""totalquantity"": 0,
    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
  },
  {
    ""id"": 4,
    ""previewimage"": ""Image4.png"",
    ""name"": ""Leather Backpack"",
    ""summary"": ""Mini pack with adjustable straps."",
    ""description"": ""Mini pack with adjustable straps."",
    ""actualprice"": 99,
    ""discountpercent"": 15,
    ""overallrating"": 4,
    ""previewimages"": [ ""Image4.png"", ""Image4.png"", ""Image4.png"", ""Image4.png"", ""Image4.png"" ],
    ""reviews"": [],
    ""quantities"": [ ""1"", ""2"", ""3"" ],
    ""totalquantity"": 0,
    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
  },
  {
    ""id"": 5,
    ""previewimage"": ""Image5.png"",
    ""name"": ""Sweetheart Dress"",
    ""summary"": ""Bold red dress with 3/4 sleeves."",
    ""description"": ""Bold red dress with 3/4 sleeves."",
    ""actualprice"": 90,
    ""discountpercent"": 15,
    ""overallrating"": 5,
    ""previewimages"": [ ""Image5.png"", ""Image5.png"", ""Image5.png"", ""Image5.png"", ""Image5.png"" ],
    ""quantities"": [ ""1"", ""2"", ""3"" ],
    ""totalquantity"": 0,
    ""sizevariants"": [ ""XS"", ""S"", ""M"", ""L"", ""XL"" ]
  }
]
}";
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<Dictionary<string, ObservableCollection<EssentialMAUIUIKit.Models.Product>>>(jsonData, options);
            if (data == null || !data.TryGetValue("products", out var products) || products == null)
            {
                return;
            }

            var previewImages = new List<string> { "Image1.png", "Image2.png", "Image3.png", "Image4.png", "Image5.png" };
            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                if (i < previewImages.Count)
                {
                    product.PreviewImage = previewImages[i];
                }

                Products.Add(product);
            }
        }
    }
}
