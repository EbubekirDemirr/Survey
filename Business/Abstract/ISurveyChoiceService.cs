using Core.Utilities.Results;
using Entities.Concrete.Models.SurveyChoiceModels;

namespace Business.Abstract;

public interface ISurveyChoiceService
{
    Task<IDataResult<SurveyChoiceViewModel>> CreateAsync(CreateSurveyChoiceModel model);

    Task<IDataResult<SurveyChoiceViewModel>> UpdateAsync(UpdateSurveyChoiceModel model);

    Task<IResult> DeleteAsync(DeleteSurveyChoiceModel model);


    Task<IDataResult<IEnumerable<SurveyChoiceViewModel>>> GetListAsync();

    Task<IDataResult<IEnumerable<SurveyChoiceViewModel>>> GetListWithDetailsAsync();

    IDataResult<List<SurveyChoiceViewModel>> GetList();


    Task<IDataResult<SurveyChoiceViewModel>> GetAsync(long id);

    Task<IDataResult<SurveyChoiceViewModel>> GetWithDetailsAsync(long id);

    IDataResult<SurveyChoiceViewModel> Get(long id);
}
