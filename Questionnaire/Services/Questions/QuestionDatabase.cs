using Questionnaire.Models;

namespace Questionnaire.Services.Questions;

public class QuestionDatabase : IQuestionDatabase
{
    public Task<Question[]> GetQuestions()
    {
        return Task.FromResult(new []
        {
            new Question
            {
                Text = "Is SK cold in the winter?",
                CorrectAnswer = true
            },
            new Question
            {
                Text = "Is SK hot in the summer?",
                CorrectAnswer = true
            },
            new Question
            {
                Text = "Are the skies in SK dead?",
                CorrectAnswer = false
            },
            new Question
            {
                Text = "Is Montreal the largest city in Canada?",
                CorrectAnswer = false
            },
            new Question
            {
                Text = "Is Toronto the largest city in Canada?",
                CorrectAnswer = true
            },
            new Question
            {
                Text = "Is Vancouver the most expensive city in Canada?",
                CorrectAnswer = true
            },
            new Question
            {
                Text = "Is British Columbia ugly?",
                CorrectAnswer = false
            },
            new Question
            {
                Text = "Is .NET awesome?",
                CorrectAnswer = true
            },
            new Question
            {
                Text = "Is this questionnaire poorly built?",
                CorrectAnswer = false
            },
            new Question
            {
                Text = "Does Quebec deserve transfer payments from Alberta?",
                CorrectAnswer = false
            }
        });
    }
}