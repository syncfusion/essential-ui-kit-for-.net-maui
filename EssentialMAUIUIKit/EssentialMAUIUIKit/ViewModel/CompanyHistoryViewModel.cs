namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.Models.Dashboard;
    using EssentialMAUIUIKit.ViewModel;
    using System.Collections.ObjectModel;

    /// <summary>
    /// View-model backing the Company History page.
    /// </summary>
    public class CompanyHistoryViewModel : BaseViewModel
    {
        #region Fields

        private readonly ObservableCollection<CompanyHistoryMenuItem> menuItems;
        private readonly ObservableCollection<CompanyHistoryData> companyHistoryDetails;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyHistoryViewModel"/> class.
        /// </summary>
        public CompanyHistoryViewModel()
        {
            this.menuItems = new ObservableCollection<CompanyHistoryMenuItem>
            {
                new CompanyHistoryMenuItem
                {
                    Name = "Dashboard",
                    IconGlyph = "\ue733"
                },
                new CompanyHistoryMenuItem
                {
                    Name = "About us",
                    IconGlyph = "\ue71b",
                    IsSelected = true
                },
                new CompanyHistoryMenuItem
                {
                    Name = "Contact Us",
                    IconGlyph = "\ue718"
                },
                new CompanyHistoryMenuItem
                {
                    Name = "Settings",
                    IconGlyph = "\ue716"
                }
            };

            // Build the timeline with explicit, deterministic 1-based indices so the
            // converters and IsFirstItem/IsLastItem flags remain correct regardless
            // of how many times the page is constructed during the app's lifetime.
            this.companyHistoryDetails = new ObservableCollection<CompanyHistoryData>
            {
                new CompanyHistoryData(1)
                {
                    Year = 2020,
                    Achievements = "The Texas cedar Elm Vault is released, impressing vault enthusiasts with its height and oblique-based leaves",
                    IsFirstItem = true
                },
                new CompanyHistoryData(2)
                {
                    Year = 2018,
                    Achievements = "The David Elm vault design receives an overhaul to further distinguish it from the american elm vault"
                },
                new CompanyHistoryData(3)
                {
                    Year = 2016,
                    Achievements = "The Heartwood and sapwood vault add-ons are announced, introducing an unprecedented elements of modularity to elm vaults products"
                },
                new CompanyHistoryData(4)
                {
                    Year = 2014,
                    Achievements = "Elm Vaults formed a strategic partnership with ROLT, enhancing its capabilities in cloud storage technology and expanding its customer base.",
                    IsLastItem = true
                }
            };

            this.ProfileImage = "profileavatar.png";
            this.CompanyLogo = "companylogo.png";
            this.PageTitle = "Our History";
            this.PageDescription = "Elm vaults is the industry leader in wooden vault construction. For more than 80 years, people around the world have relied on us for vaults that are equal parts secure and aesthetically pleasing";
        }

        #region Properties

        /// <summary>
        /// Gets the profile image path.
        /// </summary>
        public string ProfileImage { get; }

        /// <summary>
        /// Gets the company logo image path.
        /// </summary>
        public string CompanyLogo { get; }

        /// <summary>
        /// Gets the page title.
        /// </summary>
        public string PageTitle { get; }

        /// <summary>
        /// Gets the page description shown above the timeline.
        /// </summary>
        public string PageDescription { get; }

        /// <summary>
        /// Gets the list of menu items shown in the left navigation rail.
        /// </summary>
        public ObservableCollection<CompanyHistoryMenuItem> MenuItemList
        {
            get
            {
                return this.menuItems;
            }
        }

        /// <summary>
        /// Gets the list of timeline entries shown in the right content area.
        /// </summary>
        public ObservableCollection<CompanyHistoryData> CompanyHistoryDetails
        {
            get
            {
                return this.companyHistoryDetails;
            }
        }

        #endregion
    }
}