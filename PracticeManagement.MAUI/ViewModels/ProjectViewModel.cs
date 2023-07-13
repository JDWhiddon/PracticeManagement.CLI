using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticeManagement.Library.Services;
using PracticeManagement.CLI.Models;
using PracticeManagement.MAUI.Views;
using System.Windows.Input;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Project Model { get; set; }

        public ICommand AddOrUpdateCommand { get; private set; }
        public ICommand TimerCommand { get; private set; }

        public ICommand EditCommand { get; private set; }

        public string Display {
            get
            {
                return Model.ToString();
            }
        }

        private void ExecuteEdit() 
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ClientDetails?clientId={Model.ClientId}");
        }
        private void ExecuteAdd()
        {
            ProjectService.Current.AddOrUpdate(Model);
            Shell.Current.GoToAsync($"//ClientDetails?clientId={Model.ClientId}");
        }

        private void ExecuteTimer()
        {
            var window = new Window(new TimerView(Model.Id)) {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            Application.Current.OpenWindow(window);
        }

        public void SetUpCommands()
        {
            AddOrUpdateCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
        }
        
        public ProjectViewModel(int clientId)
        { 
            Model = new Project { ClientId = clientId };
            SetUpCommands();
        }

        public ProjectViewModel(int projectId, bool isProjectId)
        {
            Project project = ProjectService.Current.Get(projectId);
            Model = project;
            AddOrUpdateCommand = new Command(ExecuteEdit);
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            AddOrUpdateCommand = new Command(ExecuteEdit);
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetUpCommands();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
