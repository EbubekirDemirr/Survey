using Entities.Concrete.Models.SurveyChoiceModels;
using Entities.Concrete.Models.SurveyModels;
using Entities.Concrete.Models.SurveyQuestionModels;

namespace Entities.Concrete.Models.UsersModels;

public class UserSurveyQuestionAnswerViewModel
{
    public UserViewModel UserViewModel { get; set; }
    public SurveyViewModel SurveyViewModel { get; set; }
    public SurveyQuestionViewModel SurveyQuestionViewModel { get; set; }
    public SurveyChoiceViewModel SurveyChoiceViewModel { get; set; }
}
