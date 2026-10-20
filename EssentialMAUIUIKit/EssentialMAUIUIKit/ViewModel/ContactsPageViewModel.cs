using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ContactsPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> ContactsList { get; set; }
        public ObservableCollection<Contact> NamesListData { get; set; }

        public ObservableCollection<Contact> AlphabetFirst { get; set; }
        public ObservableCollection<Contact> AlphabetSecond { get; set; }
        public string CurrentLetter { get; set; }

        private String _selectedAlphabet = string.Empty;
        public String SelectedAlphabet
        {
            get => _selectedAlphabet;
            set
            {
                _selectedAlphabet = value;
                OnPropertyChanged();
            }
        }

        private readonly string[] groupColors =
            new[] { "#7633DA", "#2196F3", "#E2227E", "#F4890B" };
        public ContactsPageViewModel()
        {
            ContactsList = new ObservableCollection<Contact>();
            LoadData();
            var rawNames = new List<string> { "Aaron Thorsson",  "Alexander Allen",
                                        "Alta Sims",       "Ann Keller",
                                        "Bernard Daniels", "Bettie Keller",
                                        "Blake Todd",      "Brandan Tylore",
                                        "Carlos Esteban",  "Charlotte Nash",
                                        "Chase Blair",     "Christina Lloyd" };

            var coloredNames =
                rawNames.OrderBy(n => n)
                    .Select((name, index) =>
                                new { Name = name, Color = groupColors[index % 4] })
                    .ToDictionary(x => x.Name, x => x.Color);

            var groupedData =
                rawNames.OrderBy(n => n)
                    .GroupBy(n => char.ToUpper(n[0]))
                    .SelectMany(g => new List<Contact>() {
                new Contact { Name = g.Key.ToString(), IsHeader = true }
                    }.Concat(g.Select(name => new Contact
                    {
                        Name = name,
                        IsHeader = false,
                        Heading = GetInitials(name),
                        BackgroundColor = coloredNames[name]
                    })))
                    .ToList();
            AlphabetFirst = new ObservableCollection<Contact>();
            AlphabetSecond = new ObservableCollection<Contact>();
            CurrentLetter = "A";
            // First list: A to C (characters actually present in the data)
            for (char c = 'A'; c <= 'C'; c++)
            {
                // 'A' is the default heading on load
                AlphabetFirst.Add(new Contact
                {
                    Name = c.ToString(),
                    IsSelected = (c == 'A'),
                });
            }

            // Second list: D to Z (no contacts in the data — non-interactive)
            for (char c = 'D'; c <= 'Z'; c++)
            {
                AlphabetSecond.Add(new Contact { Name = c.ToString() });
            }
            SelectedAlphabet = AlphabetFirst.FirstOrDefault()?.Name ?? "A";
            NamesListData = new ObservableCollection<Contact>(groupedData);
        }
        private string GetInitials(string name)
        {
            var parts = name.Split(' ');
            if (parts.Length >= 2)
                return $"{char.ToUpper(parts[0][0])}{char.ToUpper(parts[1][0])}";
            return parts[0].Length > 0 ? parts[0][0].ToString() : "";
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private void LoadData()
        {
            string jsonData =
                @"
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

            var options =
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
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

    public class Contact : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string heading = string.Empty;
        private bool isSelected;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected == value)
                    return;

                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public string Heading
        {
            get => heading;
            set
            {
                heading = value;
                OnPropertyChanged();
            }
        }

        public string? BackgroundColor { get; set; }

        private bool isHeader;
        private bool isSingleHeader;

        public int GroupIndex { get; set; }

        public bool IsNonHeader => !IsHeader;
        public bool IsNonSingleHeader => !IsSingleHeader;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool IsHeader
        {
            get => isHeader;
            set
            {
                isHeader = value;
                OnPropertyChanged();
            }
        }
        public bool IsSingleHeader
        {
            get => isSingleHeader;
            set
            {
                isSingleHeader = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class ContactsData
    {
        public List<Contact>? ContactsPageList { get; set; }
    }
}