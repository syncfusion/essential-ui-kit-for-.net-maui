using EssentialMAUIUIKit.ViewModel;
using Syncfusion.Maui.Gauges;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit
{
    public class DailyCaloriesReportViewModel : BaseViewModel
    {
        #region Field

        private ObservableCollection<Calorie>? selectedCalorieItems;

        private ObservableCollection<RangePointer>? pointers;

        private double scaleEndValue;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="DailyCaloriesReportViewModel" /> class.
        /// </summary>
        public DailyCaloriesReportViewModel()
        {
            this.Pointers = new ObservableCollection<RangePointer>();

            this.CardItems = new List<CaloriesCard>()
            {
                new CaloriesCard()
                {
                    Icon = "\ue750",
                    Session = "Breakfast",
                    IsSelected = true,
                },
                new CaloriesCard()
                {
                    Icon = "\ue74e",
                    Session = "Lunch",
                },
                new CaloriesCard()
                {
                    Icon = "\ue74f",
                    Session = "Dinner",
                },
                new CaloriesCard()
                {
                    Icon = "\ue74b",
                    Session = "Snack",
                },
            };

            this.BreakfastCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 30, Nutrient = "Fiber", Indicator = "#5588fe",
                },
                new Calorie()
                {
                    Quantity = 260, Nutrient = "Protein", Indicator = "#7cf74c",
                },
                new Calorie()
                {
                    Quantity = 80, Nutrient = "Carbs", Indicator = "#fd50c8",
                },
                new Calorie()
                {
                    Quantity = 100, Nutrient = "Calcium", Indicator = "#ffdd7c",
                },
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fat", Indicator = "#fe6751",
                },
                new Calorie()
                {
                    Quantity = 60, Nutrient = "Vitamins", Indicator = "#7d46c2",
                },
            };

            this.DinnerCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 20, Nutrient = "Fibre", Indicator = "#5588fe",
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c",
                },
                new Calorie()
                {
                    Quantity = 50, Nutrient = "Carbs", Indicator = "#fd50c8",
                },
                new Calorie()
                {
                    Quantity = 140, Nutrient = "Calcium", Indicator = "#ffdd7c",
                },
                new Calorie()
                {
                    Quantity = 20, Nutrient = "Fat", Indicator = "#fe6751",
                },
                new Calorie()
                {
                    Quantity = 100, Nutrient = "Vitamins", Indicator = "#7d46c2",
                },
            };

            this.LunchCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fibre", Indicator = "#5588fe",
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c",
                },
                new Calorie()
                {
                    Quantity = 120, Nutrient = "Carbs", Indicator = "#fd50c8",
                },
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Calcium", Indicator = "#ffdd7c",
                },
                new Calorie()
                {
                    Quantity = 50, Nutrient = "Fat", Indicator = "#fe6751",
                },
                new Calorie()
                {
                    Quantity = 90, Nutrient = "Vitamins", Indicator = "#7d46c2",
                },
            };

            this.SnackCalories = new ObservableCollection<Calorie>()
            {
                new Calorie()
                {
                    Quantity = 40, Nutrient = "Fibre", Indicator = "#5588fe",
                },
                new Calorie()
                {
                    Quantity = 210, Nutrient = "Protein", Indicator = "#7cf74c",
                },
                new Calorie()
                {
                    Quantity = 70, Nutrient = "Carbs", Indicator = "#fd50c8",
                },
                new Calorie()
                {
                    Quantity = 130, Nutrient = "Calcium", Indicator = "#ffdd7c",
                },
                new Calorie()
                {
                    Quantity = 60, Nutrient = "Fat", Indicator = "#fe6751",
                },
                new Calorie()
                {
                    Quantity = 80, Nutrient = "Vitamins", Indicator = "#7d46c2",
                },
            };

            this.SelectedSessionCaloriesCard = this.CardItems[0];

            this.SelectedCalorieItems = this.BreakfastCalories;

            this.SessionCommand = new Command(this.SessionButtonClicked);

            this.UpdateGauge();
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the session button is clicked.
        /// </summary>
        public Command SessionCommand { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the session card items collection.
        /// </summary>
        public List<CaloriesCard> CardItems { get; private set; }

        /// <summary>
        /// Gets the breakfast calories collection.
        /// </summary>
        public ObservableCollection<Calorie> BreakfastCalories { get; private set; }

        /// <summary>
        /// Gets the lunch calories collection.
        /// </summary>
        public ObservableCollection<Calorie> LunchCalories { get; private set; }

        /// <summary>
        /// Gets the dinner calories collection.
        /// </summary>
        public ObservableCollection<Calorie> DinnerCalories { get; private set; }

        /// <summary>
        /// Gets the snack calories collection.
        /// </summary>
        public ObservableCollection<Calorie> SnackCalories { get; private set; }

        /// <summary>
        /// Gets the selected session calorie item.
        /// </summary>
        public ObservableCollection<Calorie>? SelectedCalorieItems
        {
            get
            {
                return this.selectedCalorieItems;
            }

            private set
            {
                this.SetProperty(ref this.selectedCalorieItems, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected session card item.
        /// </summary>
        public CaloriesCard SelectedSessionCaloriesCard { get; set; }

        /// <summary>
        /// Gets the calorie range.
        /// </summary>
        public ObservableCollection<RangePointer>? Pointers
        {
            get { return this.pointers; }

            private set { this.SetProperty(ref this.pointers, value); }
        }

        /// <summary>
        /// Gets or sets the gauge scale end value
        /// </summary>
        public double ScaleEndValue
        {
            get { return this.scaleEndValue; }

            set { this.SetProperty(ref this.scaleEndValue, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the session button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void SessionButtonClicked(object obj)
        {
            this.SelectedSessionCaloriesCard.IsSelected = false;

            var context = obj as CaloriesCard;
            if (context == null)
            {
                return;
            }

            context.IsSelected = true;
            this.SelectedSessionCaloriesCard = context;
            switch (this.SelectedSessionCaloriesCard.Session)
            {
                case "Breakfast":
                    {
                        this.SelectedCalorieItems = this.BreakfastCalories;
                        this.UpdateGauge();
                        break;
                    }

                case "Lunch":
                    {
                        this.SelectedCalorieItems = this.LunchCalories;
                        this.UpdateGauge();
                        break;
                    }

                case "Dinner":
                    {
                        this.SelectedCalorieItems = this.DinnerCalories;
                        this.UpdateGauge();
                        break;
                    }

                case "Snack":
                    {
                        this.SelectedCalorieItems = this.SnackCalories;
                        this.UpdateGauge();
                        break;
                    }
            }
        }

        /// <summary>
        /// Update the gauge range.
        /// </summary>
        private void UpdateGauge()
        {
        }

        #endregion
    }

    public class Calorie
    {
        #region Property

        /// <summary>
        /// Gets or sets the property that has been displays the quantity.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the nutrients.
        /// </summary>
        public string? Nutrient { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with button which displays the card items.
        /// </summary>
        public string? Indicator { get; set; }

        #endregion
    }

    public class CaloriesCard : INotifyPropertyChanged
    {
        #region fields

        /// <summary>
        /// To store the button checkable status.
        /// </summary>
        private bool isSelected;

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that has been bound with button which displays the card items.
        /// </summary>
        public string? Session { get; set; }

        /// <summary>
        /// Gets or sets the property that has been displays the icon.
        /// </summary>
        public string? Icon { get; set; }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }

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
