using Entities.Concrete.Models.SurveyChoiceModels;

namespace Entities.Concrete.Models.SurveyQuestionModels;

public class SurveyQuestionViewModel
{
    public string QuestionName { get; set; }
    public List<SurveyChoiceViewModel>? SurveyChoices { get; set; }
}
