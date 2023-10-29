namespace Questionnaire.Models;

public class Question : BindableObject
{
    public int Number { get; set; }
    public string Text { get; set; }
    public bool CorrectAnswer { get; set; }
}