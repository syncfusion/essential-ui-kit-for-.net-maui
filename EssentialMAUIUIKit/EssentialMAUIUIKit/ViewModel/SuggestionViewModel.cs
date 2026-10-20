using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class SuggestionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SuggestionItem> SuggestionsList { get; set; }

        public Command<SuggestionItem> ToggleFollowCommand { get; set; }

        public SuggestionViewModel()
        {
            SuggestionsList = new ObservableCollection<SuggestionItem>();
            ToggleFollowCommand = new Command<SuggestionItem>(ToggleFollowStatus);
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""suggestionList"": [
                { ""imagePath"": ""ProfileImage2.png"", ""suggestionName"": ""Alice Russell"", ""id"": ""Alice"" },
                { ""imagePath"": ""ProfileImage3.png"", ""suggestionName"": ""Danielle Schneider"", ""id"": ""Danielle"" },
                { ""imagePath"": ""ProfileImage4.png"", ""suggestionName"": ""Jessica Park"", ""id"": ""Jessica"" },
                { ""imagePath"": ""ProfileImage5.png"", ""suggestionName"": ""Julia Grant"", ""id"": ""Julia"" },
                { ""imagePath"": ""ProfileImage6.png"", ""suggestionName"": ""Kyle Greene"", ""id"": ""Kyle"" },
                { ""imagePath"": ""ProfileImage7.png"", ""suggestionName"": ""Danielle Booker"", ""id"": ""Daniel"" },
                { ""imagePath"": ""ProfileImage8.png"", ""suggestionName"": ""Jazmine Simmons"", ""id"": ""Jazmine"" },
                { ""imagePath"": ""ProfileImage9.png"", ""suggestionName"": ""Ira Membrit"", ""id"": ""Ira"" },
                { ""imagePath"": ""ProfileImage10.png"", ""suggestionName"": ""Serina Black"", ""id"": ""Serina"" },
                { ""imagePath"": ""ProfileImage11.png"", ""suggestionName"": ""Alise Valasquez"", ""id"": ""Alise"" },
                { ""imagePath"": ""ProfileImage12.png"", ""suggestionName"": ""Allie Bellew"", ""id"": ""Allie"" },
                { ""imagePath"": ""ProfileImage13.png"", ""suggestionName"": ""Navya Sharma"", ""id"": ""Navya"" }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SuggestionsData>(jsonData, options);
            var images = new List<string>
            {
                "ProfileImage2.png",
                "ProfileImage3.png",
                "ProfileImage4.png",
                "ProfileImage5.png",
                "ProfileImage6.png",
                "ProfileImage7.png",
                "ProfileImage8.png",
                "ProfileImage9.png",
                "ProfileImage10.png",
                "ProfileImage11.png",
                "ProfileImage12.png",
                "ProfileImage13.png"
            };

            if (data?.SuggestionList == null)
            {
                return;
            }

            for (int i = 0; i < data.SuggestionList.Count; i++)
            {
                var suggestion = data.SuggestionList[i];
                suggestion.ImagePath = images[i];
                suggestion.IsRequested = (i == 1);
                SuggestionsList.Add(suggestion);
            }
        }

        private void ToggleFollowStatus(SuggestionItem item)
        {
            if (item != null)
            {
                item.IsRequested = !item.IsRequested;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class SuggestionItem : INotifyPropertyChanged
    {
        private string? imagePath;
        public string ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }

        public string? SuggestionName { get; set; }
        public string? Id { get; set; }

        private bool isRequested;
        public bool IsRequested
        {
            get { return isRequested; }
            set
            {
                if (isRequested != value)
                {
                    isRequested = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNotRequested));
                }
            }
        }

        public bool IsNotRequested => !IsRequested;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class SuggestionsData
    {
        public List<SuggestionItem>? SuggestionList { get; set; }
    }

}
