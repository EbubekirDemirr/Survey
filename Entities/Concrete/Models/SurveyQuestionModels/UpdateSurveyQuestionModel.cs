using Entities.Concrete.DbEntities.Base;

namespace Entities.Concrete.Models.SurveyQuestionModels;

public class UpdateSurveyQuestionModel : BaseIdEntity
{
    public string QuestionName { get; set; }
}
