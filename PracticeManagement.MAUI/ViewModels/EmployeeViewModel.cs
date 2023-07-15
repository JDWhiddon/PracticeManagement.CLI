using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PracticeManagement.Library.Services;
using PracticeManagement.CLI.Models;
using PracticeManagement.Library.Models;

namespace PracticeManagement.MAUI.ViewModels
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Employee>(EmployeeService.Current.ListOfEmployees);
                }
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(Query));
            }
        }

        public Client SelectedEmployee { get; set; }

        public void Delete()
        {
            if (SelectedEmployee == null)
            {
                return;
            }
            EmployeeService.Current.Delete(SelectedEmployee.Id);
            NotifyPropertyChanged("Employees");
        }

        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }
    }
}
