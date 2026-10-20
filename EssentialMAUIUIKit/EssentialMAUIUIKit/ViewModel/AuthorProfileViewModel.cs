using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// View model that backs the <see cref="Views.Profile.AuthorProfilePage"/>.
    /// Exposes the avatar, display name, bio, phone number, email, and the
    /// settings-panel commands as bindable properties so the page can react
    /// to changes (e.g. profile edits) and to user interactions.
    /// </summary>
    public class AuthorProfileViewModel : INotifyPropertyChanged
    {
        // ---- Demo data (replace with a data service in production) ----
        private const string DefaultProfileImageFileName = "ProfileImage1.png";
        private const string DefaultProfileName = "John Doe";
        private const string DefaultBio = "Just Ignore!";
        private const string DefaultPhoneNumber = "+1 (555) 123-4567";
        private const string DefaultEmail = "johndoe@gmail.com";

        // Composed once so the default URL is never duplicated in field
        // initializers and in <see cref="ResetToDefaults"/>.
        private static readonly string DefaultProfileImage =
            App.ImageServerPath + DefaultProfileImageFileName;

        private string profileImage = DefaultProfileImage;
        private string profileName = DefaultProfileName;
        private string bio = DefaultBio;
        private string phoneNumber = DefaultPhoneNumber;
        private string email = DefaultEmail;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Absolute URL of the avatar image.
        /// </summary>
        public string ProfileImage
        {
            get => profileImage;
            set => SetField(ref profileImage, value);
        }

        /// <summary>
        /// Display name shown in the personal-info card.
        /// </summary>
        public string ProfileName
        {
            get => profileName;
            set => SetField(ref profileName, value);
        }

        /// <summary>
        /// Short bio shown in the personal-info card.
        /// </summary>
        public string Bio
        {
            get => bio;
            set => SetField(ref bio, value);
        }

        /// <summary>
        /// Phone number shown in the personal-info card.
        /// </summary>
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetField(ref phoneNumber, value);
        }

        /// <summary>
        /// Email address shown in the personal-info card.
        /// </summary>
        public string Email
        {
            get => email;
            set => SetField(ref email, value);
        }

        /// <summary>
        /// Command raised when the user taps the avatar edit badge to
        /// change their photo. Intentionally a no-op shell that the host
        /// page can override via a service in production.
        /// </summary>
        public ICommand ChangeAvatarCommand { get; }

        /// <summary>
        /// Command raised when the user taps a settings panel item
        /// (Appearance, Calls &amp; meetings, Security &amp; privacy, Sign out).
        /// The command parameter is the destination key (string).
        /// </summary>
        public ICommand SettingsItemCommand { get; }

        public AuthorProfileViewModel()
        {
            ChangeAvatarCommand = new Command(OnChangeAvatar);
            SettingsItemCommand = new Command<string>(OnSettingsItemTapped);
        }

        /// <summary>
        /// Resets the profile fields to the demo values. Useful for
        /// "discard changes" actions.
        /// </summary>
        public void ResetToDefaults()
        {
            ProfileImage = DefaultProfileImage;
            ProfileName = DefaultProfileName;
            Bio = DefaultBio;
            PhoneNumber = DefaultPhoneNumber;
            Email = DefaultEmail;
        }

        private void OnChangeAvatar()
        {
            // No-op demo. In production, launch a media-picker here and
            // assign the resulting path to <see cref="ProfileImage"/>.
        }

        private void OnSettingsItemTapped(string? destination)
        {
            // No-op demo. In production, route to the matching page here.
            _ = destination;
        }

        /// <summary>
        /// Sets the backing field and raises <see cref="PropertyChanged"/>
        /// when the value actually changes.
        /// </summary>
        private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
