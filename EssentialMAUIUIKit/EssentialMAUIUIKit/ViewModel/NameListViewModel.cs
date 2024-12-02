using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class NameListViewModel
    {
        public ObservableCollection<NameInfo> NamesList { get; set; }

        public NameListViewModel()
        {
            NamesList = new ObservableCollection<NameInfo>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
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

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
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
    }

    public class NameInfo
    {
        public string? Name { get; set; }
    }

    public class NamesData
    {
        public List<NameInfo>? NamesListPage { get; set; }
    }

}
