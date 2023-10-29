using System.Collections.Immutable;
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

    private int _currentQuestion;
    private ImmutableArray<Question> _questions;
    
    public Question Question { get; set; }
    public Answer Answer { get; set; }

    public ICommand AnswerCommand { get; private set; }

    public QuestionViewModel(INavigationService navigationService, IQuestionService questionService, IAnswerService answerService) : base(navigationService)
    {
        _questionService = questionService;
        _answerService = answerService;
        AnswerCommand = new AsyncRelayCommand<bool>(SaveAnswer);
    }
    
    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        _currentQuestion = query.ValueAsInt(nameof(Question.Number));
    }
    
    public override async Task InitializeAsync()
    {
        _questions = await _questionService.GetRandomQuestionnaire();
        
        if (_currentQuestion > 0 && _currentQuestion < _questions.Length)
        {
            Question = _questions[0];
        }
    }
    
    private async Task SaveAnswer(bool value)
    {
        await _answerService.SaveAnswer(value, Question);
    }
}