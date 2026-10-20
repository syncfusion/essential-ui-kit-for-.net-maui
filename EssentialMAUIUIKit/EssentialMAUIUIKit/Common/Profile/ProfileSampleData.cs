using System.Text.Json;
using EssentialMAUIUIKit.Models;

namespace EssentialMAUIUIKit.Common
{
    /// <summary>
    /// Factory that produces a fully-populated <see cref="Profile"/> instance from the
    /// embedded sample JSON used by the social profile demo screens.
    /// </summary>
    /// <remarks>
    /// Keeping sample-data construction in a dedicated helper avoids mixing the
    /// view-model responsibilities with raw JSON and makes the data easier to
    /// evolve (e.g. swap to a different source for future samples) without
    /// touching the view model.
    /// </remarks>
    public static class ProfileSampleData
    {
        private const string SampleJson = @"
        {
            ""headerImagePath"": ""Album2.png"",
            ""profileImage"": ""ProfileImage16.png"",
            ""backgroundImage"": ""Sky-Image.png"",
            ""profileName"": ""Lela Cortez"",
            ""designation"": ""Designer"",
            ""state"": ""San Francisco"",
            ""country"": ""CA"",
            ""about"": ""I am a UMN graduate (go Gophers!) and Minnesota native, but I am already loving my new home in the Golden Gate City! I cant wait to explore more of the great music scene here."",
            ""postsCount"": 8,
            ""followersCount"": 45,
            ""followingCount"": 45,
            ""interests"": [
                { ""name"": ""Food"",    ""imagePath"": ""Recipe12.png"" },
                { ""name"": ""Travel"",  ""imagePath"": ""Album5.png"" },
                { ""name"": ""Music"",   ""imagePath"": ""ArticleImage7.jpg"" },
                { ""name"": ""Bags"",    ""imagePath"": ""Accessories.png"" },
                { ""name"": ""Market"",  ""imagePath"": ""PersonalCare.png"" },
                { ""name"": ""Food"",    ""imagePath"": ""Recipe12.png"" },
                { ""name"": ""Travel"",  ""imagePath"": ""Album5.png"" },
                { ""name"": ""Music"",   ""imagePath"": ""ArticleImage7.jpg"" },
                { ""name"": ""Bags"",    ""imagePath"": ""Accessories.png"" },
                { ""name"": ""Market"",  ""imagePath"": ""PersonalCare.png"" }
            ],
            ""connections"": [
                { ""name"": ""Rose King"",     ""imagePath"": ""ProfileImage7.png"" },
                { ""name"": ""Jeanette Bell"", ""imagePath"": ""ProfileImage9.png"" },
                { ""name"": ""Lily Castro"",   ""imagePath"": ""ProfileImage10.png"" },
                { ""name"": ""Susie Moss"",    ""imagePath"": ""ProfileImage11.png"" },
                { ""name"": ""Rose King"",     ""imagePath"": ""ProfileImage7.png"" },
                { ""name"": ""Jeanette Bell"", ""imagePath"": ""ProfileImage9.png"" },
                { ""name"": ""Lily Castro"",   ""imagePath"": ""ProfileImage10.png"" },
                { ""name"": ""Susie Moss"",    ""imagePath"": ""ProfileImage11.png"" }
            ],
            ""pictures"": [
                { ""imagePath"": ""ProfileImage8.png"" },
                { ""imagePath"": ""Album6.png"" },
                { ""imagePath"": ""ArticleImage4.jpg"" },
                { ""imagePath"": ""Recipe17.png"" },
                { ""imagePath"": ""ArticleImage5.jpg"" },
                { ""imagePath"": ""Mask.png"" }
            ]
        }";

        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Creates a sample <see cref="Profile"/> for the social demo screens.
        /// </summary>
        public static Profile CreateSampleProfile()
        {
            return JsonSerializer.Deserialize<Profile>(SampleJson, SerializerOptions)
                   ?? new Profile();
        }
    }
}
