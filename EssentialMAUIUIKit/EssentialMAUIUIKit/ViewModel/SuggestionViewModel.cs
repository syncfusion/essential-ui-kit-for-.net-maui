using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class SuggestionViewModel
    {
        public ObservableCollection<Suggestion> SuggestionsList { get; set; }

        public SuggestionViewModel()
        {
            SuggestionsList = new ObservableCollection<Suggestion>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""suggestionList"": [
                { ""imagePath"": ""ProfileImage2.png"", ""suggestionName"": ""Alice Russell"", ""id"": ""@alice.russell"" },
                { ""imagePath"": ""ProfileImage3.png"", ""suggestionName"": ""Danielle Schneider"", ""id"": ""@danielle.schneider"" },
                { ""imagePath"": ""ProfileImage4.png"", ""suggestionName"": ""Jessica Park"", ""id"": ""@jessica.park"" },
                { ""imagePath"": ""ProfileImage5.png"", ""suggestionName"": ""Julia Grant"", ""id"": ""@julia.grant"" },
                { ""imagePath"": ""ProfileImage6.png"", ""suggestionName"": ""Kyle Greene"", ""id"": ""@kyle.greene"" },
                { ""imagePath"": ""ProfileImage7.png"", ""suggestionName"": ""Danielle Booker"", ""id"": ""@danielle.booker"" },
                { ""imagePath"": ""ProfileImage8.png"", ""suggestionName"": ""Jazmine Simmons"", ""id"": ""@jazmine.simmons"" },
                { ""imagePath"": ""ProfileImage9.png"", ""suggestionName"": ""Ira Membrit"", ""id"": ""@ira.membrit"" },
                { ""imagePath"": ""ProfileImage10.png"", ""suggestionName"": ""Serina Black"", ""id"": ""@serina.black"" },
                { ""imagePath"": ""ProfileImage11.png"", ""suggestionName"": ""Alise Valasquez"", ""id"": ""@alise.valasquez"" },
                { ""imagePath"": ""ProfileImage12.png"", ""suggestionName"": ""Allie Bellew"", ""id"": ""@allie.bellew"" },
                { ""imagePath"": ""ProfileImage13.png"", ""suggestionName"": ""Navya Sharma"", ""id"": ""@navya.sharma"" }
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
                SuggestionsList.Add(suggestion);
            }
        }
    }

    public class Suggestion
    {
        private string? imagePath;
        public string ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }

        public string? SuggestionName { get; set; }
        public string? Id { get; set; }
    }

    public class SuggestionsData
    {
        public List<Suggestion>? SuggestionList { get; set; }
    }

}
