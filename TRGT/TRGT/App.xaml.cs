namespace TRGT;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
        UserAppTheme = OSAppTheme.Dark;
    }
}
