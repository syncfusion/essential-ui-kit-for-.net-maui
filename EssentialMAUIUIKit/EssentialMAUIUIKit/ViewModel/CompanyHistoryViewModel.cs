namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.ViewModel;
    using System.Collections.ObjectModel;
    using System.Globalization;

    public class CompanyHistoryViewModel : BaseViewModel
    {

        /// <summary>
        /// To update pages that can be navigated from dashboard.
        /// </summary>
        private ObservableCollection<CompanyHistoryMenuItem> menuItems;

        private ObservableCollection<CompanyHistoryData> companyHistoryDetails;

        public CompanyHistoryViewModel()
        {
            this.menuItems = new ObservableCollection<CompanyHistoryMenuItem>
            {
                new CompanyHistoryMenuItem { Name = "Dashboard" },                
                new CompanyHistoryMenuItem { Name = "About us", IsSelected = true },
                new CompanyHistoryMenuItem { Name = "Contact us" },
                new CompanyHistoryMenuItem { Name = "Settings" }
            };

            this.companyHistoryDetails = new ObservableCollection<CompanyHistoryData>
            {
                new CompanyHistoryData { Year = 2020, Achievements = "The Texas cedar Elm Vault is released, impressing vault enthusiasts with its height and oblique-based leaves"},
                new CompanyHistoryData { Year = 2018, Achievements = "The David Elm vault design receives an overhaul to further distinguish it from the american elm vault"},
                new CompanyHistoryData { Year = 2016, Achievements = "The Heartwood and sapwood vault add-ons are announced, introducing an unprecedented elements of modularity to elm vaults products"},
                new CompanyHistoryData { Year = 2014, Achievements = "Elm Vaults formed a strategic partnership with ROLT, enhancing its capabilities in cloud storage technology and expanding its customer base."},
            };
            this.companyHistoryDetails[0].IsFirstItem = true;
            this.companyHistoryDetails[this.companyHistoryDetails.Count - 1].IsLastItem = true;

            this.ProfileImage = "profileavatar.png";
            this.CompanyLogo = "companylogo.png";
            this.PageTitle = "Our History";
            this.PageDescription = "Elm vaults is the industry leader in wooden vault construction. For more than 80 years, people around the world have relied on us for vaults that are equal parts secure and aesthetically pleasing";
        }

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the company logo image path.
        /// </summary>
        public string CompanyLogo { get; set; }

        /// <summary>
        /// Gets or sets the value for Page title.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Gets or sets the value for Page description.
        /// </summary>
        public string PageDescription { get; set; }

        /// <summary>
        /// Gets the list of HealthCareMenuItems.
        /// </summary>
        public ObservableCollection<CompanyHistoryMenuItem> MenuItemList
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
        /// Gets the list of CompanyHistoryDetails.
        /// </summary>
        public ObservableCollection<CompanyHistoryData> CompanyHistoryDetails
        {
            get
            {
                return this.companyHistoryDetails;
            }

            private set
            {
                this.SetProperty(ref this.companyHistoryDetails, value);
            }
        }

        #endregion
    }

    public class CompanyHistoryMenuItem
    {
        public string? Name { get; set; }

        public bool IsSelected { get; set; }
    }

    public class CompanyHistoryData
    {
        private static int _autoIncrementValue = 0;

        public int Index { get; } = ++_autoIncrementValue; // Auto-increment logic

        public int Year { get; set; }

        public string? Achievements { get; set; }

        public bool IsLastItem { get; set; }

        public bool IsFirstItem { get; set; }

    }

    public class EvenOddConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                // Return true if even, false if odd
                return intValue % 2 == 0;
            }
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}