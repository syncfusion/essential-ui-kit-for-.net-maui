namespace EssentialMAUIUIKit.Models.Dashboard
{
    /// <summary>
    /// Model representing a menu entry in the Company History left navigation rail.
    /// </summary>
    public class CompanyHistoryMenuItem
    {
        /// <summary>
        /// Gets or sets the display name of the menu item.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the icon glyph associated with the menu item (used for the tablet rail).
        /// </summary>
        public string? IconGlyph { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the menu item is currently selected.
        /// </summary>
        public bool IsSelected { get; set; }
    }
}
