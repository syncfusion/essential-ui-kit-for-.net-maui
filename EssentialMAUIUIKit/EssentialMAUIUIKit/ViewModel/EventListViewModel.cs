using EssentialMAUIUIKit.Models.Catalog;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class EventListViewModel
    {
        public ObservableCollection<EventList> EventItems { get; set; }

        public EventListViewModel()
        {
            EventItems = new ObservableCollection<EventList>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""eventItems"": [
                {
                    ""eventDate"": ""24"",
                    ""eventMonth"": ""Dec"",
                    ""eventName"": ""Build Your Base, New York"",
                    ""eventTime"": ""2:00 PM - 6:00 PM"",
                    ""imagePath"": ""Event-Image-two.png"",
                    ""isPopular"": true
                },
                {
                    ""eventDate"": ""22"",
                    ""eventMonth"": ""Dec"",
                    ""eventName"": ""Ignite Music, New York"",
                    ""eventTime"": ""7:00 PM - 11:00 PM"",
                    ""imagePath"": ""Event-Image.png"",
                    ""isUpcoming"": true
                },
                {
                    ""eventDate"": ""27"",
                    ""eventMonth"": ""Dec"",
                    ""eventName"": ""John Weds Jane, New York"",
                    ""eventTime"": ""10:00 AM - 2:00 PM"",
                    ""imagePath"": ""Event-Image-three.png"",
                    ""isPopular"": true
                },
                {
                    ""eventDate"": ""23"",
                    ""eventMonth"": ""Dec"",
                    ""eventName"": ""BigSounds, New York"",
                    ""eventTime"": ""BigSounds, New York"",
                    ""imagePath"": ""Event-Image-one.png"",
                    ""isUpcoming"": true
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<EventsData>(jsonData, options);

            if (data?.EventItems == null)
            {
                return;
            }

            foreach (var eventItem in data.EventItems)
            {
                EventItems.Add(eventItem);
            }
        }
    }

    public class EventsData
    {
        public List<EventList>? EventItems { get; set; }
    }

}
