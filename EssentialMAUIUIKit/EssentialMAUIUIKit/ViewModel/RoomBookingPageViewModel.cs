using EssentialMAUIUIKit.ViewModel;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    public class RoomBookingPageViewModel : BaseViewModel
    {
        #region Fields

        private readonly double productRating = 0d;

        private RoomDetail? roomDetail;

        private ObservableCollection<RoomBookingReview> reviews;

        private List<RoomDetail> facilities;

        private List<RoomDetail> previewImages;

        private bool isReviewVisible;

        private bool isFavourite;

        private string? mapMarkerLatitude;

        private string? mapMarkerLongitude;

        private string? mapMarkerImage;

        private List<RoomDetail>? guestsCollection;

        private List<RoomDetail>? bedsCollection;

        private Point geoCoordinate;

        private bool isDropDownOpen;

        private string? selectionChangedCommand;

        private ObservableCollection<object>? calender;

        private int selectedIndex;

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command is executed when the book button is clicked.
        /// </summary>
        private Command? bookCommand;

        /// <summary>
        /// Gets or sets the command is executed when the  selection button is clicked.
        /// </summary>
        private Command? selectionCommand;

        /// <summary>
        /// Gets or sets the command is executed when the more button is clicked.
        /// </summary>
        private Command? moreCommand;

        /// <summary>
        /// Gets or sets the command is executed when the  showAll button is clicked.
        /// </summary>
        private Command? showAllCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="RoomBookingPageViewModel" /> class.
        /// </summary>
        public RoomBookingPageViewModel()
        {
            this.OnSelectionChanged = new Command<SelectionChangedEventArgs>(this.SelectionChanged);

            this.GuestCommand = new Command(this.GuestSelectionChanged);

            this.BedCommand = new Command(this.BedSelectionChanged);

            this.FavouriteCommand = new Command(this.FavouriteButtonClicked);

            this.Calender = new ObservableCollection<object>() { "i" };

            this.previewImages = new List<RoomDetail>()
            {
                new RoomDetail { ImagePath = "HotelImage1.png" },
                new RoomDetail { ImagePath = "HotelImage2.jpeg" },
                new RoomDetail { ImagePath = "HotelImage3.jpeg" },
                new RoomDetail { ImagePath = "HotelImage4.jpeg" },
                new RoomDetail { ImagePath = "HotelImage5.jpeg" },
                new RoomDetail { ImagePath = "HotelImage6.jpeg" },
            };

            this.facilities = new List<RoomDetail>()
            {
               new RoomDetail
               {
                   Icon = "\ue704",
                   Facility = "Wi-Fi",
               },
               new RoomDetail
               {
                   Icon = "\ue74e",
                   Facility = "Kitchen",
               },
               new RoomDetail
               {
                   Icon = "\ue740",
                   Facility = "Parking",
               },
               new RoomDetail
               {
                   Icon = "\ue74c",
                   Facility = "Gym",
               },
            };

            this.reviews = new ObservableCollection<RoomBookingReview>
            {
                new RoomBookingReview
                {
                    CustomerImage = "ProfileImage10.png",
                    CustomerName = "Jane Deo",
                    Comment = "Great Resort, excellent hospitality!",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    CustomerReviewImages = new List<string>
                    {
                        "HotelImage1.png",
                        "HotelImage4.jpeg",
                        "HotelImage6.jpeg",
                    },
                },
                new RoomBookingReview
                {
                    CustomerImage = "ProfileImage11.png",
                    CustomerName = "Alise Valasquez",
                    Comment = "Best resort on the planet. LOVE our visits there.",
                    ReviewedDate = "29 Dec, 2019",
                    Rating = 5,
                    CustomerReviewImages = new List<string>
                    {
                       "HotelImage2.jpeg",
                       "HotelImage3.jpeg",
                       "HotelImage7.jpeg",
                    },
                },
            };

            this.BedsCollection = new List<RoomDetail>()
            {
                new RoomDetail { DisplayText = "1 Bed", ValueText = 1 },
                new RoomDetail { DisplayText = "2 Beds", ValueText = 2 },
                new RoomDetail { DisplayText = "3 Beds", ValueText = 3 },
            };

            this.GuestsCollection = new List<RoomDetail>()
            {
                new RoomDetail { DisplayText = "1 Guest", ValueText = 1 },
                new RoomDetail { DisplayText = "2 Guests", ValueText = 2 },
                new RoomDetail { DisplayText = "3 Guests", ValueText = 3 },
            };
            this.MapMarkerImage = "pin.png";
            this.MapMarkerLatitude = "40.133808";
            this.MapMarkerLongitude = "-75.516279";
            this.GetPinLocation();

            this.RoomDetail = new RoomDetail
            {
                Name = "Modern Resort",
                OverallRating = 5,
                TotalReviews = "534 Reviews",
                ResortDescription = "A charming oceanfront resort with 38 hotel rooms, studios, and suites, most with a balcony and jacuzzi, located on the turquoise water of the Atlantic Ocean.",
                Address = "7654 Cleveland Street, Phoenixville, PA 19460",
                PhoneNumber = "+1 202-555-0101",
                Cost = 30,
                TotalDays = 1,
                Reviews = this.reviews,
            };

            if (this.RoomDetail.Reviews == null || this.RoomDetail.Reviews.Count == 0)
            {
                this.IsReviewVisible = true;
            }
            else
            {
                foreach (var review in this.RoomDetail.Reviews)
                {
                   // this.productRating += review.Rating;
                }
            }

            if (this.productRating > 0 && this.RoomDetail.Reviews != null)
            {
                this.RoomDetail.OverallRating = this.productRating / this.RoomDetail.Reviews.Count;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that has been bound with icon and labels, which display the resort details.
        /// </summary>
        public RoomDetail? RoomDetail
        {
            get
            {
                return this.roomDetail;
            }

            set
            {
                if (this.roomDetail == value)
                {
                    return;
                }

                this.SetProperty(ref this.roomDetail, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the review is visible or not.
        /// </summary>
        public bool IsReviewVisible
        {
            get
            {
                if (this.RoomDetail?.Reviews.Count == 0)
                {
                    this.isReviewVisible = true;
                }

                return this.isReviewVisible;
            }

            set
            {
                this.SetProperty(ref this.isReviewVisible, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the room is favourite or not.
        /// </summary>
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.SetProperty(ref this.isFavourite, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker latitude.
        /// </summary>
        public string? MapMarkerLatitude
        {
            get
            {
                return this.mapMarkerLatitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLatitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value of map marker longitude.
        /// </summary>
        public string? MapMarkerLongitude
        {
            get
            {
                return this.mapMarkerLongitude;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerLongitude, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for map marker template image.
        /// </summary>
        public string? MapMarkerImage
        {
            get
            {
                return this.mapMarkerImage;
            }

            set
            {
                this.SetProperty(ref this.mapMarkerImage, value);
            }
        }

        /// <summary>
        /// Gets the beds collection.
        /// </summary>
        public ObservableCollection<object>? Calender
        {
            get
            {
                return this.calender;
            }

            private set
            {
                this.SetProperty(ref this.calender, value);
            }
        }

        /// <summary>
        /// Gets the facilities items collection.
        /// </summary>
        public List<RoomDetail> Facilities
        {
            get
            {
                return this.facilities;
            }

            private set
            {
                this.SetProperty(ref this.facilities, value);
            }
        }

        /// <summary>
        /// Gets the previewImages collection.
        /// </summary>
        public List<RoomDetail> PreviewImages
        {
            get
            {
                return this.previewImages;
            }

            private set
            {
                this.SetProperty(ref this.previewImages, value);
            }
        }

        /// <summary>
        /// Gets the beds collection.
        /// </summary>
        public List<RoomDetail>? BedsCollection
        {
            get
            {
                return this.bedsCollection;
            }

            private set
            {
                this.SetProperty(ref this.bedsCollection, value);
            }
        }

        /// <summary>
        /// Gets the guests collection.
        /// </summary>
        public List<RoomDetail>? GuestsCollection
        {
            get
            {
                return this.guestsCollection;
            }

            private set
            {
                this.SetProperty(ref this.guestsCollection, value);
            }
        }

        /// <summary>
        /// Gets or sets the geo coordinate.
        /// </summary>
        public Point GeoCoordinate
        {
            get
            {
                return this.geoCoordinate;
            }

            set
            {
                this.SetProperty(ref this.geoCoordinate, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the drop down is open or not.
        /// </summary>
        public bool IsDropDownOpen
        {
            get
            {
                return this.isDropDownOpen;
            }

            set
            {
                this.SetProperty(ref this.isDropDownOpen, value);
            }
        }

        /// <summary>
        /// Gets or sets the carusel view swipe item index.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                if (this.selectedIndex == value)
                {
                    return;
                }

                this.SetProperty(ref this.selectedIndex, value);
            }
        }

        /// <summary>
        /// Gets or sets the SelectionChangedCommand.
        /// </summary>
        public string? SelectionChangedCommand
        {
            get { return this.selectionChangedCommand; }
            set { this.selectionChangedCommand = value; }
        }

        /// <summary>
        /// Gets the command that will be executed when an book button is selected.
        /// </summary>
        public Command BookCommand
        {
            get
            {
                return this.bookCommand ?? (this.bookCommand = new Command(this.BookClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an book button is selected.
        /// </summary>
        public Command SelectionCommand
        {
            get
            {
                return this.selectionCommand ?? (this.selectionCommand = new Command(this.SelectionClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an more button is selected.
        /// </summary>
        public Command MoreCommand
        {
            get
            {
                return this.moreCommand ?? (this.moreCommand = new Command(this.MoreClicked));
            }
        }

        /// <summary>
        /// Gets the command that will be executed when an more button is selected.
        /// </summary>
        public Command ShowAllCommand
        {
            get
            {
                return this.showAllCommand ?? (this.showAllCommand = new Command(this.ShowAllClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command is executed when the combo box is clicked for guest.
        /// </summary>
        public Command GuestCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the combo box is clicked for bed.
        /// </summary>
        public Command BedCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the calender is clicked.
        /// </summary>
        public ICommand OnSelectionChanged { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand { get; set; }

        #endregion

        #region Methods
        private void GetPinLocation()
        {
            this.GeoCoordinate = new Point(Convert.ToDouble(this.MapMarkerLatitude, CultureInfo.CurrentCulture), Convert.ToDouble(this.MapMarkerLongitude, CultureInfo.CurrentCulture));
        }

        private void SelectionChanged(SelectionChangedEventArgs e)
        {
        }

        private void GuestSelectionChanged(object obj)
        {
            // Do your command action
        }

        private void BedSelectionChanged(object obj)
        {
            // Do your command action
        }

        private void FavouriteButtonClicked(object obj)
        {
            if (obj != null && (obj is RoomBookingPageViewModel))
            {
                RoomBookingPageViewModel? roomBookingPageViewModel = obj as RoomBookingPageViewModel;
                if (roomBookingPageViewModel != null)
                {
                    roomBookingPageViewModel.IsFavourite = roomBookingPageViewModel.IsFavourite ? false : true;
                }
            }
        }



        /// <summary>
        /// Invoked when the book button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void BookClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when carousel view item is swiped.
        /// </summary>
        /// <param name="obj">The rotator item</param>
        private void SelectionClicked(object obj)
        {
            //this.SelectedIndex = this.PreviewImages.IndexOf(obj);
        }

        /// <summary>
        /// Invoked when the more button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MoreClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the show all button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ShowAllClicked(object obj)
        {
            // Do something
        }

        #endregion
    }

    public class RoomDetail : BaseViewModel
    {
        #region Fields

        private string? imagePath;

        private int cost;

        private string? selectedRanges = $"{DateTime.Now:dd MMM yyyy} - {DateTime.Now.AddDays(2):dd MMM yyy}";

        private IReadOnlyCollection<RoomBookingReview> reviews = new ObservableCollection<RoomBookingReview>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the selected ranges 
        /// </summary>
        public string? SelectedRanges
        {
            get
            {
                return this.selectedRanges;
            }

            set
            {
                this.SetProperty(ref this.selectedRanges, value);
            }
        }

        /// <summary>
        /// Gets or sets the cost of resort.
        /// </summary>
        public int Cost
        {
            get
            {
                return this.cost;
            }

            set
            {
                this.SetProperty(ref this.cost, value);
            }
        }

        /// <summary>
        /// Gets or sets the total days.
        /// </summary>
        public int TotalDays { get; set; }

        /// <summary>
        /// Gets or sets the name of the resort.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the display text.
        /// </summary>
        public string? DisplayText { get; set; }

        /// <summary>
        /// Gets or sets the value text.
        /// </summary>
        public int ValueText { get; set; }

        /// <summary>
        /// Gets or sets the description of the resort.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the overall of the resort.
        /// </summary>
        public double OverallRating { get; set; }

        /// <summary>
        /// Gets or sets the reviews of the resort.
        /// </summary>
        public string? TotalReviews { get; set; }

        /// <summary>
        /// Gets or sets the resort description.
        /// </summary>
        public string? ResortDescription { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets the facility of resort.
        /// </summary>
        public string? Facility { get; set; }

        /// <summary>
        /// Gets or sets the count of bed.
        /// </summary>
        public ReadOnlyCollection<string>? BedCount { get; set; }

        /// <summary>
        /// Gets or sets the addresss of the resort.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the resort.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the property that bounds with a date picker .
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the review of the customers .
        /// </summary>
        public IReadOnlyCollection<RoomBookingReview> Reviews
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

        #endregion    
    }

    public class RoomBookingReview
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
