using System.Collections.ObjectModel;
using Questionnaire.Models;
using Questionnaire.Services.Answers;
using Questionnaire.Services.Navigation;
using Questionnaire.Services.Questions;

namespace Questionnaire.ViewModels;

public class ResultsViewModel : ViewModelBase
{
    private readonly IQuestionService _questionService;
    private readonly IAnswerService _answerService;

    public ObservableCollection<Answer> Answers { get; } = new ();
    
    public ResultsViewModel(INavigationService navigationService, IQuestionService questionService, IAnswerService answerService) : base(navigationService)
    {
        _questionService = questionService;
        _answerService = answerService;
    }

    public override async Task InitializeAsync()
    {
        await base.InitializeAsync();

        var questionnaire = await _questionService.GetQuestionnaire();
        var answers = await _answerService.GetAnswers(questionnaire);

        foreach (var answer in answers.OrderBy(a => a.Question.Number))
        {
            Answers.Add(answer);
        }
    }
}