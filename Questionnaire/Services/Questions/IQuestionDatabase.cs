using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public interface IQuestionDatabase
{
    Task<Question[]> GetQuestions();
}