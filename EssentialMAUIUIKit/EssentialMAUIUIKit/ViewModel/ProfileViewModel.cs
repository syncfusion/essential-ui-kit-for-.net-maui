using EssentialMAUIUIKit.Common;
using EssentialMAUIUIKit.Models;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// Lightweight view model that exposes a <see cref="Profile"/> instance to the
    /// social profile screens. The sample data is constructed by
    /// <see cref="ProfileSampleData"/> so that the view model itself can stay
    /// focused on exposing the model to the view layer.
    /// </summary>
    public class ProfileViewModel
    {
        /// <summary>
        /// Gets the profile data displayed by the social profile screens.
        /// </summary>
        public Profile Profile { get; }

        public ProfileViewModel()
        {
            Profile = ProfileSampleData.CreateSampleProfile();
        }
    }
}
