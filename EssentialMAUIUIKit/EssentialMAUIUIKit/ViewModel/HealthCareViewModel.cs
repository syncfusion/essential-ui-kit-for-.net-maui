using EssentialMAUIUIKit.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit
{
    public class HealthCareViewModel : BaseViewModel
    {
        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare>? healthCareCardItems;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare>? healthCareListItems;

        /// <summary>
        /// To store the heart rate data collection.
        /// </summary>
        private ObservableCollection<ChartModel>? heartRateData;

        /// <summary>
        /// To store the calories burned data collection.
        /// </summary>
        private ObservableCollection<ChartModel>? caloriesBurnedData;

        /// <summary>
        /// To store the sleep time data collection.
        /// </summary>
        private ObservableCollection<ChartModel>? sleepTimeData;

        /// <summary>
        /// To store the water consumed data collection.
        /// </summary>
        private ObservableCollection<ChartModel>? waterConsumedData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HealthCareViewModel" /> class.
        /// </summary>
        public HealthCareViewModel()
        {
            this.GetChartData();
            this.healthCareCardItems = new ObservableCollection<HealthCare>()
            {
                new HealthCare()
                {
                    Category = "HEART RATE",
                    CategoryValue = "87 bmp",
                    ChartData = this.heartRateData,
                    BackgroundGradientStart = Color.FromArgb("#f59083"),
                    BackgroundGradientEnd = Color.FromArgb("#fae188"),
                },
                new HealthCare()
                {
                    Category = "CALORIES BURNED",
                    CategoryValue = "948 cal",
                    ChartData = this.caloriesBurnedData,
                    BackgroundGradientStart = Color.FromArgb("#ff7272"),
                    BackgroundGradientEnd = Color.FromArgb("#f650c5"),
                },
                new HealthCare()
                {
                    Category = "SLEEP TIME",
                    CategoryValue = "7.3 hrs",
                    ChartData = this.sleepTimeData,
                    BackgroundGradientStart = Color.FromArgb("#5e7cea"),
                    BackgroundGradientEnd = Color.FromArgb("#1dcce3"),
                },
                new HealthCare()
                {
                    Category = "WATER CONSUMED",
                    CategoryValue = "38.6 ltr",
                    ChartData = this.waterConsumedData,
                    BackgroundGradientStart = Color.FromArgb("#255ea6"),
                    BackgroundGradientEnd = Color.FromArgb("#b350d1"),
                },
            };

            this.healthCareListItems = new ObservableCollection<HealthCare>()
            {
                new HealthCare()
                {
                    Category = "Blood Pressure",
                    CategoryValue = "141/90 mmgh",
                    CategoryPercentage = "30%",
                    BackgroundGradientStart = Color.FromArgb("#cf86ff"),
                },
                new HealthCare()
                {
                    Category = "Body Weight",
                    CategoryValue = "176 lbs",
                    CategoryPercentage = "50%",
                    BackgroundGradientStart = Color.FromArgb("#8691ff"),
                },
                new HealthCare()
                {
                    Category = "Steps",
                    CategoryValue = "3463",
                    CategoryPercentage = "60%",
                    BackgroundGradientStart = Color.FromArgb("#ff9686"),
                },
            };

            this.ProfileImage = App.ImageServerPath + "ProfileImage1.png";
            this.MenuCommand = new Command(this.MenuButtonClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileImageClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCare>? HealthCareCardItems
        {
            get
            {
                return this.healthCareCardItems;
            }

            private set
            {
                this.SetProperty(ref this.healthCareCardItems, value);
            }
        }

        /// <summary>
        /// Gets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCare>? HealthCareListItems
        {
            get
            {
                return this.healthCareListItems;
            }

            private set
            {
                this.SetProperty(ref this.healthCareListItems, value);
            }
        }

        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command is executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the profile image is clicked.
        /// </summary>
        public Command ProfileSelectedCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

            this.heartRateData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 15),
                new ChartModel(dateTime.AddMonths(1), 20),
                new ChartModel(dateTime.AddMonths(2), 17),
                new ChartModel(dateTime.AddMonths(3), 23),
                new ChartModel(dateTime.AddMonths(4), 18),
                new ChartModel(dateTime.AddMonths(5), 25),
                new ChartModel(dateTime.AddMonths(6), 19),
                new ChartModel(dateTime.AddMonths(7), 21),
            };

            this.caloriesBurnedData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 940),
                new ChartModel(dateTime.AddMonths(1), 960),
                new ChartModel(dateTime.AddMonths(2), 942),
                new ChartModel(dateTime.AddMonths(3), 957),
                new ChartModel(dateTime.AddMonths(4), 940),
                new ChartModel(dateTime.AddMonths(5), 942),
            };

            this.sleepTimeData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 7.8),
                new ChartModel(dateTime.AddMonths(1), 7.2),
                new ChartModel(dateTime.AddMonths(2), 8.0),
                new ChartModel(dateTime.AddMonths(3), 6.8),
                new ChartModel(dateTime.AddMonths(4), 7.6),
                new ChartModel(dateTime.AddMonths(5), 7.0),
                new ChartModel(dateTime.AddMonths(6), 7.5),
            };

            this.waterConsumedData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 36),
                new ChartModel(dateTime.AddMonths(1), 41),
                new ChartModel(dateTime.AddMonths(2), 38),
                new ChartModel(dateTime.AddMonths(3), 41),
                new ChartModel(dateTime.AddMonths(4), 35),
                new ChartModel(dateTime.AddMonths(5), 37),
                new ChartModel(dateTime.AddMonths(6), 38),
                new ChartModel(dateTime.AddMonths(7), 36),
            };
        }

        /// <summary>
        /// Invoked when the menu button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void MenuButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the profile image is clicked.
        /// </summary>
        /// <param name="obj">The object</param>
        private void ProfileImageClicked(object obj)
        {
            // Do something
        }

        #endregion
    }

    public class HealthCare : INotifyPropertyChanged
    {
        #region Field

        private IReadOnlyCollection<ChartModel>? chartData;

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been displays the Category.
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the Category value.
        /// </summary>
        public string? CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the Category percentage.
        /// </summary>
        public string? CategoryPercentage { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with SfChart Control, which displays the health care data visualization.
        /// </summary>
        public IReadOnlyCollection<ChartModel>? ChartData
        {
            get
            {
                return this.chartData;
            }

            set
            {
                if (this.chartData == value)
                {
                    return;
                }

                this.chartData = value;
                this.OnPropertyChanged("ChartData");
            }
        }

        /// <summary>
        /// Gets or sets the property that has been displays the background gradient start.
        /// </summary>
        public Color? BackgroundGradientStart { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the background gradient end.
        /// </summary>
        public Color? BackgroundGradientEnd { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="property">Property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
