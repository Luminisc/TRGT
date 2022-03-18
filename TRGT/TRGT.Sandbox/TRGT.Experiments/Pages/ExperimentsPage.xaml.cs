namespace TRGT.Experiments;

public partial class ExperimentsPage : Shell
{
	public ExperimentsPage()
	{
		InitializeComponent();
        // Routing.RegisterRoute(nameof(Playground), typeof(Playground));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.GoToAsync($"//{nameof(AboutExperiments)}");
    }
}