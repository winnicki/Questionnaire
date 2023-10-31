using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Questionnaire.Extensions;
using Questionnaire.Models;
using Questionnaire.Services.Answers;
using Questionnaire.Services.Navigation;
using Questionnaire.Services.Questions;

namespace Questionnaire.ViewModels;

public class QuestionViewModel : ViewModelBase
{
    private readonly IQuestionService _questionService;
    private readonly IAnswerService _answerService;

    private int _questionNumber;

    private Question _question;
    public Question Question
    {
        get => _question;
        private set => SetProperty(ref _question, value);
    }

    private bool _isFalseSelected;
    public bool IsFalseSelected
    {
        get => _isFalseSelected;
        private set => SetProperty(ref _isFalseSelected, value);
    }
    
    private bool _isTrueSelected;
    public bool IsTrueSelected
    {
        get => _isTrueSelected;
        private set => SetProperty(ref _isTrueSelected, value);
    }

    public IAsyncRelayCommand<bool> AnswerCommand { get; private set; }
    public ICommand PreviousCommand { get; private set; }
    public IAsyncRelayCommand NextCommand { get; private set; }

    public QuestionViewModel(INavigationService navigationService, IQuestionService questionService, IAnswerService answerService) : base(navigationService)
    {
        _questionService = questionService;
        _answerService = answerService;
        
        AnswerCommand = new AsyncRelayCommand<bool>(SaveAnswer);
        PreviousCommand = new AsyncRelayCommand(GoPrevious);
        NextCommand = new AsyncRelayCommand(GoNext, GoNextCanExecute);
    }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        _questionNumber = query.ValueAsInt(nameof(Question.Number));
    }
    
    public override async Task InitializeAsync()
    {
        if (_questionNumber == 1 && _questionService.QuestionnaireLength == 0)
        {
            await _questionService.GenerateQuestionnaire();
        }

        Question ??= _questionService.GetQuestion(_questionNumber);
        NextCommand.NotifyCanExecuteChanged();
        await LoadUsersAnswer();
    }

    private async Task LoadUsersAnswer()
    {
        var previousAnswer = await _answerService.GetAnswer(Question);
        if (previousAnswer != null)
        {
            IsFalseSelected = !previousAnswer.Value;
            IsTrueSelected = previousAnswer.Value;
        }
    }
    
    private async Task SaveAnswer(bool value)
    {
        IsFalseSelected = !value;
        IsTrueSelected = value;
        
        await _answerService.SaveAnswer(value, Question);
    }
    
    private async Task GoNext()
    {
        await NavigationService.NavigateToAsync(
            "/Question",
            new Dictionary<string, object> { { nameof(Models.Question.Number), Question.Number + 1 } });
    }

    private bool GoNextCanExecute()
    {
        return _questionService != null && Question?.Number < _questionService.QuestionnaireLength;
    }

    private async Task GoPrevious()
    {
        await NavigationService.PopAsync();
    }
}