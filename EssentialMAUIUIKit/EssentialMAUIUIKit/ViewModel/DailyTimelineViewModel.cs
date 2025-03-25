namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.ViewModel;
    using System.Collections.ObjectModel;

    public class DailyTimelineViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<DailyActivity> dailyActivities;

        private DateTime _selectedDate = DateTime.Today;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance for the <see cref="DailyTimelineViewModel" /> class.
        /// </summary>
        public DailyTimelineViewModel()
        {
            this.dailyActivities = new ObservableCollection<DailyActivity>()
            {
                new DailyActivity(){Time = "7 AM", Icon = "\ue70a", ActivityTitle="Gym", ActivityDescription = "Have to do chest and lat workouts and need to take supplement"},
                new DailyActivity(){Time = "9 AM", Icon = "\ue703", ActivityTitle="Breakfast", ActivityDescription = "Toast, boiled egg, pineapple, orange juice"},
                new DailyActivity(){Time = "10 AM", Icon = "\ue707", ActivityTitle="Meeting-college friends", ActivityDescription = "Daily Grind, Co-ordinating gifts for mel’s baby shower"},
                new DailyActivity(){Time = "12 PM", Icon = "\ue70c", ActivityTitle="Photography Exhibit", ActivityDescription = "At the art center, parking deck on main st, Meet john and kate at entrance"},
                new DailyActivity(){Time = "1 PM", Icon = "\ue700", ActivityTitle="Lunch", ActivityDescription = "Lunch at oyalo pizza"},
                new DailyActivity(){Time = "6 PM", Icon = "\ue701", ActivityTitle="Snacks", ActivityDescription = "Apple, banana, juice"},
            };
            this.dailyActivities[this.dailyActivities.Count - 1].IsLastItem = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value for Daily Activities.
        /// </summary>
        public ObservableCollection<DailyActivity> DailyActivities
        {
            get
            {
                return this.dailyActivities;
            }
            set
            {
                this.dailyActivities = value;
            }
        }

        /// <summary>
        /// Gets or sets a value for SelectedDate
        /// </summary>
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }      

        #endregion
    }

    public class DailyActivity
    {
        public string? Time { get; set; }

        public string? Icon { get; set; }

        public string? ActivityTitle { get; set; }

        public string? ActivityDescription { get; set; }

        public bool? IsLastItem { get; set; }
    }
}    