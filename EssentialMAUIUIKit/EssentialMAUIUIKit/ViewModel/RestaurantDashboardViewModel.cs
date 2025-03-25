namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.ViewModel;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class RestaurantDashboardViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region fields

        private ObservableCollection<RestaurantDashboardMenuItem> menuItems;

        private ObservableCollection<RestaurantOrder> orderDetails;

        private double ordersLayoutHeight;

        private double currentWeekRevenue;

        private double pastWeekRevenue;

        private double percentageChange;

        private int currentWeekOrdersCount;

        private int pastWeekOrdersCount;

        private ObservableCollection<RevenueSummary> currentWeekSummary;

        private ObservableCollection<string> orderDetailsHeader;

        #endregion

        #region constructor

        public RestaurantDashboardViewModel()
        {
            this.orderDetails = new ObservableCollection<RestaurantOrder>();
            this.currentWeekSummary = new ObservableCollection<RevenueSummary>();
            this.orderDetailsHeader = new ObservableCollection<string>();
            this.menuItems = new ObservableCollection<RestaurantDashboardMenuItem>
            {
                new RestaurantDashboardMenuItem { Name = "Dashboard", IsSelected = true },
                new RestaurantDashboardMenuItem { Name = "Orders" },
                new RestaurantDashboardMenuItem { Name = "Settings" }
            };
            this.DashboardTitle = "Foodfun";
            this.ProfileImage = "profileavatar.png";
            this.UpdateOrderDetails();
            this.UpdateRevenueSummary();
            this.currentWeekRevenue = (double)this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-7) && order.Date <= DateTime.Now && order.Status == "Completed").Sum(order => order.Amount);            
            this.pastWeekRevenue = (double)this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-14) && order.Date <= DateTime.Now.AddDays(-8) && order.Status == "Completed").Sum(order => order.Amount);
            this.percentageChange = pastWeekRevenue != 0 ? ((currentWeekRevenue - pastWeekRevenue) / pastWeekRevenue) * 100 : 0;            
            if (Application.Current != null)
            {
                this.OrdersLayoutHeight = DeviceDisplay.MainDisplayInfo.Height > 280 ? DeviceDisplay.MainDisplayInfo.Height - 280 : 400;
                Application.Current.RequestedThemeChanged += (s, e) =>
                {
                    UpdateSummaryOnThemeChange();
                };
            }            
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the dashboard title.
        /// </summary>
        public string DashboardTitle { get; set; }

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets the list of RestaurantDashboardMenuItems.
        /// </summary>
        public ObservableCollection<RestaurantDashboardMenuItem> MenuItemList
        {
            get
            {
                return this.menuItems;
            }

            set
            {
                this.SetProperty(ref this.menuItems, value);
            }
        }

        /// <summary>
        /// Gets the list of Order details.
        /// </summary>
        public ObservableCollection<RestaurantOrder> OrderDetails
        {
            get
            {
                return this.orderDetails;
            }

            set
            {
                this.SetProperty(ref this.orderDetails, value);
            }
        }

        /// <summary>
        /// Gets the current week revenue details
        /// </summary>
        public double CurrentWeekRevenue
        {
            get
            {
                return this.currentWeekRevenue;
            }

            set
            {
                this.SetProperty(ref this.currentWeekRevenue, value);
            }
        }

        /// <summary>
        /// Gets the current week revenue summary details
        /// </summary>
        public ObservableCollection<RevenueSummary> CurrentWeekSummary
        { 
            get
            {
                return this.currentWeekSummary;
            }

            set
            {
                this.SetProperty(ref this.currentWeekSummary, value);
                OnPropertyChanged("CurrentWeekSummary");
            }
        }

        public double OrdersLayoutHeight
        {
            get
            {
                return this.ordersLayoutHeight;
            }
            set
            {
                this.ordersLayoutHeight = value;
            }
        }

        public ObservableCollection<string> OrderDetailsHeader
        {
            get { return this.orderDetailsHeader;  }

            set { this.SetProperty(ref this.orderDetailsHeader, value); }
        }

        // PropertyChanged event handler
        public new event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region methods

        private void OnDetailsClicked()
        {
            // Action on click
            
        }

        private void UpdateOrderDetails()
        {
            this.orderDetails = new ObservableCollection<RestaurantOrder>
            {                
                new RestaurantOrder { OrderID = 9993, CustomerID = 921, Date = DateTime.Now.AddDays(-13), PaymentMode = "Gpay", Status = "Pending", Amount = 01.00m },
                new RestaurantOrder { OrderID = 9994, CustomerID = 925, Date = DateTime.Now.AddDays(-12), PaymentMode = "Phonepay", Status = "Completed", Amount = 05.00m },
                new RestaurantOrder { OrderID = 9995, CustomerID = 925, Date = DateTime.Now.AddDays(-11), PaymentMode = "Debit Card", Status = "Completed", Amount = 3.00m },
                new RestaurantOrder { OrderID = 9996, CustomerID = 931, Date = DateTime.Now.AddDays(-11), PaymentMode = "Cash", Status = "Completed", Amount = 2.00m },
                new RestaurantOrder { OrderID = 9997, CustomerID = 910, Date = DateTime.Now.AddDays(-10), PaymentMode = "Cash", Status = "Completed", Amount = 2.00m },
                new RestaurantOrder { OrderID = 9998, CustomerID = 922, Date = DateTime.Now.AddDays(-9), PaymentMode = "Gpay", Status = "Completed", Amount = 3.00m },
                new RestaurantOrder { OrderID = 9999, CustomerID = 927, Date = DateTime.Now.AddDays(-8), PaymentMode = "Phonepay", Status = "Completed", Amount = 02.00m },
                new RestaurantOrder { OrderID = 9999, CustomerID = 921, Date = DateTime.Now.AddDays(-7), PaymentMode = "Phonepay", Status = "Completed", Amount = 02.00m },
                new RestaurantOrder { OrderID = 10000, CustomerID = 928, Date = DateTime.Now.AddDays(-7), PaymentMode = "Debit Card", Status = "Completed", Amount = 04.00m },
                new RestaurantOrder { OrderID = 10001, CustomerID = 932, Date = DateTime.Now.AddDays(-6), PaymentMode = "Cash", Status = "Completed", Amount = 05.50m },
                new RestaurantOrder { OrderID = 10002, CustomerID = 934, Date = DateTime.Now.AddDays(-6), PaymentMode = "Credit Card", Status = "Failed", Amount = 02.00m },
                new RestaurantOrder { OrderID = 10003, CustomerID = 936, Date = DateTime.Now.AddDays(-5), PaymentMode = "Gpay", Status = "Pending", Amount = 03.00m },
                new RestaurantOrder { OrderID = 10004, CustomerID = 937, Date = DateTime.Now.AddDays(-4), PaymentMode = "Phonepay", Status = "Completed", Amount = 07.50m },
                new RestaurantOrder { OrderID = 10005, CustomerID = 921, Date = DateTime.Now.AddDays(-4), PaymentMode = "Debit Card", Status = "Completed", Amount = 9.00m },
                new RestaurantOrder { OrderID = 10006, CustomerID = 925, Date = DateTime.Now.AddDays(-4), PaymentMode = "Cash", Status = "Completed", Amount = 10.50m },
                new RestaurantOrder { OrderID = 10007, CustomerID = 931, Date = DateTime.Now.AddDays(-3), PaymentMode = "Cash", Status = "Completed", Amount = 6.00m },
                new RestaurantOrder { OrderID = 10008, CustomerID = 910, Date = DateTime.Now.AddDays(-2), PaymentMode = "Gpay", Status = "Completed", Amount = 5.00m },
                new RestaurantOrder { OrderID = 10009, CustomerID = 922, Date = DateTime.Now.AddDays(-2), PaymentMode = "Phonepay", Status = "Completed", Amount = 07.00m },
                new RestaurantOrder { OrderID = 10010, CustomerID = 927, Date = DateTime.Now, PaymentMode = "Debit Card", Status = "Completed", Amount = 09.00m }
            };

            this.orderDetailsHeader = new ObservableCollection<string>
            {
                "OrderID", "Date", "Payment mode", "Status", "Details"
            };

            foreach (var order in this.orderDetails)
            {
                switch (order.Status)
                {                    
                    case "Failed":
                        order.StatusColor = Colors.Red;
                        break;
                    case "Pending":
                        order.StatusColor = Colors.Blue;  
                        break;
                    default:
                        order.StatusColor = Colors.Green;
                        break;
                }
            }


        }

        public void UpdateRevenueSummary()
        {
            // Revenue summary details
            this.currentWeekRevenue = (double)this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-7) && order.Date <= DateTime.Now && order.Status == "Completed").Sum(order => order.Amount);
            this.pastWeekRevenue = (double)this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-14) && order.Date <= DateTime.Now.AddDays(-8) && order.Status == "Completed").Sum(order => order.Amount);
            double revenueDifference = this.currentWeekRevenue - this.pastWeekRevenue;
            string weeklyRevenueDifference = "%" + revenueDifference.ToString() + ((revenueDifference >= 0) ? "+" : "-");

            //Orders summary details
            this.currentWeekOrdersCount = this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-7) && order.Date <= DateTime.Now && order.Status == "Completed").Count();
            this.pastWeekOrdersCount = this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-14) && order.Date <= DateTime.Now.AddDays(-8) && order.Status == "Completed").Count();
            int orderDifference = this.currentWeekOrdersCount - this.pastWeekOrdersCount;
            string weeklyOrderDifference = orderDifference.ToString() + ((orderDifference >= 0) ? " new" : " less");

            //Customers summary details
            var currentWeekCustomers = this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-7) && order.Date <= DateTime.Now && order.Status == "Completed").Select(order => order.CustomerID).Distinct().Count();
            var pastWeekCustomers = this.OrderDetails.Where(order => order.Date >= DateTime.Now.AddDays(-14) && order.Date <= DateTime.Now.AddDays(-8) && order.Status == "Completed").Select(order => order.CustomerID).Distinct().Count();
            var difference = currentWeekCustomers - pastWeekCustomers;
            var percentage = ((currentWeekCustomers - pastWeekCustomers) / (double)pastWeekCustomers) * 100;
            var weeklyCustomerCountDifference = percentage >= 0 ? $"%{percentage:F2}+" : $"%{percentage:F2}-";

            this.currentWeekSummary = new ObservableCollection<RevenueSummary>{
                new RevenueSummary { SummaryTitle = "Orders", SummaryIcon="\ue709;", IconColor = Color.FromArgb("#0D5CDD"),IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#EFF1FF") : Color.FromArgb("#0D2354"), CurrentWeekValue = this.currentWeekOrdersCount.ToString(), DifferenceValue = weeklyOrderDifference, DifferenceDescription = "orders" },
                new RevenueSummary { SummaryTitle = "Revenue",  SummaryIcon="\ue70e;", IconColor = Color.FromArgb("#1C7E39"),IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#CEFFC9") : Color.FromArgb("#1C2F1E"), CurrentWeekValue = "$"+((this.currentWeekRevenue).ToString()), DifferenceValue = weeklyRevenueDifference, DifferenceDescription = "Since last week" },
                new RevenueSummary { SummaryTitle = "Customers",  SummaryIcon="\ue707;", IconColor = Color.FromArgb("#875F0D"),IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#FFEFDD") : Color.FromArgb("#34240D"), CurrentWeekValue = currentWeekCustomers.ToString(), DifferenceValue = weeklyCustomerCountDifference, DifferenceDescription = "Since last week"}
            };
        }

        private void UpdateSummaryOnThemeChange()
        {
            foreach(var weekSummary in this.currentWeekSummary)
            {
                switch(weekSummary.SummaryTitle)
                {
                    case "Orders":
                        weekSummary.IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#EFF1FF") : Color.FromArgb("#0D2354");
                        break;
                    case "Revenue":
                        weekSummary.IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#CEFFC9") : Color.FromArgb("#1C2F1E");
                        break;
                    default:
                        weekSummary.IconBackground = Application.Current?.RequestedTheme == AppTheme.Light ? Color.FromArgb("#FFEFDD") : Color.FromArgb("#34240D");
                        break;
                }
            }
        }

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

    public class RestaurantOrder
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentMode { get; set; }
        public string? Status { get; set; }
        public decimal Amount { get; set; }
        public Color? StatusColor { get; set; }
    }

    public class RevenueSummary : INotifyPropertyChanged
    {
        #region Fields

        private string? summaryTitle;
        private string? summaryIcon;
        private Color? iconColor;
        private Color? iconBackground;
        private string? currentWeekValue;
        private string? differenceValue;
        private Color? differenceColorcode;
        private string? differenceDescription;

        #endregion

        #region Properties

        public string? SummaryTitle
        {
            get
            {
                return this.summaryTitle;
            }
            set
            {
                this.summaryTitle = value;
            }
        }
        public string? SummaryIcon
        {
            get
            {
                return this.summaryIcon;
            }
            set
            {
                this.summaryIcon = value;
            }
        }
        public Color? IconColor
        {
            get
            {
                return this.iconColor;
            }
            set
            {
                this.iconColor = value;
            }
        }
        public Color? IconBackground 
        {
            get
            {
                return this.iconBackground;
            }
            set 
            {
                this.iconBackground = value;
                OnPropertyChanged("IconBackground");
            }
        }
        public string? CurrentWeekValue
        {
            get
            {
                return this.currentWeekValue;
            }
            set
            {
                this.currentWeekValue = value;
            }
        }
        public string? DifferenceValue
        {
            get
            {
                return this.differenceValue;
            }
            set
            {
                this.differenceValue = value;
            }
        }
        public Color? DifferenceColorCode
        {
            get
            {
                return this.differenceColorcode;
            }
            set
            {
                this.differenceColorcode = value;
            }
        }
        public string? DifferenceDescription
        {
            get
            {
                return this.differenceDescription;
            }
            set
            {
                this.differenceDescription = value;
            }
        }

        // PropertyChanged event handler
        public event PropertyChangedEventHandler? PropertyChanged;

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

    public class RestaurantDashboardMenuItem
    {
        public string? Name { get; set; }

        public bool IsSelected { get; set; }
    }
}