using System.Collections.Immutable;
using Questionnaire.Extensions;
using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IQuestionDatabase _questionDatabase;
    private ImmutableArray<Question> _questions;

    public int QuestionnaireLength => _questions != null
        ? _questions.Length
        : 0;

    public Task<IEnumerable<Question>> GetQuestionnaire()
    {
        return Task.FromResult((IEnumerable<Question>)_questions);
    }

    public QuestionService(IQuestionDatabase questionDatabase)
    {
        _questionDatabase = questionDatabase;
    }
    
    public async Task GenerateQuestionnaire(int count = 10)
    {
        var questions = await _questionDatabase.GetQuestions();
        
        var number = 1;
        
        _questions = questions
            .Shuffle(new Random())
            .Select(q =>
            {
                q.Number = number++;
                return q;
            })
            .ToImmutableArray();
    }

    public Question GetQuestion(int number)
    {
        var index = number - 1;
        if (index >= 0 && index < _questions.Length)
        {
            return _questions[index];
        }
        return null;
    }
}