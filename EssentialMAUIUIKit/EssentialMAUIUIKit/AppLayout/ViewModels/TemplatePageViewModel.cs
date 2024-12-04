using EssentialMAUIUIKit.AppLayout.Models;
using EssentialMAUIUIKit.ViewModel;

namespace EssentialMAUIUIKit.AppLayout.ViewModels
{
    public class TemplatePageViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        private Category? selectedCategory;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        public Category? SelectedCategory
        {
            get => this.selectedCategory;
            set
            {
                if (TemplatePageViewModel.Equals(value, this.selectedCategory))
                {
                    return;
                }

                this.SetProperty(ref this.selectedCategory, value);
            }
        }

        #endregion
    }
}
