namespace TRGT;

public partial class App : Application
{
    static App current = null;

    public App()
    {
        InitializeComponent();

        //MainPage = new NavigationPage(new MainPage());
        MainPage = new MainPage();
        UserAppTheme = OSAppTheme.Dark;
        current = this;
    }

    public static void ChangePage(Page page) => current.MainPage = page;
}
