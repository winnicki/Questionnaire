using Questionnaire.Services.Navigation;

namespace Questionnaire;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeRouting();
        InitializeComponent();
    }
    
    private static void InitializeRouting()
    {
        Routing.RegisterRoute("Main", typeof(MainView));
        Routing.RegisterRoute("Question", typeof(QuestionView));
    }
}