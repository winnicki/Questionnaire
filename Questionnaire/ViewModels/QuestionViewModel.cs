using System.Collections.Immutable;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
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

    private int _currentQuestion;
    private ImmutableArray<Question> _questions;

    private Question _question;
    public Question Question
    {
        get => _question;
        private set => SetProperty(ref _question, value);
    }

    public ICommand AnswerCommand { get; private set; }
    public ICommand PreviousCommand { get; private set; }
    public ICommand NextCommand { get; private set; }

    public QuestionViewModel(INavigationService navigationService, IQuestionService questionService, IAnswerService answerService) : base(navigationService)
    {
        _questionService = questionService;
        _answerService = answerService;
        
        AnswerCommand = new AsyncRelayCommand<bool>(SaveAnswer);
        PreviousCommand = new AsyncRelayCommand(GoPrevious);
        NextCommand = new AsyncRelayCommand(GoNext);
    }

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        _currentQuestion = query.ValueAsInt(nameof(Question.Number));
    }
    
    public override async Task InitializeAsync()
    {
        if (_currentQuestion == 1)
        {
            _questions = await _questionService.GetRandomQuestionnaire();
        }
        
        if (_currentQuestion > 0 && _currentQuestion < _questions.Length)
        {
            Question = _questions[0];
        }
    }
    
    private async Task SaveAnswer(bool value)
    {
        await _answerService.SaveAnswer(value, Question);
    }
    
    private async Task GoNext()
    {
        await NavigationService.NavigateToAsync(
            "/Question",
            new Dictionary<string, object> { { nameof(Models.Question.Number), Question.Number + 1 } });
    }

    private async Task GoPrevious()
    {
        await NavigationService.PopAsync();
    }
}