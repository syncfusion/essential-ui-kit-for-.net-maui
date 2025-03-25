namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.ViewModel;
    using Syncfusion.Maui.Core.Chips;
    using System.Collections.ObjectModel;
    using EssentialMAUIUIKit.Models.Dashboard;
    using System.ComponentModel;

    public class HealthCareViewModel : BaseViewModel
    {
        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCareModel>? trackingNutrientData;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCareModel>? trackingData;

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

        /// <summary>
        /// To update pages that can be navigated from dashboard.
        /// </summary>
        private ObservableCollection<HealthCareMenuItem> menuItems; 

        private ObservableCollection<CaloriesConsumedData> caloriesConsumedList;

        private CaloriesChartData caloriesChartDataValue;

        // PropertyChanged event handler
        public new event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HealthCareViewModel" /> class.
        /// </summary>
        public HealthCareViewModel()
        {
            this.caloriesConsumedList = new ObservableCollection<CaloriesConsumedData>();
            
            this.GetChartData();
            this.trackingNutrientData = new ObservableCollection<HealthCareModel>()
            {
                 new HealthCareModel()
                {
                    Category = "Calories eaten",
                    CategoryValue = "1200",
                    ChartData = this.waterConsumedData,
                    BackgroundGradientStart = Color.FromArgb("#FFAD4E"),
                    BackgroundGradientEnd = Color.FromArgb("#D942B8"),
                    RowValue = 0,
                    ColumnValue = 0,
                },
                new HealthCareModel()
                {
                    Category = "Heart rate",
                    CategoryValue = "84 bmp",
                    ChartData = this.heartRateData,
                    BackgroundGradientStart = Color.FromArgb("#6DB0FF"),
                    BackgroundGradientEnd = Color.FromArgb("#6957D9"),
                    RowValue = 0,
                    ColumnValue = 1,
                },
                new HealthCareModel()
                {
                    Category = "Steps",
                    CategoryValue = "10000",
                    ChartData = this.caloriesBurnedData,
                    BackgroundGradientStart = Color.FromArgb("#FFAD4E"),
                    BackgroundGradientEnd = Color.FromArgb("#D942B8"),
                    RowValue = 1,
                    ColumnValue = 0,
                },
                new HealthCareModel()
                {
                    Category = "Sleeping hours",
                    CategoryValue = "6 hrs",
                    ChartData = this.sleepTimeData,
                    BackgroundGradientStart = Color.FromArgb("#14E983"),
                    BackgroundGradientEnd = Color.FromArgb("#0F9292"),
                    RowValue = 1,
                    ColumnValue = 1,
                },
            };

            this.trackingData = new ObservableCollection<HealthCareModel>()
            {
                new HealthCareModel()
                {
                    Category = "Blood Pressure",
                    CategoryValue = "121/90 mmgh",
                    CategoryPercentage = "40%",
                    CategoryStage = "Normal",
                    BackgroundGradientStart = Color.FromArgb("#2EF867"),
                    CategoryStageColor = Color.FromArgb("#1C7E39"),

                },
                new HealthCareModel()
                {
                    Category = "Body Weight",
                    CategoryValue = "176 lbs",
                    CategoryPercentage = "50%",
                    CategoryStage = "Normal",
                    BackgroundGradientStart = Color.FromArgb("#116DF9"),
                    CategoryStageColor = Color.FromArgb("#1C7E39"),
                },
                new HealthCareModel()
                {
                    Category = "Running",
                    CategoryValue = "15 min",
                    CategoryPercentage = "50%",
                    CategoryStage = "Low",
                    BackgroundGradientStart = Color.FromArgb("#F4890B"),
                    CategoryStageColor = Color.FromArgb("#C20D32"),
                },
            };

            this.menuItems = new ObservableCollection<HealthCareMenuItem>
            {
                new HealthCareMenuItem { Name = "Dashboard", IsSelected = true },
                new HealthCareMenuItem { Name = "Goals" },
                new HealthCareMenuItem { Name = "Running" },
                new HealthCareMenuItem { Name = "Food in-taken" },
                new HealthCareMenuItem { Name = "Settings" }
            };

            this.caloriesChartDataValue = this.UpdateCaloriesConsumedData();
            this.ProfileImage = "profileavatar.png";
            this.MenuCommand = new Command(this.MenuButtonClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileImageClicked);
            if(Application.Current != null)
            {
                Application.Current.RequestedThemeChanged += (s, e) =>
                {
                    UpdateMealTheme();
                };
            }
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
        public ObservableCollection<HealthCareModel>? TrackingNutrientData
        {
            get
            {
                return this.trackingNutrientData;
            }

            private set
            {
                this.SetProperty(ref this.trackingNutrientData, value);
            }
        }

        /// <summary>
        /// Gets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCareModel>? TrackingData
        {
            get
            {
                return this.trackingData;
            }

            private set
            {
                this.SetProperty(ref this.trackingData, value);
            }
        }

        /// <summary>
        /// Gets the list of HealthCareMenuItems.
        /// </summary>
        public ObservableCollection<HealthCareMenuItem> MenuItemList
        {
            get
            {
                return this.menuItems;
            }

            private set
            {
                this.SetProperty(ref this.menuItems, value);
            }
        }

        /// <summary>
        /// Gets or sets the calories consumed list
        /// </summary>
        public ObservableCollection<CaloriesConsumedData> CaloriesConsumedList
        {
            get { return this.caloriesConsumedList; }
            set { this.caloriesConsumedList = value; }
        }

        /// <summary>
        /// Gets or sets the calories consumed data per day
        /// </summary>
        public CaloriesChartData CaloriesChartDataValue
        {
            get 
            { 
                return this.caloriesChartDataValue; 
            }
            set 
            { 
                this.caloriesChartDataValue = value;
                OnPropertyChanged("CaloriesChartDataValue");
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

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="property">Property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Calories consumed data
        /// </summary>
        private CaloriesChartData UpdateCaloriesConsumedData()
        {
            this.caloriesConsumedList = new ObservableCollection<CaloriesConsumedData>
            {
                new CaloriesConsumedData()
                {
                    Date = DateTime.Today,
                    IsSelected = true,
                    CaloriesConsumedPerMeal = new ObservableCollection<MealCalorieConsumed>
                    {
                        new MealCalorieConsumed
                        {
                            MealTime = "Breakfast",
                            CaloriesFromFiber = 30,
                            CaloriesFromProtein = 100,
                            CaloriesFromCarbs = 80,
                            CaloriesFromVitamin = 40,
                            CaloriesFromCalcium = 30,
                            CaloriesFromFat = 20,
                            MealIcon = "\ue703",
                            IsSelected = true
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Lunch",
                            CaloriesFromFiber = 40,
                            CaloriesFromProtein = 120,
                            CaloriesFromCarbs = 70,
                            CaloriesFromVitamin = 30,
                            CaloriesFromCalcium = 20,
                            CaloriesFromFat = 20,
                            MealIcon = "\ue700"
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Dinner",
                            CaloriesFromFiber = 30,
                            CaloriesFromProtein = 110,
                            CaloriesFromCarbs = 90,
                            CaloriesFromVitamin = 30,
                            CaloriesFromCalcium = 25,
                            CaloriesFromFat = 15,
                            MealIcon = "\ue702"
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Snacks",
                            CaloriesFromFiber = 20,
                            CaloriesFromProtein = 80,
                            CaloriesFromCarbs = 60,
                            CaloriesFromVitamin = 30,
                            CaloriesFromCalcium = 15,
                            CaloriesFromFat = 25,
                            MealIcon = "\ue701"
                        }
                    }
                },
                new CaloriesConsumedData()
                {
                    Date = DateTime.Today.AddDays(-1),
                    IsSelected = false,
                    CaloriesConsumedPerMeal = new ObservableCollection<MealCalorieConsumed>
                    {
                        new MealCalorieConsumed
                        {
                            MealTime = "Breakfast",
                            CaloriesFromFiber = 35,
                            CaloriesFromProtein = 120,
                            CaloriesFromCarbs = 90,
                            CaloriesFromVitamin = 50,
                            CaloriesFromCalcium = 30,
                            CaloriesFromFat = 25
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Lunch",
                            CaloriesFromFiber = 40,
                            CaloriesFromProtein = 140,
                            CaloriesFromCarbs = 80,
                            CaloriesFromVitamin = 40,
                            CaloriesFromCalcium = 25,
                            CaloriesFromFat = 25
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Dinner",
                            CaloriesFromFiber = 30,
                            CaloriesFromProtein = 130,
                            CaloriesFromCarbs = 100,
                            CaloriesFromVitamin = 40,
                            CaloriesFromCalcium = 30,
                            CaloriesFromFat = 20
                        },
                        new MealCalorieConsumed
                        {
                            MealTime = "Snacks",
                            CaloriesFromFiber = 20,
                            CaloriesFromProtein = 100,
                            CaloriesFromCarbs = 70,
                            CaloriesFromVitamin = 30,
                            CaloriesFromCalcium = 20,
                            CaloriesFromFat = 40
                        }
                    }
                }
                
            };

            var selectedData = this.CaloriesConsumedList
                .Where(item => item.IsSelected)
                .Select(item => new CaloriesConsumedData
                {
                    Date = item.Date,
                    IsSelected = item.IsSelected,
                    CaloriesConsumedPerMeal = new ObservableCollection<MealCalorieConsumed>(
                    item.CaloriesConsumedPerMeal)
                }).ToList();

           return (new CaloriesChartData(selectedData));
        }

        /// <summary>
        /// Updates calories consumed data based on the selected chip
        /// </summary>
        /// <param name="e">Selection changed argument from chipsgroup</param>
        public void ChipSelectionChanged(SelectionChangedEventArgs e)
        {
            var selectedData = this.CaloriesConsumedList
                .Where(item => item.IsSelected)
                .Select(item => new CaloriesConsumedData
                {
                    Date = item.Date,
                    IsSelected = item.IsSelected,
                    CaloriesConsumedPerMeal = new ObservableCollection<MealCalorieConsumed>(
                    item.CaloriesConsumedPerMeal)
                }).ToList(); 

            ObservableCollection<MealCalorieConsumed> selectedMealData = new ObservableCollection<MealCalorieConsumed>();
            // Add meal details based on the selected meals
            foreach (var meal in selectedData[0].CaloriesConsumedPerMeal)
            {
                meal.IsSelected = false;
                meal.MealFontColor = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#313032") : Color.FromArgb("#FFFFFF");
                meal.MealIconColor = Color.FromArgb("#7633DA");
                if (e.AddedItem != null && meal.MealTime == ((MealCalorieConsumed)e.AddedItem).MealTime?.ToString())
                {
                    meal.IsSelected = true;
                    meal.MealFontColor = Color.FromArgb("#FFFFFF");
                    meal.MealIconColor = Color.FromArgb("#FFFFFF");
                }
                selectedMealData.Add(meal);
            }
            selectedData[0].CaloriesConsumedPerMeal = selectedMealData;

            this.CaloriesChartDataValue.SelectedMealDetails = new ObservableCollection<MealCalorieConsumed>(
            selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Where(m => m.IsSelected));
        }

        /// <summary>
        /// Updates meal font color based on the selected theme
        /// </summary>
        private void UpdateMealTheme()
        {
           foreach (var dayMeal in CaloriesConsumedList)
            {
                if(dayMeal.IsSelected)
                {
                    foreach(var mealValue in dayMeal.CaloriesConsumedPerMeal)
                    {
                        mealValue.MealFontColor = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#313032") : Color.FromArgb("#FFFFFF");
                    }
                }
            }
        }

        #endregion
    }

    public class HealthCareModel : INotifyPropertyChanged
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

        /// <summary>
        /// Gets or sets the property to update health status
        /// </summary>
        public string? CategoryStage { get; set; }

        /// <summary>
        /// Gets or sets the property to update color based on health status
        /// </summary>
        public Color? CategoryStageColor { get; set; }

        /// <summary>
        /// Gets or sets the property to update the row placement in UI
        /// </summary>
        public int RowValue { get; set; }

        /// <summary>
        /// Gets or sets the property to update the column placement in UI
        /// </summary>
        public int ColumnValue { get; set; }

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

    public class HealthCareMenuItem
    {
        /// <summary>
        /// Gets or sets the property to display menu items in left layout.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the property to update the selected menu.
        /// </summary>
        public bool IsSelected { get; set; }
    }   

    public class MealCalorieConsumed : INotifyPropertyChanged
    {
        #region fields

        private string mealTime;

        private int caloriesFromFiber;

        private int caloriesFromProtein;

        private int caloriesFromCarbs;

        private int caloriesFromCalcium;

        private int caloriesFromVitamin;        

        private int caloriesFromFat;

        private string? mealIcon;

        private bool _isSelected;

        private Color? mealFontColor;

        private Color? mealIconColor;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the property to display meal option.
        /// </summary>
        public string MealTime
        {
            get { return this.mealTime; }
            set { this.mealTime = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from fibre.
        /// </summary>
        public int CaloriesFromFiber
        {
            get { return this.caloriesFromFiber; }
            set { this.caloriesFromFiber = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from protein.
        /// </summary>
        public int CaloriesFromProtein
        {
            get { return this.caloriesFromProtein; }
            set { this.caloriesFromProtein = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from carbs.
        /// </summary>
        public int CaloriesFromCarbs
        {
            get { return this.caloriesFromCarbs; }
            set { this.caloriesFromCarbs = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from calcium.
        /// </summary>
        public int CaloriesFromCalcium
        {
            get { return this.caloriesFromCalcium; }
            set { this.caloriesFromCalcium = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from vitamin.
        /// </summary>
        public int CaloriesFromVitamin
        {
            get { return this.caloriesFromVitamin; }
            set { this.caloriesFromVitamin = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories from fat.
        /// </summary>
        public int CaloriesFromFat
        {
            get { return this.caloriesFromFat; }
            set { this.caloriesFromFat = value; }
        }

        /// <summary>
        /// Gets or sets the property to display colors based on nutrients.
        /// </summary>
        public NutrientColors NutrientColorValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the property to update icon color of meal option
        /// </summary>
        public Color? MealIconColor
        {
            get
            {
                return this.mealIconColor;
            }
            set
            {
                this.mealIconColor = value;
                OnPropertyChanged("MealIconColor");
            }
        }

        /// <summary>
        /// Gets or sets the property to update font color of meal option
        /// </summary>
        public Color? MealFontColor 
        {
            get 
            { 
                return this.mealFontColor;
            } 
            set
            { 
                this.mealFontColor = value;
                OnPropertyChanged("MealFontColor"); 
            } 
        }

        /// <summary>
        /// Gets or sets the property to update meal icon
        /// </summary>
        public string? MealIcon
        {
            get
            {
                return this.mealIcon;
            }
            set
            {
                this.mealIcon = value;
            }
        }

        /// <summary>
        /// Gets or sets the property to update selected meal option
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MealCalorieConsumed" /> class.
        /// </summary>
        public MealCalorieConsumed()
        {
            this.mealTime = string.Empty;
            this.IsSelected = false; // Default value
            this.NutrientColorValue = new NutrientColors(); 
            this.MealFontColor = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#313032") : Color.FromArgb("#FFFFFF");
            this.MealIconColor = Color.FromArgb("#7633DA");
        }

        #endregion

        #region events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class CaloriesConsumedData : INotifyPropertyChanged
    {
        #region Fields

        private DateTime date;

        private ObservableCollection<MealCalorieConsumed> caloriesConsumedPerMeal;

        private bool _isSelected;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the date to update calories consumed data on daywise.
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// Gets or sets the calories consumed per meal in a day
        /// </summary>
        public ObservableCollection<MealCalorieConsumed> CaloriesConsumedPerMeal
        {
            get { return this.caloriesConsumedPerMeal; }
            set { this.caloriesConsumedPerMeal = value; }
        }

        /// <summary>
        /// Gets or sets the day selected to be displayed.
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CaloriesConsumedData" /> class.
        /// </summary>
        public CaloriesConsumedData()
        {
            this.caloriesConsumedPerMeal = new ObservableCollection<MealCalorieConsumed>();
            this.IsSelected = false; // Default value
        }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class CaloriesConsumedADay
    {
        #region Properties

        /// <summary>
        /// Gets or sets the value to display nutrient name
        /// </summary>
        public string? Nutrient { get; set; }

        /// <summary>
        /// Gets or sets the value to display nutrient value
        /// </summary>
        public int Value { get; set; }

        #endregion
    }

    public class CaloriesChartData : INotifyPropertyChanged
    {
        #region fields

        private ObservableCollection<CaloriesConsumedADay> caloriesConsumedInADay;

        private ObservableCollection<string> mealTime;

        private ObservableCollection<MealCalorieConsumed> selectedMealDetails;

        private string totalCaloriesInADay;

        private ObservableCollection<Brush> segmentColors;

        private NutrientColors nutrientColorValue;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CaloriesChartData" /> class.
        /// </summary>
        public CaloriesChartData(List<CaloriesConsumedData> selectedData)
        {

            this.caloriesConsumedInADay = new ObservableCollection<CaloriesConsumedADay>()
            {
                new CaloriesConsumedADay { Nutrient = "Fiber", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromFiber) },
                new CaloriesConsumedADay { Nutrient = "Protein", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromProtein) },
                new CaloriesConsumedADay { Nutrient = "Carbs", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromCarbs) },
                new CaloriesConsumedADay { Nutrient = "Vitamin", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromVitamin) },
                new CaloriesConsumedADay { Nutrient = "Calcium", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromCalcium) },
                new CaloriesConsumedADay { Nutrient = "Fat", Value = selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Sum(meal => meal.CaloriesFromFat) }
            };

            nutrientColorValue = new NutrientColors();
            this.segmentColors = new ObservableCollection<Brush>()
            {               
               new SolidColorBrush(nutrientColorValue.FiberColor),
               new SolidColorBrush(nutrientColorValue.ProteinColor),
               new SolidColorBrush(nutrientColorValue.CarbsColor),
               new SolidColorBrush(nutrientColorValue.VitaminColor),
               new SolidColorBrush(nutrientColorValue.CalciumColor),
               new SolidColorBrush(nutrientColorValue.FatColor),
            };

            this.totalCaloriesInADay = this.CaloriesConsumedInADay.Sum(nutrient => nutrient.Value).ToString();

           
            this.mealTime = new ObservableCollection<string>(selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Select(meal => meal.MealTime)
);
            this.selectedMealDetails = new ObservableCollection<MealCalorieConsumed>(
            selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Where(m => m.IsSelected));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value to display calories consumed in a day.
        /// </summary>
        public ObservableCollection<CaloriesConsumedADay> CaloriesConsumedInADay
        {
            get { return this.caloriesConsumedInADay; }
            set { this.caloriesConsumedInADay = value; }
        }

        /// <summary>
        /// Gets or sets the property to display total calories consumed in a day.
        /// </summary>
        public string TotalCaloriesInADay
        {
            get { return this.totalCaloriesInADay; }
            set
            {
                this.totalCaloriesInADay = value;
            }
        }

        /// <summary>
        /// Gets or sets the property to display meal time.
        /// </summary>
        public ObservableCollection<string> MealTime
        {
            get { return this.mealTime; }
            set
            {
                this.mealTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the property to display selected meal nutrients.
        /// </summary>
        public ObservableCollection<MealCalorieConsumed> SelectedMealDetails 
        {
            get { return this.selectedMealDetails; }
            set
            {
                this.selectedMealDetails = value;
                OnPropertyChanged("SelectedMealDetails");
            }
        }

        /// <summary>
        /// Gets or sets the property to update colors for each segments
        /// </summary>
        public ObservableCollection<Brush> SegmentColors 
        {
            get
            {
                return this.segmentColors;
            }
            set
            {
                this.segmentColors = value;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }

    public class NutrientColors
    {

        #region Properties

        /// <summary>
        /// Gets or sets the value to display fiber segment color.
        /// </summary>
        public Color FiberColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value to display carbs segment color.
        /// </summary>
        public Color CarbsColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value to display vitamin segment color.
        /// </summary>
        public Color VitaminColor
        {
            get;
            set;

        }

        /// <summary>
        /// Gets or sets the value to display fat segment color.
        /// </summary>
        public Color FatColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value to display calcium segment color.
        /// </summary>
        public Color CalciumColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value to display protein segment color.
        /// </summary>
        public Color ProteinColor
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NutrientColors" /> class.
        /// </summary>
        public NutrientColors()
        {
            FiberColor = Color.FromArgb("#2196F3");
            CalciumColor = Color.FromArgb("#FF4E4E");
            VitaminColor = Color.FromArgb("#E2227E");
            ProteinColor = Color.FromArgb("#25E739");
            CarbsColor = Color.FromArgb("#FCD404");
            FatColor = Color.FromArgb("#9215F3");
        }

        #endregion
    }
}
