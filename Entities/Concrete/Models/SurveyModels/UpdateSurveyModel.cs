using Entities.Concrete.DbEntities.Base;

namespace Entities.Concrete.Models.SurveyModels;

public class UpdateSurveyModel : BaseIdEntity
{
    public string SurveyName { get; set; }
    public string UserId { get; set; }
}
