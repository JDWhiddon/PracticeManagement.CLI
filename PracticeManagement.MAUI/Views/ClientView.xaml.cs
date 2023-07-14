using PracticeManagement.CLI.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;


public partial class ClientView : ContentPage
{

    public ClientView()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Delete();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Search();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetails");
    }
    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Edit();
    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).ShowProjects();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewModel).RefreshClientList();
    }
}
