using Core.Utilities.Results;
using Entities.Concrete.Models.SurveyQuestionModels;

namespace Business.Abstract;

public interface ISurveyQuestionService
{
    Task<IDataResult<SurveyQuestionViewModel>> CreateAsync(CreateSurveyQuestionModel model);

    Task<IDataResult<SurveyQuestionViewModel>> UpdateAsync(UpdateSurveyQuestionModel model);

    Task<IResult> DeleteAsync(DeleteSurveyQuestionModel model);


    Task<IDataResult<IEnumerable<SurveyQuestionViewModel>>> GetListAsync();

    Task<IDataResult<IEnumerable<SurveyQuestionViewModel>>> GetListWithDetailsAsync();

    IDataResult<List<SurveyQuestionViewModel>> GetList();


    Task<IDataResult<SurveyQuestionViewModel>> GetAsync(long id);

    Task<IDataResult<SurveyQuestionViewModel>> GetWithDetailsAsync(long id);

    IDataResult<SurveyQuestionViewModel> Get(long id);
}
