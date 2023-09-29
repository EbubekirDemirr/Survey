using Entities.Concrete.DbEntities.Base;
using Entities.Concrete.DbEntities.Users;

namespace Entities.Concrete.DbEntities;

public class Survey : BaseEntity
{
    public string SurveyName { get; set; }


    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<UserSurveyQuestionAnswer> UserSurveyQuestionAnswers { get; set; }
    public ICollection<SurveyQuestion> SurveyQuestions { get; set; }

}
