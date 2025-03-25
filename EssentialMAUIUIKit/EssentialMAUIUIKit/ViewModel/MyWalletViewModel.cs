using EssentialMAUIUIKit.ViewModel;
using Syncfusion.Maui.DataSource.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

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

        private double layoutHeight;

        private ObservableCollection<PaymentDetail> weekListItems;

        private ObservableCollection<PaymentDetail> monthListItems;

        private ObservableCollection<PaymentDetail> yearListItems;

        private ObservableCollection<PaymentDetail> listItems;

        private ObservableCollection<CardDetails>? cardDetails;

        private ObservableCollection<CardDetails>? filteredCardDetails;

        private CardDetails? selectedCard;

        /// <summary>
        /// To update pages that can be navigated from dashboard.
        /// </summary>
        private ObservableCollection<MyWalletMenuItems>? menuItems;

        /// <summary>
        /// To update label text for chart
        /// </summary>
        private string? chartLabel;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="MyWalletViewModel" /> class.
        /// </summary>
        public MyWalletViewModel()
        {
            this.weekListItems = this.WeekData();
            this.monthListItems = this.MonthData();
            this.yearListItems =  this.YearData();
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
            this.menuItems = new ObservableCollection<MyWalletMenuItems>
            {
                new MyWalletMenuItems { Name = "Dashboard", IsSelected = true },
                new MyWalletMenuItems { Name = "Transactions" },
                new MyWalletMenuItems { Name = "Payments" },
                new MyWalletMenuItems { Name = "Wallet" },
                new MyWalletMenuItems { Name = "Settings" }
            };
         
            this.listItems = this.WeekListItems;

            // Group transactions by date, excluding "Today" from having a header
            this.GroupedTransactions = new ObservableCollection<TransactionGroup>(
                this.ListItems
                    .GroupBy(t =>
                    {
                        if (t.Date.Date == DateTime.Now.Date) return null; // Skip header for today's transactions
                        if (t.Date.Date == DateTime.Now.Date.AddDays(-1)) return "Yesterday";
                        return t.Date.ToString("dd MMM yyyy");
                    })
                    .Where(g => g.Key != null) // Exclude null headers
                    .Select(g => new TransactionGroup(g.Key, g.ToObservableCollection<PaymentDetail>()))
            );

            // Add today's transactions as a flat list without a header
            var todaysTransactions = this.ListItems
                .Where(t => t.Date.Date == DateTime.Now.Date)
                .ToObservableCollection();

            if (todaysTransactions.Any())
            {
                GroupedTransactions.Insert(0, new TransactionGroup(null, todaysTransactions));
            }

            // Add Card details
            this.UpdateCardDetails();
            this.UpdateSelectedCards();
            this.ProfileImage = "profileavatar.png";
            this.DashboardTitle = "Pay Karo";
            this.chartLabel = "Weekly Analysis";
            this.LayoutHeight = DeviceDisplay.MainDisplayInfo.Height > 280 ? DeviceDisplay.MainDisplayInfo.Height - 280 : 400;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the weekly analysis chart data
        /// </summary>
        public ObservableCollection<TransactionChartData> ChartData { get; private set; }

        /// <summary>
        /// Gets or sets the collection of payment details
        /// </summary>
        public ObservableCollection<PaymentDetail> DataSource { get; private set; }

        /// <summary>
        /// Gets or sets the weekly payment data
        /// </summary>
        public ObservableCollection<PaymentDetail> WeekListItems
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
        /// Gets or sets the monthly payment data
        /// </summary>
        public ObservableCollection<PaymentDetail> MonthListItems
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
        /// Gets or sets the yearly payment data
        /// </summary>
        public ObservableCollection<PaymentDetail> YearListItems
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
        public ObservableCollection<PaymentDetail> ListItems
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
        /// Gets or sets the selected index.
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

        /// <summary>
        /// Gets the list of WalletMenuItemList.
        /// </summary>
        public ObservableCollection<MyWalletMenuItems>? MenuItemList
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
        /// Gets or sets the CardDetails in the wallet.
        /// </summary>
        public ObservableCollection<CardDetails>? CardDetails
        {
            get
            {
                return this.cardDetails;
            }

            set
            {
                this.cardDetails = value;               
            }
        }

        /// <summary>
        /// Gets or sets the CardDetails in the wallet.
        /// </summary>
        public ObservableCollection<CardDetails>? FilteredCardDetails
        {
            get
            {
                return this.filteredCardDetails;
            }

            set
            {
                this.filteredCardDetails = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for selected card
        /// </summary>
        public CardDetails? SelectedCard
        {
            get
            {
                return this.selectedCard;
            }

            set
            {
                this.selectedCard = value;
            }
        }


        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the dashboard title.
        /// </summary>
        public string DashboardTitle { get; set; }

        /// <summary>
        /// Gets or sets the day wise Transaction Group .
        /// </summary>
        public ObservableCollection<TransactionGroup> GroupedTransactions { get; set; }

        /// <summary>
        /// Gets the label for Analysis Chart
        /// </summary>
        public string? ChartLabel
        {
            get => chartLabel;
            set
            {
                if (chartLabel != value)
                {
                    chartLabel = value;
                }
            }        
        }

        /// <summary>
        /// Gets or sets a value for layout height.
        /// </summary>
        public double LayoutHeight
        {
            get
            {
                return this.layoutHeight;
            }

            set
            {
                this.layoutHeight = value;
            }
        }

        #endregion

        #region Methods        

        /// <summary>
        /// Week data collection.
        /// </summary>
        private ObservableCollection<PaymentDetail> WeekData()
        {
            return new ObservableCollection<PaymentDetail>()
            {
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage1.png",
                    Name = "Tina hermandez",
                    Amount = 50,
                    Date = DateTime.Now.AddHours(-1),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Chris steve",
                    Amount = 50,
                    Date = DateTime.Now.AddHours(-2).AddMinutes(-35),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage11.png",
                    Name = "Ovenfresh paris",
                    Amount = 60,
                    Date = DateTime.Now.AddHours(-3).AddMinutes(-10),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Shell petrol bunk",                   
                    Amount = 40,
                    Date = DateTime.Now.AddHours(-4).AddMinutes(-50),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage7.png",
                    Name = "Diana",
                    Amount = 40,
                    Date = DateTime.Now.AddDays(-1).AddMinutes(-50),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Amount = 60,
                    Date = DateTime.Now.AddDays(-1).AddHours(-3).AddMinutes(-50),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage2.png",
                    Name = "Alta Sims",
                    Amount = 60,
                    Date = DateTime.Now.AddDays(-1).AddHours(-4).AddMinutes(-30),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Amount = 40.25,
                    Date = DateTime.Now.AddDays(-1).AddHours(-5).AddMinutes(-25),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage3.png",
                    Name = "Blake Moore",
                    Amount = 45,
                    Date = DateTime.Now.AddDays(-1).AddHours(-6).AddMinutes(-10),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Amount = 55,
                    Date = DateTime.Now.AddDays(-1).AddHours(-8).AddMinutes(-20),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage4.png",
                    Name = "Chase Blair",
                    Amount = 65,
                    Date = DateTime.Now.AddDays(-2).AddHours(-4).AddMinutes(-30),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Amount = 35,
                    Date = DateTime.Now.AddDays(-3).AddHours(-7).AddMinutes(-10),
                    IsCredited = false,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage5.png",
                    Name = "Bernard Daniels",
                    Amount = 35,
                    Date = DateTime.Now.AddDays(-4).AddHours(-8).AddMinutes(-10),
                    IsCredited = true,
                },
                new PaymentDetail()
                {
                    ProfileImage = "ProfileImage8.png",
                    Name = "Nell Sanchez",
                    Amount = 65,
                    Date = DateTime.Now.AddDays(-5).AddHours(-9).AddMinutes(-18),
                    IsCredited = false,
                },
            };
        }

        /// <summary>
        /// Month data collection.
        /// </summary>
        private ObservableCollection<PaymentDetail> MonthData()
        {
            return new ObservableCollection<PaymentDetail>()
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
        private ObservableCollection<PaymentDetail> YearData()
        {
            return new ObservableCollection<PaymentDetail>()
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
        /// Method for update the selected index items.
        /// </summary>
        private void UpdateListViewData()
        {
            switch (this.SelectedIndex)
            {
                case 0:
                    this.ListItems = this.WeekListItems;
                    this.section = this.days;
                    this.chartLabel = "Weekly Analysis";
                    break;
                case 1:
                    this.ListItems = this.MonthListItems;
                    this.section = this.weeks;
                    this.chartLabel = "Monthly Analysis";
                    break;
                case 2:
                    this.ListItems = this.YearListItems;
                    this.section = this.months;
                    this.chartLabel = "Yearly Analysis";
                    break;
                default:
                    break;
            }
            this.UpdateChartData();
        }

        /// <summary>
        /// Updates the chart data to be displayed
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
        /// Updates the card details.
        /// </summary>
        private void UpdateCardDetails()
        {
            this.CardDetails = new ObservableCollection<CardDetails>
            {
                new CardDetails
                {
                    CardType = "CREDIT CARD",
                    CardLogo = "mastercardlogo.png",
                    CardNumber = "XXXX XXXX XXXX 9876",
                    CardHolderName = "John Steve Chris",
                    CardExpiry = new DateTime(2026,09,30),
                    CardCVV = 897,
                    AvailableBalance = 12.09,
                    IsSelected = true,
                    ColorGradientStart = Color.FromArgb("9F60FD"),
                    ColorGradientStop = Color.FromArgb("D957BC")
                },
                new CardDetails
                {
                    CardType = "DEBIT CARD",
                    CardLogo = "visalogo.png",
                    CardNumber = "XXXX XXXX XXXX 4567",
                    CardHolderName = "Diana Chris",
                    CardExpiry = new DateTime(2028,12,30),
                    CardCVV = 845,
                    AvailableBalance = 15.00,
                    ColorGradientStart = Color.FromArgb("6DB0FF"),
                    ColorGradientStop = Color.FromArgb("6957D9")
                },
                // Last element to enable add new card
                new CardDetails
                {
                    IsVisible = false
                }
            };

            this.FilteredCardDetails = new ObservableCollection<CardDetails>(this.CardDetails.Take(2));
        }

        /// <summary>
        /// To display the selected card details
        /// </summary>
        public void UpdateSelectedCards()
        {
            // Filter only selected cards
            this.SelectedCard = CardDetails?.Where(card => card.IsSelected).FirstOrDefault();
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

    public class CardDetails
    {
        private Color? _colorGradientStart = Color.FromArgb("6DB0FF");

        private Color? _colorGradientStop = Color.FromArgb("6957D9");

        #region properties

        /// <summary>
        /// Updates the card type.
        /// </summary>
        public string? CardType { get; set; }

        /// <summary>
        /// Updates the card type logo.
        /// </summary>
        public string? CardLogo { get; set; }

        /// <summary>
        /// Updates the card number.
        /// </summary>
        public string? CardNumber { get; set; }

        /// <summary>
        /// Updates the card holder name.
        /// </summary>
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Updates the card expiry date.
        /// </summary>
        public DateTime CardExpiry { get; set; }

        /// <summary>
        /// Updates the card cvv.
        /// </summary>
        public int CardCVV { get; set; }

        /// <summary>
        /// Updates the available balance in card.
        /// </summary>
        public double AvailableBalance { get; set; }

        /// <summary>
        /// Updates the color gradient for each card.
        /// </summary>
        public Color? ColorGradientStart
        {
            get => this._colorGradientStart;
            set
            {
                this._colorGradientStart = value;
            }
        }

        /// <summary>
        /// Updates the color gradient for each card.
        /// </summary>
        public Color? ColorGradientStop 
        {
            get => this._colorGradientStop;
            set
            {
                this._colorGradientStop = value;
            }            
        }

        /// <summary>
        /// Updates the selected card
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// Displays add new card option
        /// </summary>
        public bool IsVisible { get; set; } = true;

        #endregion
    }

    public class MyWalletMenuItems
    {
        /// <summary>
        /// Displays menu items in left panel.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the property to update selected menu 
        /// </summary>
        public bool IsSelected { get; set; }
    }

    public class TransactionGroup : ObservableCollection<PaymentDetail>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title to group transactions
        /// </summary>
        public string? Title { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="TransactionGroup" /> class.
        /// </summary>
        public TransactionGroup(string? title, ObservableCollection<PaymentDetail> transactions)
            : base(transactions)
        {
            Title = title;
        }

        #endregion
    }    

    public class CardTemplateSelector : DataTemplateSelector
    {
        #region Properties

        public required DataTemplate RegularTemplate { get; set; }
        public required DataTemplate LastItemTemplate { get; set; }
        public ObservableCollection<CardDetails>? ItemsSource { get; set; }

        #endregion

        #region Methods

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {              
            if(((CardDetails)item).IsVisible == false)
            {
                // Return LastItemTemplate for the last item
                return LastItemTemplate;
            }
            // Return RegularTemplate for other items
            return RegularTemplate;
        }

        #endregion
    }

    public class NullToBooleanConverter : IValueConverter
    {
        #region Methods

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
