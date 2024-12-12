using System.Collections.ObjectModel;

namespace EssentialMAUIUIKit
{
    public class CategoryTileViewModel
    {
        public ObservableCollection<CategoryItem> Categories { get; set; }

        public CategoryTileViewModel()
        {
            // Load the JSON data
            Categories = new ObservableCollection<CategoryItem>
            {
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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
                new CategoryItem
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

    public class CategoryItem
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
        public List<CategoryItem>? Categories { get; set; }
    }
}
