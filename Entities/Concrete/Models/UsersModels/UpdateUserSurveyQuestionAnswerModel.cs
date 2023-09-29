using Entities.Concrete.DbEntities.Base;

namespace Entities.Concrete.Models.UsersModels;

public class UpdateUserSurveyQuestionAnswerModel : BaseIdEntity
{
    public string UserId { get; set; }
    public long SurveyId { get; set; }
    public long SurveyQuestionId { get; set; }
    public long SurveyChoiceId { get; set; }
}
