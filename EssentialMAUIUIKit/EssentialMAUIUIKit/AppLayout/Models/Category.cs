using System.Globalization;

namespace EssentialMAUIUIKit.AppLayout.Models
{
    public class Category
    {
        #region Constructor

        public Category(string name, string icon, string description)
        {
            this.Pages = new List<Template>();
            this.Name = name;
            this.Icon = icon;
            this.Description = description;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public List<Template> Pages { get; private set; }

        public string TemplateCount
        {
            get
            {
                return this.Pages.Count > 1 ? $"{this.Pages.Count.ToString(CultureInfo.InvariantCulture)} Templates" : $"{this.Pages.Count.ToString(CultureInfo.InvariantCulture)} Template";
            }
        }
        #endregion
    }
}
