using EssentialMAUIUIKit.Models.Catalog;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class TravelPlannerViewModel
    {
        public ObservableCollection<Travel> TravelPlacesList { get; set; }
        public ObservableCollection<Travel> TopDestinationsList { get; set; }
        public ObservableCollection<Travel> BestPlacesList { get; set; }

        public TravelPlannerViewModel()
        {
            TravelPlacesList = new ObservableCollection<Travel>();
            TopDestinationsList = new ObservableCollection<Travel>();
            BestPlacesList = new ObservableCollection<Travel>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""travelPlacesList"": [
                {
                    ""imagePath"": ""Surf-hotel-in-dubai.jpeg"",
                    ""place"": ""Dubai"",
                    ""details"": ""A melting pot of cultures, Dubai is the most advanced city in the Arab world. Lined with luxury resorts, there are activities for every interest, from camel racing to fossil cliffs to extravagant shopping opportunities.""
                },
                {
                    ""imagePath"": ""Mount-fuji.jpeg"",
                    ""place"": ""Mount Fuji"",
                    ""details"": ""Japan most famous, holy mountain dominates the landscape of three prefectures when you can see it. Fuji-san is shy and often obscured by clouds, but take the slow train through Shizuoka, or go shopping at the grand Gotemba outlet mall and you might get lucky""
                },
                {
                    ""imagePath"": ""London.jpeg"",
                    ""place"": ""London"",
                    ""details"": ""The bustling capital of the United Kingdom has enough historical landmarks, architectural beauties, and free museums to keep even the pickiest traveler occupied for days, if not weeks.""
                },
                {
                    ""imagePath"": ""Singapore.jpeg"",
                    ""place"": ""Singapore"",
                    ""details"": ""At only 725 sq. km., Singapore is one of the smallest countries in the world, but it packs a major punch in terms of reasons to visit.""
                }
            ],
            ""topDestinationsList"": [
                {
                    ""imagePath"": ""Venice.jpeg"",
                    ""place"": ""Venice, Italy"",
                    ""details"": ""Venice is arguably the most beautiful city in the world. The world seems to agree, sending 30 million tourists to walk its cobblestone streets, cross its ornate bridges, and sail down its elegant canals every year."",
                    ""price"": ""$1500""
                },
                {
                    ""imagePath"": ""Santorini-greece.jpeg"",
                    ""place"": ""Santorini, Greece"",
                    ""details"": ""The result of volcanic eruptions that devastated ancient civilizations, Santorini, locally known as Thira, is now a tourism must-do. The white buildings and blue roofs of Oia town are an icon of Greece itself."",
                    ""price"": ""$2000""
                },
                {
                    ""imagePath"": ""Salt-Pond-Bay-Thailand.jpeg"",
                    ""place"": ""Maya Beach, Thailand"",
                    ""details"": ""The crystal blue waters of this cove were made famous by the 2000 movie The Beach. Surrounded by dramatic cliffs and a white-sand beach, Maya Beach is a popular day trip."",
                    ""price"": ""$2500""
                },
                {
                    ""imagePath"": ""Gran-via-Valencia.jpeg"",
                    ""place"": ""Madrid, Spain"",
                    ""details"": ""The capital of Spain tends to be overlooked in favor of the colorful Barcelona, but this city has a glamor of its own."",
                    ""price"": ""$1700""
                }
            ],
            ""bestPlacesList"": [
                {
                    ""imagePath"": ""Salt-Pond-Bay-Thailand.jpeg"",
                    ""place"": ""Maya Bay, Thailand""
                },
                {
                    ""imagePath"": ""Gran-via-Valencia.jpeg"",
                    ""place"": ""Madrid, Spain""
                },
                {
                    ""imagePath"": ""Venice.jpeg"",
                    ""place"": ""Venice, Italy""
                },
                {
                    ""imagePath"": ""Santorini-greece.jpeg"",
                    ""place"": ""Santorini, Greece""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<TravelData>(jsonData, options);

            if (data?.TravelPlacesList == null)
            {
                return;
            }

            foreach (var travelPlace in data.TravelPlacesList)
            {
                TravelPlacesList.Add(travelPlace);
            }

            if (data?.TopDestinationsList == null)
            {
                return;
            }

            foreach (var topDestination in data.TopDestinationsList)
            {
                TopDestinationsList.Add(topDestination);
            }

            if (data?.BestPlacesList == null)
            {
                return;
            }

            foreach (var bestPlace in data.BestPlacesList)
            {
                BestPlacesList.Add(bestPlace);
            }
        }
    }

    public class TravelData
    {
        public List<Travel>? TravelPlacesList { get; set; }
        public List<Travel>? TopDestinationsList { get; set; }
        public List<Travel>? BestPlacesList { get; set; }
    }
}
