using Core.Utilities.Results;
using Entities.Concrete.Models.UsersModels;

namespace Business.Abstract;

public interface IUserSurveyQuestionAnswerService
{
    Task<IDataResult<UserSurveyQuestionAnswerViewModel>> CreateAsync(CreateUserSurveyQuestionAnswerModel model);

    Task<IDataResult<UserSurveyQuestionAnswerViewModel>> UpdateAsync(UpdateUserSurveyQuestionAnswerModel model);

    Task<IResult> DeleteAsync(DeleteUserSurveyQuestionAnswerModel model);


    Task<IDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListAsync();

    Task<IDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListWithDetailsAsync();

    IDataResult<List<UserSurveyQuestionAnswerViewModel>> GetList();


    Task<IDataResult<UserSurveyQuestionAnswerViewModel>> GetAsync(long id);

    Task<IDataResult<UserSurveyQuestionAnswerViewModel>> GetWithDetailsAsync(long id);

    IDataResult<UserSurveyQuestionAnswerViewModel> Get(long id);
}