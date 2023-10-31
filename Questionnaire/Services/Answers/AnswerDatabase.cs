using Questionnaire.Models;

namespace Questionnaire.Services.Answers;

public class AnswerDatabase : IAnswerDatabase
{
    private readonly IDictionary<int, Answer> SavedAnswers = new Dictionary<int, Answer>();
        
    public Task UpsertAnswer(Answer answer)
    {
        SavedAnswers[answer.Question.Number] = answer;
        return Task.CompletedTask;
    }

    public Task<IDictionary<int, Answer>> GetAnswers(IEnumerable<Question> questions)
    {
        return Task.FromResult(SavedAnswers);
    }

    public Task<Answer> GetAnswer(int question)
    {
        return SavedAnswers.TryGetValue(question, out var previousAnswer) 
            ? Task.FromResult(previousAnswer) 
            : null;
    }
}