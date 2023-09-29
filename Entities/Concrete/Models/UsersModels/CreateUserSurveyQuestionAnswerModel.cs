namespace Entities.Concrete.Models.UsersModels;

public class CreateUserSurveyQuestionAnswerModel
{
    public string UserId { get; set; }
    public long SurveyId { get; set; }
    public long SurveyQuestionId { get; set; }
    public long SurveyChoiceId { get; set; }
}
