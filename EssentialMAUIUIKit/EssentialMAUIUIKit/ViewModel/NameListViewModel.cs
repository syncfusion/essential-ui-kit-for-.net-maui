using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class NameListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NameInfo> NamesList { get; set; }
        public ObservableCollection<NameInfo> NamesListData { get; set; }
        public ObservableCollection<Contact> AlphabetFirst { get; set; }
        public ObservableCollection<Contact> AlphabetSecond { get; set; }
        public string CurrentLetter { get; set; }

        private string _selectedAlphabet = string.Empty;
        public string SelectedAlphabet
        {
            get => _selectedAlphabet;
            set
            {
                _selectedAlphabet = value;
                OnPropertyChanged();
            }
        }

        public NameListViewModel()
        {
            NamesList = new ObservableCollection<NameInfo>();
            LoadData();
            AlphabetFirst = new ObservableCollection<Contact>();
            AlphabetSecond = new ObservableCollection<Contact>();

            // First list: A to C (characters actually present in the data)
            for (char c = 'A'; c <= 'D'; c++)
            {
                // 'A' is the default heading on load
                AlphabetFirst.Add(new Contact
                {
                    Name = c.ToString(),
                    IsSelected = (c == 'A'),
                });
            }
            CurrentLetter = "A";
            // Second list: D to Z (no contacts in the data — non-interactive)
            for (char c = 'E'; c <= 'Z'; c++)
            {
                AlphabetSecond.Add(new Contact { Name = c.ToString() });
            }

            SelectedAlphabet = AlphabetFirst.FirstOrDefault()?.Name ?? "A";

            var rawNames = new List<string> { "Alora Elliot",      "Arden Noelle",
                                        "Austin Bradley",    "Aurelia Lilan",
                                        "Arthur Kim",        "Bernard Daniels",
                                        "Bernard Rodriquez", "Barden Daniel",
                                        "Brandan Todd",      "Charlotte Nash",
                                        "Carlos Esteban",    "Christina Hanson",
                                        "Camila Sage",       "Dustin Blake" };

            NamesListData = new ObservableCollection<NameInfo>(
                rawNames.OrderBy(n => n)
                    .GroupBy(n => char.ToUpper(n[0]))
                    .SelectMany(g => new NameInfo[] {
                new NameInfo { Name = g.Key.ToString(), IsHeader = true }
                    }.Concat(g.Select(name => new NameInfo
                    {
                        Name = name,
                        IsHeader = false
                    }))));
        }

        private void LoadData()
        {
            string jsonData =
                @"
        {
            ""namesListPage"": [
                { ""name"": ""Alora Elliot"" },
                { ""name"": ""Arden Noelle"" },
                { ""name"": ""Austin Bradley"" },
                { ""name"": ""Aurelia Lilan"" },
                { ""name"": ""Arthur Kim"" },
                { ""name"": ""Bernard Daniels"" },
                { ""name"": ""Bernard Rodriquez"" },
                { ""name"": ""Barden Daniel"" },
                { ""name"": ""Brandan Todd"" },
                { ""name"": ""Charlotte Nash"" },
                { ""name"": ""Carlos Esteban"" },
                { ""name"": ""Christina Hanson"" },
                { ""name"": ""Camila Sage"" },
                { ""name"": ""Dustin Blake"" }
            ]
        }";

            var options =
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<NamesData>(jsonData, options);

            if (data?.NamesListPage == null)
            {
                return;
            }

            foreach (var name in data.NamesListPage)
            {
                NamesList.Add(name);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class NameInfo : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private bool isHeader;
        private bool isSingleHeader;

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

    public class NamesData
    {
        public List<NameInfo>? NamesListPage { get; set; }
    }
}