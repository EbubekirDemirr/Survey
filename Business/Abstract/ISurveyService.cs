using Core.Utilities.Results;
using Entities.Concrete.Models.SurveyModels;

namespace Business.Abstract;

public interface ISurveyService
{
    Task<IDataResult<SurveyViewModel>> CreateAsync(CreateSurveyModel model);

    Task<IDataResult<SurveyViewModel>> UpdateAsync(UpdateSurveyModel model);

    Task<IResult> DeleteAsync(DeleteSurveyModel model);


    Task<IDataResult<IEnumerable<SurveyViewModel>>> GetListAsync();

    Task<IDataResult<IEnumerable<SurveyViewModel>>> GetListWithDetailsAsync();

    IDataResult<List<SurveyViewModel>> GetList();


    Task<IDataResult<SurveyViewModel>> GetAsync(long id);

    Task<IDataResult<SurveyViewModel>> GetWithDetailsAsync(long id);

    IDataResult<SurveyViewModel> Get(long id);
}
