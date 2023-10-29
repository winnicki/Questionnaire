using Questionnaire.Services.Navigation;

namespace Questionnaire.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(INavigationService navigationService) : base(navigationService)
    {
    }
}