using System.Collections.Immutable;
using Questionnaire.Extensions;
using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public class QuestionService : IQuestionService
{
    private readonly IQuestionDatabase _questionDatabase;
    
    public QuestionService(IQuestionDatabase questionDatabase)
    {
        _questionDatabase = questionDatabase;
    }
    
    public async Task<ImmutableArray<Question>> GetRandomQuestionnaire(int count = 10)
    {
        var questions = await _questionDatabase.GetQuestions();
        
        var number = 1;
        
        return questions
            .Shuffle(new Random())
            .Select(q =>
            {
                q.Number = number++;
                return q;
            })
            .ToImmutableArray();
    }
}