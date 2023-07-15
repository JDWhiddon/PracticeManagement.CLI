using PracticeManagement.CLI.Models;
using PracticeManagement.MAUI.ViewModels;

namespace PracticeManagement.MAUI.Views;


public partial class TimerView : ContentPage
{
	public int projectId { get; set; }
	public TimerView(int projectId)
	{
		InitializeComponent();
		BindingContext = new TimerViewModel(projectId);
	}

    private void EnterTimeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//TimeEntryView");
    }
}