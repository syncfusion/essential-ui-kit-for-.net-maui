using Syncfusion.Maui.ListView;

namespace EssentialMAUIUIKit.Views.Navigation
{
    public partial class ContactsPage : ContentView
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        private void SfListView_SelectionChanging(
            object sender,
            Syncfusion.Maui.ListView.ItemSelectionChangingEventArgs e)
        {
            if (sender is not SfListView listView)
                return;
            var AlphabetFirst = viewmodel.AlphabetFirst;
            // Clear previous selection
            foreach (var item in AlphabetFirst)
            {
                item.IsSelected = false;
            }

            // Set newly selected item
            if (e.AddedItems?.Count > 0)
            {
                if (e.AddedItems[0] is Contact contact)
                {
                    contact.IsSelected = true;
                    if (!string.IsNullOrEmpty(contact.Name))
                    {
                        label.Text = contact.Name[0].ToString().ToUpper();
                        labelMobile.Text = contact.Name[0].ToString().ToUpper();
                    }
                }
            }
        }
    }
}