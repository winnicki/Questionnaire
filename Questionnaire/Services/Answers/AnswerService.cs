using Questionnaire.Models;

namespace Questionnaire.Services.Answers;

public class AnswerService : IAnswerService
{
    private readonly IAnswerDatabase _answerDatabase;

    public AnswerService(IAnswerDatabase answerDatabase)
    {
        _answerDatabase = answerDatabase;
    }
    
    public Task SaveAnswer(bool value, Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException("Missing question during save of answer.");
        }
        
        var answer = new Answer
        {
            Id = Guid.NewGuid(),
            Value = value,
            Question = question
        };
        
        return _answerDatabase.UpsertAnswer(answer);
    }

    public async Task<IEnumerable<Answer>> GetAnswers(IEnumerable<Question> questions)
    {
        var savedAnswers = await _answerDatabase.GetAnswers(questions);
        return savedAnswers.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value);
    }
}