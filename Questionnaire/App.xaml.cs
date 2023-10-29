using Questionnaire.Services.Navigation;

namespace Questionnaire;

public partial class App : Application
{
    private readonly INavigationService _navigationService;

    public App(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeComponent();

        MainPage = new AppShell(navigationService);
    }
}