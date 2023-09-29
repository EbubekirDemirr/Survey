using Entities.Concrete.DbEntities.Base;

namespace Entities.Concrete.DbEntities.Users;

public class UserSurveyQuestionAnswer : BaseEntity
{
    public bool IsPollster { get; set; }

    public long? SurveyChoiceId { get; set; }
    public SurveyChoice? SurveyChoice { get; set; }

    public long SurveyQuestionId { get; set; }
    public SurveyQuestion SurveyQuestion { get; set; }

    public long? SurveyId { get; set; }
    public Survey? Survey { get; set; }

    public long? AnswerUserId { get; set; }
    public User? AnswerUser { get; set; }

}