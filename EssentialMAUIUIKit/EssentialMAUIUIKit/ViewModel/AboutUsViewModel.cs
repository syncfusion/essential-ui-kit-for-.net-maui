using EssentialMAUIUIKit.Models.About;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EssentialMAUIUIKit
{
    public class AboutUsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AboutUsModel>? employeeDetails;

        public AboutUsViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<AboutUsModel>? EmployeeDetails
        {
            get => employeeDetails;
            set
            {
                employeeDetails = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PopulateData()
        {
            EmployeeDetails = new ObservableCollection<AboutUsModel>
            {
                new AboutUsModel{ Image = "ProfileImage15.png", Designation = "Project Manager", EmployeeName = "Alice"},
                new AboutUsModel{ Image = "ProfileImage10.png", Designation = "Senior Manager", EmployeeName = "Jessica"},
                new AboutUsModel{ Image = "ProfileImage11.png", Designation = "Project Manager", EmployeeName = "Lisa"},
                new AboutUsModel{ Image = "ProfileImage12.png", Designation = "Project Manager", EmployeeName = "Rebecca"},
                new AboutUsModel{ Image = "ProfileImage3.png", Designation = "Project Manager", EmployeeName = "Alexander"},
                new AboutUsModel{ Image = "ProfileImage1.png", Designation = "Project Manager", EmployeeName = "Antony"},
                new AboutUsModel{ Image = "ProfileImage7.png", Designation = "Project Manager", EmployeeName = "Danielle"},
                new AboutUsModel{ Image = "ProfileImage6.png", Designation = "Project Manager", EmployeeName = "Kyle Greene"},
                new AboutUsModel{ Image = "ProfileImage13.png", Designation = "Project Manager", EmployeeName = "Navya"},
                new AboutUsModel{ Image = "ProfileImage14.png", Designation = "Project Manager", EmployeeName = "Roseline"},
            };
        }
    }
}
