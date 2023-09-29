using Entities.Concrete.Models.SurveyQuestionModels;
using Entities.Concrete.Models.UsersModels;

namespace Entities.Concrete.Models.SurveyModels;

public class SurveyViewModel
{
    public string SurveyName { get; set; }

    public List<SurveyQuestionViewModel>? SurveyQuestions { get; set; }
    public UserViewModel User { get; set; }
}
