namespace EssentialMAUIUIKit.Models.Dashboard
{
    /// <summary>
    /// Model representing a single entry in the Company History timeline.
    /// </summary>
    public class CompanyHistoryData
    {
        /// <summary>
        /// Gets the ordinal position (1-based) of this entry in the timeline.
        /// Set by the view-model at construction time so that the value is deterministic
        /// and unaffected by collection lifetime or static state.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Gets or sets the year associated with the achievement.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the achievement description for the year.
        /// </summary>
        public string? Achievements { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the first entry in the timeline.
        /// </summary>
        public bool IsFirstItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the last entry in the timeline.
        /// </summary>
        public bool IsLastItem { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyHistoryData"/> class.
        /// </summary>
        /// <param name="index">The 1-based ordinal position of this entry in the timeline.</param>
        public CompanyHistoryData(int index)
        {
            this.Index = index;
        }
    }
}
