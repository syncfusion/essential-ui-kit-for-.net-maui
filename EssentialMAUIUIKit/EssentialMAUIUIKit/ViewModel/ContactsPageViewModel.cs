using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ContactsPageViewModel
    {
        public ObservableCollection<Contact> ContactsList { get; set; }

        public ContactsPageViewModel()
        {
            ContactsList = new ObservableCollection<Contact>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""contactsPageList"": [
                { ""name"": ""Aaron Thorsson"", ""backgroundColor"": ""#837bff"" },
                { ""name"": ""Alexander Allen"", ""backgroundColor"": ""#678cc8"" },
                { ""name"": ""Alta Sims"", ""backgroundColor"": ""#29aaa0"" },
                { ""name"": ""Ann Keller"", ""backgroundColor"": ""#db7faa"" },
                { ""name"": ""Arthur Kim"", ""backgroundColor"": ""#dc9737"" },
                { ""name"": ""Bernard Daniels"", ""backgroundColor"": ""#a8d35f"" },
                { ""name"": ""Bernard Rodriquez"", ""backgroundColor"": ""#ec5b76"" },
                { ""name"": ""Bettie Conlon"", ""backgroundColor"": ""#6c88ff"" },
                { ""name"": ""Blake Moore"", ""backgroundColor"": ""#cf62e2"" },
                { ""name"": ""Brandon Todd"", ""backgroundColor"": ""#f57780"" },
                { ""name"": ""Carlos Esteban"", ""backgroundColor"": ""#a8d35f"" },
                { ""name"": ""Charlotte Nash"", ""backgroundColor"": ""#ec5b76"" },
                { ""name"": ""Chase Blair"", ""backgroundColor"": ""#6c88ff"" },
                { ""name"": ""Christina Lloyd"", ""backgroundColor"": ""#cf62e2"" },
                { ""name"": ""Christina Hanson"", ""backgroundColor"": ""#f57780"" }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ContactsData>(jsonData, options);

            if (data?.ContactsPageList == null)
            {
                return;
            }

            foreach (var contact in data.ContactsPageList)
            {
                ContactsList.Add(contact);
            }
        }
    }

    public class Contact
    {
        public string? Name { get; set; }
        public string? BackgroundColor { get; set; }
    }

    public class ContactsData
    {
        public List<Contact>? ContactsPageList { get; set; }
    }

}
