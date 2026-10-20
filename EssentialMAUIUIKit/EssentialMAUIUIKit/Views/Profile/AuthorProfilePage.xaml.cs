namespace EssentialMAUIUIKit.Views.Profile
{
    /// <summary>
    /// Content view that displays the author's profile (avatar, name,
    /// bio, phone number and regional settings.
    /// </summary>
    public partial class AuthorProfilePage : ContentView
    {
        public AuthorProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Detaches the binding context when the host view goes off-screen.
        /// Safe to call multiple times.
        /// </summary>
        public void DetachBindingContext()
        {
            BindingContext = null;
        } 
    }
}