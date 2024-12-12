using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using EssentialMAUIUIKit.AppLayout.Models;

namespace EssentialMAUIUIKit.AppLayout.ViewModels
{
    public class HomePageViewModel : Element, INotifyPropertyChanged
    {
        #region Fields

        private bool exitLoop = true;

        private const string SampleListFile = "EssentialMAUIUIKit.AppLayout.TemplateList.xml";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HomePageViewModel" /> class.
        /// </summary>
        public HomePageViewModel()
        {
            this.Categories = new List<Category>();
            this.Templates = new List<Template>();
            this.SearchList = new ObservableCollection<SearchModel>();
            this.PopulateList();
        }

        #endregion

        #region Bindable Properties

        /// <summary>
        /// 
        /// </summary>
        public static readonly BindableProperty SearchListProperty =
            BindableProperty.Create("SearchList", typeof(ObservableCollection<SearchModel>), typeof(HomePageViewModel), null);

        /// <summary>
        /// 
        /// </summary>
        public static readonly BindableProperty SearchTextProperty =
            BindableProperty.Create("SearchText", typeof(String), typeof(HomePageViewModel), null, BindingMode.TwoWay, null, OnSearchTextPropertyChanged);

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public String SearchText
        {
            get { return (String)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<SearchModel> SearchList
        {
            get { return (ObservableCollection<SearchModel>)GetValue(SearchListProperty); }
            set { SetValue(SearchListProperty, value); }
        }

        public List<Category> Categories { get; private set; }
        public List<Template> Templates { get; private set; }

        #endregion

        #region Events

        public new event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Property changed

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnSearchTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var searchText = newValue.ToString();

            if (bindable is HomePageViewModel sender && searchText != null)
            {
                if (searchText.Length < 2)
                {
                    if (sender.SearchList != null)
                    {
                        sender.SearchList.Clear();
                    }
                    return;
                }

                sender.exitLoop = true;
                sender.PopulateSearchItem(searchText);
            }
        }

        #endregion

        #region Methods
        internal bool CanShowSearchList()
        {
            if (this.SearchList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal void PopulateSearchItem(string searchText)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                this.exitLoop = true;
                this.PopulateSearchText(searchText);
            });
        }

        private void PopulateList()
        {
            this.Categories.Clear();

            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(SampleListFile);
            if (stream == null)
            {
                return;
            }

            using (var reader = new StreamReader(stream))
            {
#pragma warning disable CA2000 // Dispose objects before losing scope
                var xmlReader = XmlReader.Create(reader);
#pragma warning restore CA2000 // Dispose objects before losing scope
                xmlReader.Read();
                Category? category = null;
                var hasAdded = false;

                while (!xmlReader.EOF)
                {
                    switch (xmlReader.Name)
                    {
                        case "Category" when xmlReader.IsStartElement() && xmlReader.HasAttributes:
                            {
                                if (!hasAdded && category != null)
                                {
                                    this.Categories.Add(category);
                                    category = null;
                                    hasAdded = true;
                                }

                                var platform = GetDataFromXmlReader(xmlReader, "Platform");
                                if (string.IsNullOrEmpty(platform))
                                {
                                    var categoryName = GetDataFromXmlReader(xmlReader, "Name");
                                    var description = GetDataFromXmlReader(xmlReader, "Description");
                                    var icon = $"EssentialMAUIUIKit.AppLayout.Icons.{GetDataFromXmlReader(xmlReader, "Icon")}";
                                    category = new Category(categoryName, icon, description);
                                }

                                break;
                            }

                        case "Page" when xmlReader.IsStartElement() && xmlReader.HasAttributes && category != null:
                            {
                                var platform = GetDataFromXmlReader(xmlReader, "Platform");

                                if (string.IsNullOrEmpty(platform))
                                {
                                    var templateName = GetDataFromXmlReader(xmlReader, "Name");
                                    var description = GetDataFromXmlReader(xmlReader, "Description");
                                    var pageName = GetDataFromXmlReader(xmlReader, "PageName");

                                    var template = new Template(templateName, description, pageName);

                                    Routing.RegisterRoute(templateName, assembly.GetType($"EssentialMAUIUIKit.{pageName}"));

                                    category.Pages.Add(template);
                                    hasAdded = false;
                                }

                                break;
                            }
                    }

                    xmlReader.Read();
                }

                if (!hasAdded)
                {
                    if (category != null)
                    {
                        this.Categories.Add(category);
                    }
                }
            }
        }

        private static string GetDataFromXmlReader(XmlReader reader, string attribute)
        {
            if (reader != null)
            {
                reader.MoveToAttribute(attribute);
                return reader.Value;
            }

            return string.Empty;
        }

        private async void PopulateSearchText(string searchText)
        {
            await Task.Delay(searchText == string.Empty ? 40 : 0);
            // Ensure SearchList is initialized and cleared
            if (this.SearchList == null)
            {
                this.SearchList = new ObservableCollection<SearchModel>();
                this.OnPropertyRaised(nameof(SearchList));
            }
            else
            {
                this.SearchList.Clear();
            }

            exitLoop = false;
            foreach (var category in this.Categories)
            {
                if (ExitLoop()) return;
                var show = category.Pages?.Where(a => (a.Name!.ToLower().Contains(searchText, StringComparison.CurrentCultureIgnoreCase)));
                if (show == null)
                {
                    return;
                }

                IEnumerable<Template> templateList = show;
                if (templateList != null)
                {
                    if (ExitLoop()) return;
                    foreach (var samples in templateList)
                    {
                        if (ExitLoop()) return;
                        var searchModel = new SearchModel() { Category = category, Template = samples };
                        this.SearchList.Add(searchModel);
                        if (this.SearchList.Count % 5 == 0)
                            await Task.Delay(searchText == string.Empty ? 40 : 0);
                    }
                }
            }     
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private bool ExitLoop()
        {
            if (exitLoop)
            {
                if (this.SearchList != null)
                {
                    this.SearchList.Clear();
                }
            }

            return exitLoop;
        }

        #endregion
    }

    public class SearchModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Template? Template { get; set; }
    }
}
