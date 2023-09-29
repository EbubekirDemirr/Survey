using Entities.Concrete.DbEntities.Base;
using Entities.Concrete.DbEntities.Users;

namespace Entities.Concrete.DbEntities;

public class SurveyQuestion : BaseEntity
{
    public string QuestionName { get; set; }

    public long SurveyId { get; set; }
    public Survey Survey { get; set; }

    public ICollection<UserSurveyQuestionAnswer> UserSurveyQuestionAnswers { get; set; }
    public ICollection<SurveyChoice> SurveyChoices { get; set; }
}
