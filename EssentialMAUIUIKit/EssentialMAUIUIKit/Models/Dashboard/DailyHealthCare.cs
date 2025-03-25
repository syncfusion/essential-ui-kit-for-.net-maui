using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialMAUIUIKit.Models.Dashboard
{
    public class DailyHealthCare : INotifyPropertyChanged
    {
        #region Field

        private IReadOnlyCollection<DailyChartModel>? chartData;

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
        public IReadOnlyCollection<DailyChartModel>? ChartData
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


            this.mealTime = new ObservableCollection<string>(selectedData.SelectMany(data => data.CaloriesConsumedPerMeal).Select(meal => meal.MealTime));
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

    public class DailyChartModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="ChartModel" /> class.
        /// </summary>
        /// <param name="dateTime">The date time</param>
        /// <param name="value">The value</param>
        public DailyChartModel(DateTime dateTime, double value)
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
}
