using System.Text.Json.Serialization;

namespace Questionnaire.Models;

public class Answer : BindableObject
{
    public Guid Id { get; set; }
    public bool Value { get; set; }
    
    // [JsonIgnore]
    public Question Question { get; set; }
}