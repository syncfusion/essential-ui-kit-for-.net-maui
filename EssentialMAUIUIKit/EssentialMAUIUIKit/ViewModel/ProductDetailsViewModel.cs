using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ProductDetailsViewModel : INotifyPropertyChanged
    {
        public Product? Product { get; set; }

        public ProductImage? ProductImage { get; set; }

        public ProductDetailsViewModel()
        {
            LoadData();

            Product!.PreviewImages = new ObservableCollection<ProductImage>()
            {
                new ProductImage { ImagePath = App.ImageServerPath + "Image1.png", IsSelected = true },
                new ProductImage { ImagePath = App.ImageServerPath + "Image1.png" },
                new ProductImage { ImagePath = App.ImageServerPath + "Image1.png" },
                new ProductImage { ImagePath = App.ImageServerPath + "Image1.png" },
                new ProductImage { ImagePath = App.ImageServerPath + "Image1.png" },
            };

            AvailableSizes = new ObservableCollection<SizeItem>
            {
                new() { Name = "XS", IsSelected = false },
                new() { Name = "S", IsSelected = false },
                new() { Name = "M", IsSelected = true },
                new() { Name = "L", IsSelected = false },
                new() { Name = "XL", IsSelected = false }
            };

            // The SfChipGroup owns selection state via its
            // SelectedItem property (bound below). When SelectedSize
            // changes, the setter flips IsSelected on the affected
            // SizeItem instances so the DataTrigger in SizeChipStyle
            // can re-paint the stroke (the one thing the group does
            // not expose a SelectedChip* property for).
            SelectedSize = AvailableSizes[2]; // Pre-select "M"
        }

        public ObservableCollection<SizeItem> AvailableSizes { get; }

        private SizeItem? selectedSize;
        public SizeItem? SelectedSize
        {
            get => selectedSize;
            set
            {
                if (selectedSize != value)
                {
                    // Clear the previous selection so the trigger
                    // on the previously selected chip reverts the
                    // stroke back to the unselected colour.
                    if (selectedSize != null)
                    {
                        selectedSize.IsSelected = false;
                    }

                    selectedSize = value;

                    // Mark the newly selected item so the trigger
                    // applies the selected stroke.
                    if (selectedSize != null)
                    {
                        selectedSize.IsSelected = true;
                    }

                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            var previewImages = new List<string> { "Image1.png", "Image1.png", "Image1.png", "Image1.png", "Image1.png", "Image1.png" };
            if (Product?.DetailPageReviews == null)
            {
                return;
            }

            Product.DetailPageReviews[0].CustomerReviewImages = previewImages;
            Product.DetailPageReviews[1].CustomerReviewImages = previewImages;
            Product.DetailPageReviews[0].CustomerImage = "ProfileImage10.png";
            Product.DetailPageReviews[1].CustomerImage = "ProfileImage11.png";
        }
    }

    public class ProductImage : INotifyPropertyChanged
    {
        public string? ImagePath { get; set; }

        private bool isSelected; 
        
        private bool isFavourite;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether the product is marked as favourite.
        /// Used by the Favourite icon button on the product detail page to swap the
        /// outline glyph for a filled glyph (and primary colour) when tapped.
        /// </summary>
        public bool IsFavourite
        {
            get => isFavourite;
            set
            {
                if (isFavourite != value)
                {
                    isFavourite = value;
                    OnPropertyChanged(nameof(IsFavourite));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class Product : INotifyPropertyChanged
    {
        public string? Name { get; set; }
        public string? Summary { get; set; }
        public decimal ActualPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<ProductImage>? PreviewImages { get; set; }

        public List<ProductDetailsModel>? DetailPageReviews { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class SizeItem : INotifyPropertyChanged
    {
        private string? name;
        public string? Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public string? Text
        {
            get => Name;
            set => Name = value;
        }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
