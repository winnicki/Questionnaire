using System.Collections.Immutable;
using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public interface IQuestionService
{
    Task<ImmutableArray<Question>> GetRandomQuestionnaire(int count = 10);
}