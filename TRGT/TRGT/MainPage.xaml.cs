namespace TRGT;

using System.IO;
using System.Reflection;
using TRGT.Experiments;
using TRGT.PluginCore;

public partial class MainPage : ContentPage
{

    public MainPage() => InitializeComponent();

    private void GoToExperiments(object sender, EventArgs e) =>
        App.ChangePage(new ExperimentsPage());
        //Navigation.PushAsync(new ExperimentsPage());
}
