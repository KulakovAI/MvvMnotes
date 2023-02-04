using Notes.Views;

namespace Notes;

public partial class App : Application
{
    public App()
    {
        MainPage = new NavigationPage(new NoteListPage());
    }

    protected override void OnStart()
    { }

    protected override void OnSleep()
    { }

    protected override void OnResume()
    { }
}
