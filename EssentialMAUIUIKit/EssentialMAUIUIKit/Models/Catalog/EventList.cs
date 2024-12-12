using Syncfusion.Maui.Toolkit.Buttons;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace EssentialMAUIUIKit.Models.Catalog
{
    /// <summary>
    /// Model for Event list page.
    /// </summary>
    [DataContract]
    public class EventList : INotifyPropertyChanged
    {
        #region Fields

        private string? imagePath;

        private Command? favouriteCommand;

        private bool isUpcoming;

        private bool isPopular;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the event image path.
        /// </summary>
        public string ImagePath
        {
            get { return App.ImageServerPath + this.imagePath; }
            set { this.imagePath = value; }
        }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string? EventName { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        public string? EventDate { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        public string? EventTime { get; set; }

        /// <summary>
        /// Gets or sets the event month.
        /// </summary>
        public string? EventMonth { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event in the list is popular or not.
        /// </summary>
        public bool IsPopular
        {
            get
            {
                return this.isPopular;
            }

            set
            {
                this.isPopular = value;
                this.NotifyPropertyChanged(nameof(this.IsPopular));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the upcoming event in the list is upcoming or not.
        /// </summary>
        public bool IsUpcoming
        {
            get
            {
                return this.isUpcoming;
            }

            set
            {
                this.isUpcoming = value;
                this.NotifyPropertyChanged(nameof(this.IsUpcoming));
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command FavouriteCommand
        {
            get
            {
                return this.favouriteCommand ?? (this.favouriteCommand = new Command(this.FavouriteButtonClicked));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the favourite button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void FavouriteButtonClicked(object obj)
        {
            var button = obj as SfButton;

            if (button == null || Application.Current == null)
            {
                return;
            }

            if (button.Text == "\ue701")
            {
                button.Text = "\ue732";
                Application.Current.Resources.TryGetValue("PrimaryColorLight", out var retVal);
                button.TextColor = (Color)retVal;
            }
            else
            {
                button.Text = "\ue701";
                Application.Current.Resources.TryGetValue("Gray-White", out var retVal);
                button.TextColor = (Color)retVal;
            }
        }

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
