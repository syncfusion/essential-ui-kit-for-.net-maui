using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit.Models
{
    /// <summary>
    /// Model for pages with product.
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        #region Fields

        private bool isFavourite;

        private string? previewImage;

        private List<string>? previewImages;

        private int totalQuantity;

        private double actualPrice;

        private double discountPrice;

        private double discountPercent;

        private ObservableCollection<Review> reviews = new ObservableCollection<Review>();

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that holds the product id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the product image.
        /// </summary>
        public string PreviewImage
        {
            get { return App.ImageServerPath + this.previewImage; }
            set { this.previewImage = value; }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfRotator, which displays the item images.
        /// </summary>
        public List<string>? PreviewImages
        {
            get
            {
                for (var i = 0; i < this.previewImages?.Count; i++)
                {
                    this.previewImages[i] = this.previewImages[i].Contains(App.ImageServerPath) ? this.previewImages[i] : App.ImageServerPath + this.previewImages[i];
                }

                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product summary.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the actual price of the product.
        /// </summary>
        public double ActualPrice
        {
            get
            {
                return this.actualPrice;
            }

            set
            {
                this.actualPrice = value;
                this.NotifyPropertyChanged(nameof(this.ActualPrice));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the discounted price of the product.
        /// </summary>
        public double DiscountPrice
        {
            get
            {
                return this.ActualPrice - (this.ActualPrice * ((this.DiscountPercent) / 100));
            }

            set
            {
                this.discountPrice = value;
                this.NotifyPropertyChanged(nameof(this.DiscountPrice));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the discounted percent of the product.
        /// </summary>
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }

            set
            {
                this.discountPercent = value;
                this.NotifyPropertyChanged(nameof(this.DiscountPercent));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the overall rating of the product.
        /// </summary>
        public double OverallRating { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the customer review.
        /// </summary>
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
                this.NotifyPropertyChanged(nameof(this.Reviews));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the seller.
        /// </summary>
        public string? SellerName { get; set; }

        /// <summary>
        /// Gets or sets the property has been bound with SfCombobox which displays selected quantity of product.
        /// </summary>
        public List<object> Quantities { get; set; } = new List<object> { 1, 2, 3, 4, 5 };

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the product variants.
        /// </summary>
        public List<string> SizeVariants { get; set; } = new List<string> { "XS", "S", "M", "L", "XL" };

        /// <summary>
        /// Gets or sets a value indicating whether the cart is favorite.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged(nameof(this.IsFavourite));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the total quantity.
        /// </summary>
        public int TotalQuantity
        {
            get
            {
                return this.totalQuantity;
            }

            set
            {
                this.totalQuantity = value;
                this.NotifyPropertyChanged(nameof(this.TotalQuantity));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}