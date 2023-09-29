using Entities.Concrete.DbEntities.Base;
using Entities.Concrete.DbEntities.Users;

namespace Entities.Concrete.DbEntities;

public class SurveyChoice : BaseEntity
{
    public string ChoiceName { get; set; }

    public long SurveyQuestionId { get; set; }
    public SurveyQuestion SurveyQuestion { get; set; }

    public ICollection<UserSurveyQuestionAnswer>? UserSurveyQuestionAnswers { get; set; }

}
