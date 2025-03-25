using EssentialMAUIUIKit.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EssentialMAUIUIKit
{
    public class StockOverviewViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Field

        private ObservableCollection<Stock> items = new ObservableCollection<Stock>();

        private ObservableCollection<ChartData> bindingChartData = new ObservableCollection<ChartData>();

        private ChartData filterChartData = new ChartData();

        private Stock item = new Stock();

        private int selectedDataVariantIndex;

        private ObservableCollection<ChartModel> threeMonthData = new ObservableCollection<ChartModel>();

        private ObservableCollection<ChartModel> sixMonthData = new ObservableCollection<ChartModel>();

        private ObservableCollection<ChartModel> nineMonthData = new ObservableCollection<ChartModel>();

        private ObservableCollection<ChartModel> yearData = new ObservableCollection<ChartModel>();

        private string? notificationIcon;

        private string? profileImage;

        private static readonly string[] InvestmentFrameColors =
        {
            "PrimaryLighter",
            "WarningLight",
            "InfoLight",
            "SuccessLight",
            "PrimaryLighterDark",
            "WarningLightDark",
            "InfoLightDark",
            "SuccessLightDark"
        };

        private double investmentLayoutHeight;

        private ObservableCollection<NavigationPages> navigationPageList;

        private DateTime _selectedDate;

        private ObservableCollection<string>? timeVariant;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="StockOverviewViewModel" /> class.
        /// </summary>
        public StockOverviewViewModel()
        {
            this.navigationPageList = new ObservableCollection<NavigationPages>
            {
                new NavigationPages { Name = "Dashboard", IsSelected = true },
                new NavigationPages { Name = "Investment" },
                new NavigationPages { Name = "Transaction" },
                new NavigationPages { Name = "Portfolio" },
                new NavigationPages { Name = "Settings" }
            };

            // Time variant to assign on chip group
            this.TimeVariant = new ObservableCollection<string> { "3M", "6M", "9M", "1Y" };
            this.SelectedVariant = this.TimeVariant[0];

            // Initialized data to bind on chart
            this.GetChartData();

            // Filtered time variant data to bind on chart
            this.GetFilteredChartData();

                        
            Application.Current!.RequestedThemeChanged += (sender, args) =>
            {
                UpdateStockData();
            };
            

            this.Nifty50Data = new ObservableCollection<MarketData>
            {
                new MarketData { Value = 13098, Change = "+0.98%" }
            };
            this.SensexData = new ObservableCollection<MarketData>
            {
                new MarketData { Value = 32098, Change = "-0.76%"}
            };

            this.UpdateStockData();
            this.item = items.First();
            this.ProfileImage = "profileavatar.png";
            this.MenuCommand = new Command(this.MenuButtonClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileImageClicked);
            this.SelectedDate = DateTime.Today; // Default to today's date
            this.InvestmentsLayoutHeight = DeviceDisplay.MainDisplayInfo.Height > 280 ? DeviceDisplay.MainDisplayInfo.Height - 280 : 400;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value for Profile Image.
        /// </summary>
        public string? ProfileImage
        {
            get
            {
                return this.profileImage;
            }

            set
            {
                this.SetProperty(ref this.profileImage, value);
            }
        }

        /// <summary>
        /// Gets or sets a value for Investments layout height.
        /// </summary>
        public double InvestmentsLayoutHeight
        {
            get
            {
                return this.investmentLayoutHeight;
            }

            set
            {
                this.investmentLayoutHeight = value;
                OnPropertyChanged("InvestmentsLayoutHeight");
            }
        }

        /// <summary>
        /// Gets or sets a value for Notification Icon image
        /// </summary>
        public string? NotificationIcon
        {
            get
            {
                return this.notificationIcon;
            }

            set
            {
                this.SetProperty(ref this.notificationIcon, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected data variant index.
        /// </summary>
        public int SelectedDataVariantIndex
        {
            get
            {
                return this.selectedDataVariantIndex;
            }

            set
            {
                this.SetProperty(ref this.selectedDataVariantIndex, value);
            }
        }

        /// <summary>
        /// Gets the stock items collection.
        /// </summary>
        public ObservableCollection<Stock> Items
        {
            get
            {
                return this.items;
            }

            private set
            {
                this.SetProperty(ref this.items, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the stock item.
        /// </summary>
        public Stock Item
        {
            get
            {
                return this.item;
            }

            private set
            {
                this.SetProperty(ref this.item, value);
            }
        }

        /// <summary>
        /// Gets the list of Navigation Pages.
        /// </summary>
        public ObservableCollection<NavigationPages> NavigationPageList
        {
            get
            {
                return this.navigationPageList;
            }

            private set
            {
                this.SetProperty(ref this.navigationPageList, value);
            }
        }

        /// <summary>
        /// Gets the Nifty50 data
        /// </summary>
        public ObservableCollection<MarketData> Nifty50Data { get; set; }

        /// <summary>
        /// Gets the Sensex data
        /// </summary>
        public ObservableCollection<MarketData> SensexData { get; set; }

        /// <summary>
        /// Gets or sets the date selected in date picker
        /// </summary>
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                }
            }
        }

        /// <summary>
        /// Gets or sets the property to select Time Variant
        /// </summary>
        public ObservableCollection<string>? TimeVariant
        {
            get
            {
                return this.timeVariant;
            }
            set
            {    
                this.timeVariant = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected variant
        /// </summary>
        public string SelectedVariant { get; set; }

        /// <summary>
        /// Gets or sets the chart data
        /// </summary>
        public ObservableCollection<ChartData> BindingChartData 
        { 
            get 
            { 
                return this.bindingChartData; 
            }
            set 
            { 
                this.bindingChartData = value; 
                OnPropertyChanged("BindingChartData"); 
            }
        }

        /// <summary>
        /// Gets or sets the filtered chart data
        /// </summary>
        public ChartData FilteredChartData
        {
            get
            { 
                return this.filterChartData;
            }
            set 
            { 
                this.filterChartData = value;
                OnPropertyChanged("FilteredChartData");
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
        /// Chart Data based on time variant
        /// </summary>
        private void GetChartData()
        {
            // Ensuring to initialize chart data based on variant
            this.TimeVariantChartData();

            this.bindingChartData = new ObservableCollection<ChartData>()
            {
                new ChartData(){ TimeVariant = "3M", IsSelected = false, ChartValue = this.threeMonthData },
                new ChartData(){ TimeVariant = "6M", IsSelected = false, ChartValue = this.sixMonthData },
                new ChartData(){ TimeVariant = "9M", IsSelected = true, ChartValue = this.nineMonthData },
                new ChartData(){ TimeVariant = "1Y", IsSelected = false, ChartValue = this.yearData }
            };
        }

        /// <summary>
        /// Chart value based on selected Time variant
        /// </summary>
        private void GetFilteredChartData()
        {
            foreach (var chartValue in this.BindingChartData)
            {
                if(chartValue.IsSelected == true)
                {
                    this.FilteredChartData = chartValue;
                }
            }
        }

        /// <summary>
        /// Chart Data based on time variant
        /// </summary>
        private void TimeVariantChartData()
        {
            DateTime dateTime = DateTime.Today.AddDays(-180);

            this.sixMonthData = new ObservableCollection<ChartModel>()
            {

                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(4), 4508),
                new ChartModel(dateTime.AddDays(6), 4157),
                new ChartModel(dateTime.AddDays(8), 4062),
                new ChartModel(dateTime.AddDays(10), 4587),
                new ChartModel(dateTime.AddDays(12), 4642),
                new ChartModel(dateTime.AddDays(14), 4205),
                new ChartModel(dateTime.AddDays(16), 4678),
                new ChartModel(dateTime.AddDays(18), 4402),
                new ChartModel(dateTime.AddDays(20), 4650),
                new ChartModel(dateTime.AddDays(22), 4704),
                new ChartModel(dateTime.AddDays(24), 4680),
                new ChartModel(dateTime.AddDays(26), 5351),
                new ChartModel(dateTime.AddDays(28), 5385),
                new ChartModel(dateTime.AddDays(30), 5289),
                new ChartModel(dateTime.AddDays(32), 4703),
                new ChartModel(dateTime.AddDays(34), 4718),
                new ChartModel(dateTime.AddDays(36), 4430),
                new ChartModel(dateTime.AddDays(38), 4308),
                new ChartModel(dateTime.AddDays(40), 4212),
                new ChartModel(dateTime.AddDays(42), 4643),
                new ChartModel(dateTime.AddDays(44), 5620),
                new ChartModel(dateTime.AddDays(46), 5432),
                new ChartModel(dateTime.AddDays(48), 5339),
                new ChartModel(dateTime.AddDays(50), 5718),
                new ChartModel(dateTime.AddDays(52), 5450),
                new ChartModel(dateTime.AddDays(54), 5578),
                new ChartModel(dateTime.AddDays(56), 5337),
                new ChartModel(dateTime.AddDays(58), 5317),
                new ChartModel(dateTime.AddDays(60), 5204),
                new ChartModel(dateTime.AddDays(64), 4922),
                new ChartModel(dateTime.AddDays(68), 4878),
                new ChartModel(dateTime.AddDays(72), 4975),
                new ChartModel(dateTime.AddDays(76), 4900),
                new ChartModel(dateTime.AddDays(80), 5312),
                new ChartModel(dateTime.AddDays(84), 5283),
                new ChartModel(dateTime.AddDays(88), 5390),
                new ChartModel(dateTime.AddDays(92), 5550),
                new ChartModel(dateTime.AddDays(96), 5620),
                new ChartModel(dateTime.AddDays(100), 5430),
                new ChartModel(dateTime.AddDays(104), 5522),
                new ChartModel(dateTime.AddDays(108), 5604),
                new ChartModel(dateTime.AddDays(112), 5837),
                new ChartModel(dateTime.AddDays(116), 5720),
                new ChartModel(dateTime.AddDays(120), 5703),
                new ChartModel(dateTime.AddDays(124), 5904),
                new ChartModel(dateTime.AddDays(128), 6110),
                new ChartModel(dateTime.AddDays(132), 6280),
                new ChartModel(dateTime.AddDays(136), 6217),
                new ChartModel(dateTime.AddDays(140), 5830),
                new ChartModel(dateTime.AddDays(144), 5742),
                new ChartModel(dateTime.AddDays(148), 5701),
                new ChartModel(dateTime.AddDays(152), 5640),
                new ChartModel(dateTime.AddDays(156), 5780),
                new ChartModel(dateTime.AddDays(160), 6232),
                new ChartModel(dateTime.AddDays(164), 6150),
                new ChartModel(dateTime.AddDays(168), 6183),
                new ChartModel(dateTime.AddDays(172), 5630),
                new ChartModel(dateTime.AddDays(176), 5692),
                new ChartModel(dateTime.AddDays(180), 5680),
            };
            dateTime = DateTime.Today.AddDays(-90);
            this.threeMonthData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(4), 4508),
                new ChartModel(dateTime.AddDays(6), 4157),
                new ChartModel(dateTime.AddDays(8), 4062),
                new ChartModel(dateTime.AddDays(10), 4587),
                new ChartModel(dateTime.AddDays(12), 4642),
                new ChartModel(dateTime.AddDays(14), 4205),
                new ChartModel(dateTime.AddDays(16), 4678),
                new ChartModel(dateTime.AddDays(18), 4402),
                new ChartModel(dateTime.AddDays(20), 4650),
                new ChartModel(dateTime.AddDays(22), 4704),
                new ChartModel(dateTime.AddDays(24), 4680),
                new ChartModel(dateTime.AddDays(26), 5351),
                new ChartModel(dateTime.AddDays(28), 5385),
                new ChartModel(dateTime.AddDays(30), 5289),
                new ChartModel(dateTime.AddDays(32), 4703),
                new ChartModel(dateTime.AddDays(34), 4718),
                new ChartModel(dateTime.AddDays(36), 4430),
                new ChartModel(dateTime.AddDays(38), 4308),
                new ChartModel(dateTime.AddDays(40), 4212),
                new ChartModel(dateTime.AddDays(42), 4643),
                new ChartModel(dateTime.AddDays(44), 5620),
                new ChartModel(dateTime.AddDays(46), 5432),
                new ChartModel(dateTime.AddDays(48), 5339),
                new ChartModel(dateTime.AddDays(50), 5718),
                new ChartModel(dateTime.AddDays(52), 5450),
                new ChartModel(dateTime.AddDays(54), 5578),
                new ChartModel(dateTime.AddDays(56), 5337),
                new ChartModel(dateTime.AddDays(58), 5317),
                new ChartModel(dateTime.AddDays(60), 5204),
                new ChartModel(dateTime.AddDays(64), 4922),
                new ChartModel(dateTime.AddDays(68), 4878),
                new ChartModel(dateTime.AddDays(72), 4975),
                new ChartModel(dateTime.AddDays(76), 4900),
                new ChartModel(dateTime.AddDays(80), 5312),
                new ChartModel(dateTime.AddDays(84), 5283),
                new ChartModel(dateTime.AddDays(88), 5390),
            };
            dateTime = DateTime.Today.AddDays(-260);
            this.nineMonthData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddDays(15), 4508),
                new ChartModel(dateTime.AddDays(30), 4157),
                new ChartModel(dateTime.AddDays(45), 4062),
                new ChartModel(dateTime.AddDays(60), 4587),
                new ChartModel(dateTime.AddDays(75), 4642),
                new ChartModel(dateTime.AddDays(90), 4205),
                new ChartModel(dateTime.AddDays(105), 4678),
                new ChartModel(dateTime.AddDays(120), 4402),
                new ChartModel(dateTime.AddDays(135), 4650),
                new ChartModel(dateTime.AddDays(150), 4704),
                new ChartModel(dateTime.AddDays(165), 4680),
                new ChartModel(dateTime.AddDays(180), 5351),
                new ChartModel(dateTime.AddDays(195), 5385),
                new ChartModel(dateTime.AddDays(210), 5289),
                new ChartModel(dateTime.AddDays(225), 4680),
                new ChartModel(dateTime.AddDays(240), 5351),
                new ChartModel(dateTime.AddDays(255), 5385),
                new ChartModel(dateTime.AddDays(260), 5289),
            };

            dateTime = DateTime.Today.AddDays(-365);
            this.yearData = new ObservableCollection<ChartModel>()
            {
                new ChartModel(dateTime, 4478),
                new ChartModel(dateTime.AddMonths(1), 4508),
                new ChartModel(dateTime.AddMonths(2), 4157),
                new ChartModel(dateTime.AddMonths(3), 4062),
                new ChartModel(dateTime.AddMonths(4), 4587),
                new ChartModel(dateTime.AddMonths(5), 4642),
                new ChartModel(dateTime.AddMonths(6), 4205),
                new ChartModel(dateTime.AddMonths(7), 4678),
                new ChartModel(dateTime.AddMonths(8), 4402),
                new ChartModel(dateTime.AddMonths(9), 4650),
                new ChartModel(dateTime.AddMonths(10), 4704),
                new ChartModel(dateTime.AddMonths(11), 4680),
                new ChartModel(dateTime.AddMonths(12), 5351),
            };
        }  

        /// <summary>
        /// Invoked when the menu button clicked
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


        // PropertyChanged event handler
        public new event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }        

        private void UpdateStockData()
        {
            this.Items = new ObservableCollection<Stock>()
            {
                new Stock()
                {
                    Category = "BSESN",
                    SubCategory = "S&P BSE SENSEX",
                    CategoryValue = 2492.89,
                    PastCategoryValue = 2484.90,
                    FrameColor = (Color) (Application.Current!.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[0]]:Application.Current.Resources[InvestmentFrameColors[4]]),
                },
                new Stock()
                {
                    Category = "NSEI",
                    SubCategory = "NIFTY 50",
                    CategoryValue = 6165.76,
                    PastCategoryValue = 6144.78,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[1]]:Application.Current.Resources[InvestmentFrameColors[5]]),
                },
                new Stock()
                {
                    Category = "AAPL",
                    SubCategory = "APPLE INC",
                    CategoryValue = 656,
                    PastCategoryValue = 601.91,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[2]]:Application.Current.Resources[InvestmentFrameColors[6]]),
                },
                new Stock()
                {
                    Category = "SBUCX",
                    SubCategory = "STARSSBUCKS CORP",
                    CategoryValue = 908.87,
                    PastCategoryValue = 832.78,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[3]]:Application.Current.Resources[InvestmentFrameColors[7]]),
                },
                new Stock()
                {
                    Category = "GOOGLECX",
                    SubCategory = "GOOGLE",
                    CategoryValue = 6766.00,
                    PastCategoryValue = 6864.00,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[0]]:Application.Current.Resources[InvestmentFrameColors[4]]),
                },
                new Stock()
                {
                    Category = "AMAZONINC",
                    SubCategory = "AMAZON",
                    CategoryValue = 42346,
                    PastCategoryValue = 42258.35,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[1]]:Application.Current.Resources[InvestmentFrameColors[5]]),
                },
                new Stock()
                {
                    Category = "TCS",
                    SubCategory = "TATA",
                    CategoryValue = 266,
                    PastCategoryValue = 355,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[2]]:Application.Current.Resources[InvestmentFrameColors[6]]),
                },
                new Stock()
                {
                    Category = "MAHINDRAAUT",
                    SubCategory = "MAHINDRA",
                    CategoryValue = 2492.89,
                    PastCategoryValue = 2519.01,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[3]]:Application.Current.Resources[InvestmentFrameColors[7]]),
                },
                new Stock()
                {
                    Category = "INFOSYS LTD ADR",
                    SubCategory = "INFOSYS",
                    CategoryValue = 20.72,
                    PastCategoryValue = 20.68,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[0]]:Application.Current.Resources[InvestmentFrameColors[4]]),
                },
                new Stock()
                {
                    Category = "TECH MAHINDRA LTD",
                    SubCategory = "MAHINDRA",
                    CategoryValue = 1631.40,
                    PastCategoryValue = 1624.40,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[1]]:Application.Current.Resources[InvestmentFrameColors[5]]),
                },
                new Stock()
                {
                    Category = "HDFC BANK LTD",
                    SubCategory = "HDFC",
                    CategoryValue = 1714.85,
                    PastCategoryValue = 1715.60,
                    FrameColor = (Color) (Application.Current.RequestedTheme == AppTheme.Light ? Application.Current.Resources[InvestmentFrameColors[2]]:Application.Current.Resources[InvestmentFrameColors[6]]),
                },
            };
        }

        /// <summary>
        /// Invoked when the time variant has been changed.
        /// </summary>
        /// <param name="selectedChip">selected chip value</param>
        public void UpdateSelectedChipData(string? selectedChip)
        {
            foreach (var item in this.BindingChartData)
            {
                item.IsSelected = false;
                if (item.TimeVariant == selectedChip)
                {
                    item.IsSelected = true;
                    this.FilteredChartData = item;
                }
            }
        }

        #endregion
    }

    public class Stock : INotifyPropertyChanged
    {
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
        /// Gets or sets the property holding value of previous category value.
        /// </summary>
        public double PastCategoryValue { get; set; }

        /// <summary>
        /// Gets the property that displays the Difference value based on Current and Past Category value.
        /// </summary>
        public string DifferenceValue
        {
            get
            {
                var difference = CategoryValue - PastCategoryValue;
                return difference > 0
                    ? $"+{difference:F2}"
                    : $"{difference:F2}";
            }
        }

        /// <summary>
        /// Gets the property that returns the Color for font based on difference value
        /// </summary>
        public Color DifferenceColor => CategoryValue - PastCategoryValue >= 0 ? (Color)(Application.Current?.Resources["SuccessGreen"] ?? Colors.Transparent) : (Color)(Application.Current?.Resources["DangerRed"] ?? Colors.Transparent);
        
        /// <summary>
        /// Gets or sets the property that has been displays the SubCategory.
        /// </summary>
        public string? SubCategory { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the Category value.
        /// </summary>
        public double CategoryValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been used to update background color for each frame.
        /// </summary>
        public Color? FrameColor { get; set; }            

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


    public class ChartModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="dateTime">The date time</param>
        /// <param name="value">The value</param>
        public ChartModel(DateTime dateTime, double value)
        {
            this.DateTimeXValue = dateTime;
            this.YValue = value;
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been bound the chart X value.
        /// </summary>
        public DateTime DateTimeXValue { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound the chart Y value.
        /// </summary>
        public double YValue { get; set; }

        #endregion
    }

    public class MarketData
    {
        #region Property
        /// <summary>
        /// Gets or sets the value for Market data
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Gets or sets change in market data value
        /// </summary>
        public required string Change { get; set; }

        #endregion
    }

    public class NavigationPages
    {
        #region Property

        /// <summary>
        /// Gets or sets the navigation page list.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets selected navigation page.
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion
    }

    public class ChartData
    {
        #region fields

        private bool isSelected;

        private IReadOnlyCollection<ChartModel> chartData = new Collection<ChartModel>();

        #endregion

        /// <summary>
        /// Gets or sets the property that has been bound with SfChart Control, which displays the items source for Stock.
        /// </summary>
        public IReadOnlyCollection<ChartModel> ChartValue
        {
            get
            {
                return this.chartData;
            }

            set
            {
                this.chartData = value;
            }
        }

        /// <summary>
        ///  Updates selected chart data value
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            { 
                this.isSelected = value;
            }
        }

        /// <summary>
        /// Gets or sets the meal option
        /// </summary>
        public string? TimeVariant { get; set; }

    }
}