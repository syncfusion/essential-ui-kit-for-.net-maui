using EssentialMAUIUIKit.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class HealthProfileViewModel
    {
        private string? profileImage;
        public ObservableCollection<HealthProfile> CardItems { get; set; }

        public string? ProfileImage
        {
            get { return App.ImageServerPath + this.profileImage; }
            set { this.profileImage = value; }
        }

        /// <summary>
        /// Gets or sets the profile name.
        /// </summary>
        public string? ProfileName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public string? Age { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public string? Weight { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public string? Height { get; set; }

        public HealthProfileViewModel()
        {
            CardItems = new ObservableCollection<HealthProfile>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"{""cardItems"": [
  {
    ""category"": ""Calories Eaten"",
    ""categoryValue"": ""13,100"",
    ""categoryImage"": ""CaloriesEaten.svg""
  },
  {
    ""category"": ""Heart Rate"",
    ""categoryValue"": ""87 BPM"",
    ""categoryImage"": ""HeartRate.svg""
  },
  {
    ""category"": ""Water Consumed"",
    ""categoryValue"": ""38.6 L"",
    ""categoryImage"": ""WaterConsumed.svg""
  },
  {
    ""category"": ""Sleep Duration"",
    ""categoryValue"": ""7.3 H"",
    ""categoryImage"": ""SleepDuration.svg""
  }
],

""profileImage"": ""ProfileImage16.png"",
""profileName"": ""Lela Cortez"",
""state"": ""San Francisco"",
""country"": ""CA"",
""age"": ""35"",
""weight"": ""159 Ibs"",
""height"": ""165 cm""}";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<HealthProfileData>(jsonData, options);

            var categoryImages = new List<string>() { "calorieseaten.png", "heartrate.png", "waterconsumed.png", "sleepduration.png" };

            if (data?.CardItems == null)
            {
                return;
            }

            for (int i = 0; i < data.CardItems.Count; i++)
            {
                data.CardItems[i].CategoryImage = categoryImages[i];
            }

            foreach (var cardItem in data.CardItems)
            {
                CardItems.Add(cardItem);
            }

            ProfileImage = data.ProfileImage;
            ProfileName = data.ProfileName;
            State = data.State;
            Country = data.Country;
            Age = data.Age;
            Weight = data.Weight;
            Height = data.Height;
        }
    }

    public class HealthProfileData
    {
        public ObservableCollection<HealthProfile>? CardItems { get; set; }
        public string? ProfileImage { get; set; }
        public string? ProfileName { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Age { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
    }
}
