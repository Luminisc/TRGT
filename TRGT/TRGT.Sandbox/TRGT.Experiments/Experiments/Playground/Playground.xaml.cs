namespace TRGT.Experiments;

using System.Reflection;
using TRGT.PluginCore;

public partial class Playground : ContentPage
{
    private int count = 0;
    public string Logs { get; set; }

    public Playground()
    {
        InitializeComponent();
        Logs = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Environment.NewLine
            + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + Environment.NewLine
            + Environment.GetFolderPath(Environment.SpecialFolder.Personal) + Environment.NewLine
            + Environment.ProcessPath + Environment.NewLine
#if ANDROID
            + Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath + Environment.NewLine
#endif
            + Environment.CurrentDirectory;

        BindingContext = this;
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

        Logs = $"Saved file to: {filePath}";
        OnPropertyChanged(nameof(Logs));
    }

    private void TestLoading(object sender, EventArgs e)
    {
        var pluginFolderPath = GetPluginsFolder();
        var filePath = Path.Combine(pluginFolderPath, "TRGT.PluginTest.dll");

        var pluginAssembly = Assembly.LoadFile(filePath);
        var pluginType = pluginAssembly.GetTypes()
            .Where(x => x.IsPublic && !x.IsAbstract && typeof(IPlugin).IsAssignableFrom(x))
            .First();

        var pluginInstance = (IPlugin)Activator.CreateInstance(pluginType);

        var control = pluginInstance.GetView();
        componentsStack.Add(control);

        Logs = $"Loaded plugin: {pluginType.Name}{Environment.NewLine}"
            + $"Initialize: {pluginInstance.Initialize()}{Environment.NewLine}"
            + $"DemoName: {pluginInstance.GetName()}{Environment.NewLine}";
        OnPropertyChanged(nameof(Logs));
    }

    private static string GetPluginsFolder()
    {
        var gameFilesFolder = string.Empty;
#if ANDROID
        // /storage/emulated/0/Android/data/com.companyname.trgt/files
        var androidAppPath = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
        gameFilesFolder = androidAppPath;
#endif
#if WINDOWS
		gameFilesFolder = Directory.GetParent(Environment.ProcessPath).FullName;
#endif

        if (string.IsNullOrEmpty(gameFilesFolder))
        {
            throw new PlatformNotSupportedException();
        }

        return Path.Combine(gameFilesFolder, "plugins");
    }
}