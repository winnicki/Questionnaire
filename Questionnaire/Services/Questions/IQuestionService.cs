using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public interface IQuestionService
{
    Task GenerateQuestionnaire(int count = 10);
    Question GetQuestion(int number);
    int QuestionnaireLength { get; }
}