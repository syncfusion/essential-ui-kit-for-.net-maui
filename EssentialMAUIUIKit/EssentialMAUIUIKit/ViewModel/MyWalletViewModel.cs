using EssentialMAUIUIKit.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit
{
    class MyWalletViewModel : BaseViewModel
    {
        #region Fields

        private int selectedIndex;

        private double totalBalance;

        private string[] days;

        private string[] weeks;

        private string[] months;

        private string[]? section;

        private ObservableCollection<PaymentDetail>? weekListItems;

        private ObservableCollection<PaymentDetail>? monthListItems;

        private ObservableCollection<PaymentDetail>? yearListItems;

        private ObservableCollection<PaymentDetail>? listItems;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MyWalletViewModel" /> class.
        /// </summary>
        public MyWalletViewModel()
        {
            this.WeekData();
            this.MonthData();
            this.days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            this.weeks = new string[] { "Week 1", "Week 2", "Week 3", "Week 4" };
            this.months = new string[] { "Jan", "Mar", "May", "Jul", "Sep", "Nov" };
            this.ChartData = new ObservableCollection<TransactionChartData>();
            this.DataSource = new ObservableCollection<PaymentDetail>()
            {
                new PaymentDetail() { Duration = "Week" },
                new PaymentDetail() { Duration = "Month" },
                new PaymentDetail() { Duration = "Year" },
            };
            this.ListItems = this.WeekListItems;
        }

        #endregion

        #region Properties

        public ObservableCollection<TransactionChartData> ChartData { get; private set; }

        public ObservableCollection<PaymentDetail> DataSource { get; private set; }

        /// <summary>
        /// Gets the my wallet items collection in a week.
        /// </summary>
        public ObservableCollection<PaymentDetail>? WeekListItems
        {
            get
            {
                return this.weekListItems;
            }

            private set
            {
                this.SetProperty(ref this.weekListItems, value);
            }
        }

        /// <summary>
        /// Gets the my wallet items collection in a month.
        /// </summary>
        public ObservableCollection<PaymentDetail>? MonthListItems
        {
            get
            {
                return this.monthListItems;
            }

            private set
            {
                this.SetProperty(ref this.monthListItems, value);
            }
        }

        /// <summary>
        /// Gets the my wallet items collection in a year.
        /// </summary>
        public ObservableCollection<PaymentDetail>? YearListItems
        {
            get
            {
                return this.yearListItems;
            }

            private set
            {
                this.SetProperty(ref this.yearListItems, value);
            }
        }

        /// <summary>
        /// Gets the my wallet items collection.
        /// </summary>
        public ObservableCollection<PaymentDetail>? ListItems
        {
            get
            {
                return this.listItems;
            }

            private set
            {
                this.SetProperty(ref this.listItems, value);
            }
        }

        /// <summary>
        /// Gets or sets the selected index of combobox.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }

            set
            {
                this.selectedIndex = value;
                this.UpdateListViewData();
            }
        }

        /// <summary>
        /// Gets or sets the total balance remaining in the wallet.
        /// </summary>
        public double TotalBalance
        {
            get
            {
                return this.totalBalance;
            }

            set
            {
                this.SetProperty(ref this.totalBalance, value);
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Week data collection.
        /// </summary>
        private void WeekData()
        {
            this.weekListItems = new ObservableCollection<PaymentDetail>()
            {
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage1.png",
                    Name = "Phillip Estrada",
                    Title = "Cash Back",
                    Amount = 50,
                    Date = new DateTime(2019, 1, 7),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 50,
                    Date = new DateTime(2019, 1, 7),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage11.png",
                    Name = "Essie Hansen",
                    Title = "XXXXXXX6585",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "Refund",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Recharge",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage2.png",
                    Name = "Alta Sims",
                    Title = "Cash Back",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 4),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 40.25,
                    Date = new DateTime(2019, 1, 4),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage3.png",
                    Name = "Blake Moore",
                    Title = "XXXXXXX6585",
                    Amount = 45,
                    Date = new DateTime(2019, 1, 3),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 55,
                    Date = new DateTime(2019, 1, 3),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage4.png",
                    Name = "Chase Blair",
                    Title = "Refund",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 2),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 2),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage5.png",
                    Name = "Bernard Daniels",
                    Title = "Cash Back",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 1),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 1),
                    IsCredited = false,
                },
            };
        }

        /// <summary>
        /// Month data collection.
        /// </summary>
        private void MonthData()
        {
            this.monthListItems = new ObservableCollection<PaymentDetail>()
            {
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "Refund",
                    Amount = 85,
                    Date = new DateTime(2019, 1, 28),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 15.75,
                    Date = new DateTime(2019, 1, 26),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "XXXXXXX6585",
                    Amount = 65,
                    Date = new DateTime(2019, 1, 20),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Delivery Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 1, 18),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage9.png",
                    Name = "Bettie Conlon",
                    Title = "Refund",
                    Amount = 40,
                    Date = new DateTime(2019, 1, 12),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food Order Bill",
                    Amount = 60,
                    Date = new DateTime(2019, 1, 10),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage11.png",
                    Name = "Essie Hansen",
                    Title = "Cashback",
                    Amount = 30,
                    Date = new DateTime(2019, 1, 6),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Food order Bill",
                    Amount = 70,
                    Date = new DateTime(2019, 1, 5),
                    IsCredited = false,
                },
            };
        }

        /// <summary>
        /// Year data collection.
        /// </summary>
        private void YearData()
        {
            this.yearListItems = new ObservableCollection<PaymentDetail>()
            {
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "XXXXXXX6585",
                    Amount = 65,
                    Date = new DateTime(2019, 11, 24),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Delivery Bill",
                    Amount = 35,
                    Date = new DateTime(2019, 11, 2),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Amelia Coleman",
                    Title = "XXXXXXX6585",
                    Amount = 70,
                    Date = new DateTime(2019, 9, 21),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 30.50,
                    Date = new DateTime(2019, 9, 8),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage2.png",
                    Name = "Alta Sims",
                    Title = "XXXXXXX6585",
                    Amount = 50,
                    Date = new DateTime(2019, 7, 18),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 50,
                    Date = new DateTime(2019, 7, 12),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage3.png",
                    Name = "Blake Moore",
                    Title = "Refund",
                    Amount = 35,
                    Date = new DateTime(2019, 5, 21),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 65,
                    Date = new DateTime(2019, 5, 15),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage4.png",
                    Name = "Chase Blair",
                    Title = "XXXXXXX6585",
                    Amount = 20,
                    Date = new DateTime(2019, 3, 15),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 80,
                    Date = new DateTime(2019, 3, 5),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage6.png",
                    Name = "Arthur Kim",
                    Title = "Cashback",
                    Amount = 85,
                    Date = new DateTime(2019, 1, 26),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Title = "Credit Card Bill",
                    Amount = 15,
                    Date = new DateTime(2019, 1, 13),
                    IsCredited = false,
                },
            };
        }

        /// <summary>
        /// Method for update the listview items.
        /// </summary>
        private void UpdateListViewData()
        {
            switch (this.SelectedIndex)
            {
                case 0:
                    this.ListItems = this.WeekListItems;
                    this.section = this.days;
                    break;
                case 1:
                    this.ListItems = this.MonthListItems;
                    this.section = this.weeks;
                    break;
                case 2:
                    this.ListItems = this.YearListItems;
                    this.section = this.months;
                    break;
                default:
                    break;
            }

            this.UpdateChartData();
        }

        /// <summary>
        /// Method for update the chart data.
        /// </summary>
        private void UpdateChartData()
        {
            this.ChartData.Clear();
            this.TotalBalance = 0;

            var incomeCollection = this.ListItems?.Where(item => item.IsCredited).ToList();
            var expenseCollection = this.ListItems?.Where(item => !item.IsCredited).ToList();

            if (incomeCollection == null || expenseCollection == null)
            {
                return;
            }

            for (int i = 0; i < incomeCollection.Count; i++)
            {
                this.TotalBalance += incomeCollection[i].Amount;
                this.TotalBalance -= expenseCollection[i].Amount;
                if (this.section != null)
                {
                    this.ChartData.Add(new TransactionChartData(this.section[i], incomeCollection[i].Amount, expenseCollection[i].Amount, 4));
                }
            }
        }

        /// <summary>
        /// Invoked when an item is selected from the my wallet page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an view all button is selected from the my wallet page.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void ViewAllClicked(object selectedItem)
        {
            // Do something
        }

        #endregion
    }

    public class PaymentDetail : INotifyPropertyChanged
    {
        #region Fields

        private string? profileImage;

        private bool isCredited;

        #endregion

        #region Events

        /// <summary>
        /// The declaration of the property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        public string ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public string? Duration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the transaction type is income or expense.
        /// </summary>
        public bool IsCredited
        {
            get
            {
                return this.isCredited;
            }

            set
            {
                this.isCredited = value;
                this.OnPropertyChanged(nameof(this.IsCredited));
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

    public class TransactionChartData
    {
        #region Constructor

        /// <summary>
        /// Method for transaction chart data.
        /// </summary>
        /// <param name="section">The section</param>
        /// <param name="incomeValue">The income value</param>
        /// <param name="expenseValue">The expense value</param>
        /// <param name="difference">The difference</param>
        public TransactionChartData(string section, double incomeValue, double expenseValue, double difference)
        {
            this.Section = section;
            this.Income = incomeValue;
            this.Expense = expenseValue;
            this.Difference = difference;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the X-value.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the income value.
        /// </summary>
        public double Income { get; set; }

        /// <summary>
        /// Gets or sets the expense value.
        /// </summary>
        public double Expense { get; set; }

        /// <summary>
        /// Gets or sets the gap value for data.
        /// </summary>
        public double Difference { get; set; }

        #endregion
    }
}
