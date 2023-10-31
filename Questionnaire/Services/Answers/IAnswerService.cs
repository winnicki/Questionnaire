using Questionnaire.Models;

namespace Questionnaire.Services.Answers;

public interface IAnswerService
{
    Task SaveAnswer(bool value, Question question);
    Task<IEnumerable<Answer>> GetAnswers(IEnumerable<Question> questions);
    Task<Answer> GetAnswer(Question question);
}