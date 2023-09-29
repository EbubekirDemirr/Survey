using Entities.Concrete.DbEntities.Base;

namespace Entities.Concrete.Models.SurveyChoiceModels;

public class UpdateSurveyChoiceModel : BaseIdEntity
{
    public string ChoiceName { get; set; }
    public long QuestionId { get; set; }
}
