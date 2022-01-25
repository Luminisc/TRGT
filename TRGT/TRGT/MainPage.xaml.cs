namespace TRGT;

using System.IO;

public partial class MainPage : ContentPage
{
    int count = 0;
    public string ProcessPath { get; set; }

    public MainPage()
    {
        InitializeComponent();
        ProcessPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Environment.NewLine
            + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Environment.NewLine
            + Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Environment.NewLine
            + Environment.ProcessPath + Environment.NewLine
#if ANDROID
            + Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath + Environment.NewLine
#endif
            + Environment.CurrentDirectory;

        this.BindingContext = this;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
    }

    private void TestSaving(object sender, EventArgs e)
    {
        var pluginFolderPath = GetPluginsFolder();
        var filePath = Path.Combine(pluginFolderPath, "output.txt");

        Directory.CreateDirectory(pluginFolderPath);
        File.WriteAllText(filePath, "Hey! I'm writing!");

        ProcessPath = $"Saved file to: {filePath}";
        OnPropertyChanged(nameof(ProcessPath));
    }

    private string GetPluginsFolder()
    {
#if ANDROID
        var androidAppPath = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
        return Path.Combine(androidAppPath, "plugins");
#endif
#if WINDOWS
		return Path.Combine(Directory.GetParent(Environment.ProcessPath).FullName, "plugins");
#endif
        throw new PlatformNotSupportedException();
    }
}

