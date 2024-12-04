using System.ComponentModel;

namespace EssentialMAUIUIKit.AppLayout.Models
{
    public class Template
    {
        #region Constructor

        public Template(string name, string description, string pageName)
        {
            this.Name = name;
            this.Description = description;
            this.PageName = pageName;
        }

        #endregion

        #region Properties

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? PageName { get; set; }

        #endregion
    }
}
