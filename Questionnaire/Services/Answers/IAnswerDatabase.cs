using Questionnaire.Models;

namespace Questionnaire.Services.Answers;

public interface IAnswerDatabase
{
    Task UpsertAnswer(Answer answer);
    Task<IDictionary<int, Answer>> GetAnswers(IEnumerable<Question> questions);
    Task<Answer> GetAnswer(int question);
}