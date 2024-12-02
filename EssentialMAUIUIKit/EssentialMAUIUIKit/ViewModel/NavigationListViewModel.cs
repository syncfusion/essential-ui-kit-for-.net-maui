using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class NavigationListViewModel
    {
        public ObservableCollection<NavigationItem> NavigationList { get; set; }

        public NavigationListViewModel()
        {
            NavigationList = new ObservableCollection<NavigationItem>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""navigationList"": [
                {
                    ""itemName"": ""Hamburger"",
                    ""name"": ""Burger King"",
                    ""description"": ""Burger, Pizza"",
                    ""itemDescription"": ""Classic hamburger with Angus beef grilled to perfection"",
                    ""itemImage"": ""Recipe19.png"",
                    ""offer"": ""40% OFF - Use code OFF40"",
                    ""itemRating"": 4.5
                },
                {
                    ""itemName"": ""Black Bean Burger"",
                    ""itemDescription"": ""Our signature black bean burger on a whole-grain bun"",
                    ""itemImage"": ""Recipe8.png"",
                    ""name"": ""McDonalds"",
                    ""description"": ""Burger, Fast Food"",
                    ""offer"": ""60% OFF - Use code OFF60"",
                    ""itemRating"": 4.4
                },
                {
                    ""itemName"": ""Macarons"",
                    ""itemDescription"": ""Eight colorful flavors of macarons, fresh daily"",
                    ""itemImage"": ""Recipe3.png"",
                    ""name"": ""Macrons"",
                    ""description"": ""Cafe, Beverages"",
                    ""offer"": ""50% OFF - Use code OFF50"",
                    ""itemRating"": 4.2
                },
                {
                    ""itemName"": ""Egg on Toast"",
                    ""itemDescription"": ""A sunny-side up egg on toast, just like grandma used to make"",
                    ""itemImage"": ""Recipe9.png"",
                    ""name"": ""Kings Kitchen"",
                    ""description"": ""North Indian, Chinese, Sushi"",
                    ""offer"": ""40% OFF - Use code OFF40"",
                    ""itemRating"": 4.5
                },
                {
                    ""itemName"": ""Chocolate Caramel Cake"",
                    ""itemDescription"": ""Rich dark chocolate cake layered with caramel icing"",
                    ""itemImage"": ""Recipe13.png"",
                    ""name"": ""Chai Wale"",
                    ""description"": ""Cafe, Beverages, Fast Food"",
                    ""offer"": ""50% OFF - Use code OFF50"",
                    ""itemRating"": 4.6
                },
                {
                    ""itemName"": ""Red Velvet Cake"",
                    ""itemDescription"": ""Classic red velvet cake with rich, cream cheese frosting and dark chocolate shavings"",
                    ""itemImage"": ""Recipe4.png"",
                    ""name"": ""Krispy Kreme"",
                    ""description"": ""Desserts, Beverages"",
                    ""offer"": ""60% OFF - Use code OFF60"",
                    ""itemRating"": 4.2
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<NavigationData>(jsonData, options);
            var images = new List<string>() { "Recipe19.png", "Recipe8.png", "Recipe3.png", "Recipe9.png", "Recipe13.png", "Recipe4.png" };
            if (data?.NavigationList == null)
            {
                return;
            }

            for (int i = 0; i < data.NavigationList.Count; i++)
            {
                data.NavigationList[i].ItemImage = images[i];
                NavigationList.Add(data.NavigationList[i]);
            }
        }
    }

    public class NavigationItem
    {
        private string? itemImage;
        public string? ItemName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ItemDescription { get; set; }
        public string ItemImage
        {
            get { return App.ImageServerPath + this.itemImage; }
            set { this.itemImage = value; }
        }

        public string? Offer { get; set; }
        public double? ItemRating { get; set; }
    }

    public class NavigationData
    {
        public List<NavigationItem>? NavigationList { get; set; }
    }

}
