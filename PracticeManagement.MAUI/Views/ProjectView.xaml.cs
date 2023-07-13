using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]

public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
	public ProjectView()
	{
		InitializeComponent();
    }

    
    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewViewModel(ClientId);
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ProjectDetails?clientId={ClientId}");
    }
}