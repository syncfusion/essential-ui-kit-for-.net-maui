using System.Collections.ObjectModel;

namespace EssentialMAUIUIKit
{
    public class CategoryTileViewModel
    {
        public ObservableCollection<CategoryTile> Categories { get; set; }

        public CategoryTileViewModel()
        {
            // Load the JSON data
            Categories = new ObservableCollection<CategoryTile>
            {
                new CategoryTile
                {
                    Icon = "Electronics.png",
                    Name = "Electronics",
                    SubCategories = new List<string>
                    {
                        "Laptops",
                        "Mobiles",
                        "Tablets",
                        "Televisions",
                        "Printers and Monitors"
                    }
                },
                new CategoryTile
                {
                    Icon = "Fashion.png",
                    Name = "Fashion",
                    SubCategories = new List<string>
                    {
                        "Shirts",
                        "Skirts",
                        "Casual Wear",
                        "Jeans",
                        "Kurtis"
                    }
                },
                new CategoryTile
                {
                    Icon = "HomeFurniture.png",
                    Name = "Home and Furniture",
                    SubCategories = new List<string>
                    {
                        "Diwans",
                        "Sofas",
                        "Curtains"
                    }
                },
                new CategoryTile
                {
                    Icon = "PersonalCare.png",
                    Name = "Personal Care",
                    SubCategories = new List<string>
                    {
                        "Skin Care",
                        "Hair Care",
                        "Oral Care",
                        "Fragrances",
                        "Personal Hygiene"
                    }
                },
                new CategoryTile
                {
                    Icon = "Books.png",
                    Name = "Books",
                    SubCategories = new List<string>
                    {
                        "Fiction",
                        "Non-Fiction",
                        "Children's Books",
                        "Educational",
                        "Comics"
                    }
                },
                new CategoryTile
                {
                    Icon = "Clothes.png",
                    Name = "Clothes",
                    SubCategories = new List<string>
                    {
                        "Men's Clothing",
                        "Women's Clothing",
                        "Kids' Clothing",
                        "Sportswear",
                        "Innerwear"
                    }
                },
                new CategoryTile
                {
                    Icon = "MobilePhones.png",
                    Name = "Mobile Phones",
                    SubCategories = new List<string>
                    {
                        "Smartphones",
                        "Feature Phones",
                        "Mobile Accessories",
                        "Tablets",
                        "Wearable Technology"
                    }
                },
                new CategoryTile
                {
                    Icon = "Accessories.png",
                    Name = "Accessories",
                    SubCategories = new List<string>
                    {
                        "Watches",
                        "Jewellery",
                        "Bags",
                        "Sunglasses",
                        "Belts"
                    }
                },
                new CategoryTile
                {
                    Icon = "Toys.png",
                    Name = "Toys and Baby",
                    SubCategories = new List<string>
                    {
                        "Baby Care",
                        "Soft Toys",
                        "Educational Toys",
                        "Action Figures",
                        "Outdoor Play"
                    }
                }
            };
        }
    }

    public class CategoryTile
    {
        private string? icon;
        public string Icon
        {
            get { return App.ImageServerPath + icon; }
            set { icon = value; }
        }

        public string? Name { get; set; }
        public List<string>? SubCategories { get; set; }
    }

    public class CategoryTilesRoot
    {
        public List<CategoryTile>? Categories { get; set; }
    }
}
