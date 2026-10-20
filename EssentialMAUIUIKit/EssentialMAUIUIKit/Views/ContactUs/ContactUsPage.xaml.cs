namespace EssentialMAUIUIKit.Views.ContactUs
{
    public partial class ContactUsPage : ContentView
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }
        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            if (!string.IsNullOrEmpty(entry.Text))
            {
                string digitsOnly = new string(entry.Text.Where(char.IsDigit).ToArray());

                if (entry.Text != digitsOnly)
                    entry.Text = digitsOnly;
            }
        }
    }
}