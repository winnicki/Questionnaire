using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Questionnaire.Services.Navigation;

namespace Questionnaire.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ICommand StartCommand { get; private set; }
    
    public MainViewModel(INavigationService navigationService) : base(navigationService)
    {
        StartCommand = new AsyncRelayCommand(StartQuestionnaire);
    }
    
    private async Task StartQuestionnaire()
    {
        await NavigationService.NavigateToAsync(
            "/Question",
            new Dictionary<string, object> { { nameof(Models.Question.Number), 1 } });
    }
}