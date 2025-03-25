using EssentialMAUIUIKit.ViewModel;
using EssentialMAUIUIKit.Models.Dashboard;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Maui.Core.Chips;

namespace EssentialMAUIUIKit
{
    public class DailyCaloriesReportViewModel : BaseViewModel
    {
        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<DailyHealthCare>? trackingNutrientData;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<DailyHealthCare>? trackingData;

        /// <summary>
        /// To store the heart rate data collection.
        /// </summary>
        private ObservableCollection<DailyChartModel>? heartRateData;

        /// <summary>
        /// To store the calories burned data collection.
        /// </summary>
        private ObservableCollection<DailyChartModel>? caloriesBurnedData;

        /// <summary>
        /// To store the sleep time data collection.
        /// </summary>
        private ObservableCollection<DailyChartModel>? sleepTimeData;

        /// <summary>
        /// To store the water consumed data collection.
        /// </summary>
        private ObservableCollection<DailyChartModel>? waterConsumedData;

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
        public DailyCaloriesReportViewModel()
        {
            this.caloriesConsumedList = new ObservableCollection<CaloriesConsumedData>();

            this.GetChartData();
            this.trackingNutrientData = new ObservableCollection<DailyHealthCare>()
            {
                 new DailyHealthCare()
                {
                    Category = "Calories eaten",
                    CategoryValue = "1200",
                    ChartData = this.waterConsumedData,
                    BackgroundGradientStart = Color.FromArgb("#FFAD4E"),
                    BackgroundGradientEnd = Color.FromArgb("#D942B8"),
                    RowValue = 0,
                    ColumnValue = 0,
                },
                new DailyHealthCare()
                {
                    Category = "Heart rate",
                    CategoryValue = "84 bmp",
                    ChartData = this.heartRateData,
                    BackgroundGradientStart = Color.FromArgb("#6DB0FF"),
                    BackgroundGradientEnd = Color.FromArgb("#6957D9"),
                    RowValue = 0,
                    ColumnValue = 1,
                },
                new DailyHealthCare()
                {
                    Category = "Steps",
                    CategoryValue = "10000",
                    ChartData = this.caloriesBurnedData,
                    BackgroundGradientStart = Color.FromArgb("#FFAD4E"),
                    BackgroundGradientEnd = Color.FromArgb("#D942B8"),
                    RowValue = 1,
                    ColumnValue = 0,
                },
                new DailyHealthCare()
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

            this.trackingData = new ObservableCollection<DailyHealthCare>()
            {
                new DailyHealthCare()
                {
                    Category = "Blood Pressure",
                    CategoryValue = "121/90 mmgh",
                    CategoryPercentage = "40%",
                    CategoryStage = "Normal",
                    BackgroundGradientStart = Color.FromArgb("#2EF867"),
                    CategoryStageColor = Color.FromArgb("#1C7E39"),

                },
                new DailyHealthCare()
                {
                    Category = "Body Weight",
                    CategoryValue = "176 lbs",
                    CategoryPercentage = "50%",
                    CategoryStage = "Normal",
                    BackgroundGradientStart = Color.FromArgb("#116DF9"),
                    CategoryStageColor = Color.FromArgb("#1C7E39"),
                },
                new DailyHealthCare()
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
            this.MenuCommand = new Command(this.MenuButtonClicked);
            this.ProfileSelectedCommand = new Command(this.ProfileImageClicked);
            if (Application.Current != null)
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
        /// Gets the health care items collection.
        /// </summary>
        public ObservableCollection<DailyHealthCare>? TrackingNutrientData
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
        public ObservableCollection<DailyHealthCare>? TrackingData
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

            this.heartRateData = new ObservableCollection<DailyChartModel>()
            {
                new DailyChartModel(dateTime, 15),
                new DailyChartModel(dateTime.AddMonths(1), 20),
                new DailyChartModel(dateTime.AddMonths(2), 17),
                new DailyChartModel(dateTime.AddMonths(3), 23),
                new DailyChartModel(dateTime.AddMonths(4), 18),
                new DailyChartModel(dateTime.AddMonths(5), 25),
                new DailyChartModel(dateTime.AddMonths(6), 19),
                new DailyChartModel(dateTime.AddMonths(7), 21),
            };

            this.caloriesBurnedData = new ObservableCollection<DailyChartModel>()
            {
                new DailyChartModel(dateTime, 940),
                new DailyChartModel(dateTime.AddMonths(1), 960),
                new DailyChartModel(dateTime.AddMonths(2), 942),
                new DailyChartModel(dateTime.AddMonths(3), 957),
                new DailyChartModel(dateTime.AddMonths(4), 940),
                new DailyChartModel(dateTime.AddMonths(5), 942),
            };

            this.sleepTimeData = new ObservableCollection<DailyChartModel>()
            {
                new DailyChartModel(dateTime, 7.8),
                new DailyChartModel(dateTime.AddMonths(1), 7.2),
                new DailyChartModel(dateTime.AddMonths(2), 8.0),
                new DailyChartModel(dateTime.AddMonths(3), 6.8),
                new DailyChartModel(dateTime.AddMonths(4), 7.6),
                new DailyChartModel(dateTime.AddMonths(5), 7.0),
                new DailyChartModel(dateTime.AddMonths(6), 7.5),
            };

            this.waterConsumedData = new ObservableCollection<DailyChartModel>()
            {
                new DailyChartModel(dateTime, 36),
                new DailyChartModel(dateTime.AddMonths(1), 41),
                new DailyChartModel(dateTime.AddMonths(2), 38),
                new DailyChartModel(dateTime.AddMonths(3), 41),
                new DailyChartModel(dateTime.AddMonths(4), 35),
                new DailyChartModel(dateTime.AddMonths(5), 37),
                new DailyChartModel(dateTime.AddMonths(6), 38),
                new DailyChartModel(dateTime.AddMonths(7), 36),
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
        public void ChipSelectionChanged(Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
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
                if (dayMeal.IsSelected)
                {
                    foreach (var mealValue in dayMeal.CaloriesConsumedPerMeal)
                    {
                        mealValue.MealFontColor = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#313032") : Color.FromArgb("#FFFFFF");
                    }
                }
            }
        }

        #endregion
    }
}
