using System.ComponentModel;

namespace EssentialMAUIUIKit.ViewModel
{
    public class BaseViewModel
    {
        #region Fields

        private Command<object>? backButtonCommand;

        #endregion

        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        [Obsolete]
        public Command<object> BackButtonCommand
        {
            get
            {
                return this.backButtonCommand ?? (this.backButtonCommand = new Command<object>(this.BackButtonClicked));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged(string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.NotifyPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Invoked when an back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        [Obsolete]
        private void BackButtonClicked(object obj)
        {
            if (Application.Current?.MainPage == null)
            {
                return;
            }

            if (Device.RuntimePlatform == Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 1)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
            else if (Device.RuntimePlatform != Device.UWP && Application.Current.MainPage.Navigation.NavigationStack.Count > 0)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        #endregion
    }
}
