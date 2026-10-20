namespace EssentialMAUIUIKit.Views.Forms
{
    public partial class BusinessRegistrationForm : ContentView
    {
        public BusinessRegistrationForm()
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