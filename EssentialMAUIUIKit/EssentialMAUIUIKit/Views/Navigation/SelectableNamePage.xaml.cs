
using Syncfusion.Maui.ListView;

namespace EssentialMAUIUIKit.Views.Navigation
{
    public partial class SelectableNamePage : ContentView
    {
        public SelectableNamePage()
        {
            InitializeComponent();
        }
        private void SfListView_SelectionChanging(
            object sender, ItemSelectionChangingEventArgs e)
        {
            foreach (var item in viewmodel.AlphabetFirst)
            {
                item.IsSelected = false;
            }

            if (e.AddedItems?.Count > 0 && e.AddedItems[0] is Contact contact)
            {
                contact.IsSelected = true;

                if (!string.IsNullOrEmpty(contact.Name))
                {
                    var letter = contact.Name[0].ToString().ToUpper();

                    label.Text = letter;
                    labelMobile.Text = letter;
                }
            }
        }
    }
}