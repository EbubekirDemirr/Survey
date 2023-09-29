using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities.Users;
using Entities.Concrete.Models.UsersModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class UserSurveyQuestionAnswerManager : IUserSurveyQuestionAnswerService
{
    private readonly IUserSurveyQuestionAnswerRepository _UserSurveyQuestionAnswerRepository;
    private readonly IMapper _mapper;

    public UserSurveyQuestionAnswerManager(IUserSurveyQuestionAnswerRepository UserSurveyQuestionAnswerRepository, IMapper mapper)
    {
        _UserSurveyQuestionAnswerRepository = UserSurveyQuestionAnswerRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<UserSurveyQuestionAnswerViewModel>> CreateAsync(CreateUserSurveyQuestionAnswerModel model)
    {
        var mappedEntity = _mapper.Map<UserSurveyQuestionAnswer>(model);

        _UserSurveyQuestionAnswerRepository.Add(mappedEntity);
        await _UserSurveyQuestionAnswerRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<UserSurveyQuestionAnswerViewModel>(model);

        return new SuccessDataResult<UserSurveyQuestionAnswerViewModel>(mappedViewModel);
    }

    public async Task<IDataResult<UserSurveyQuestionAnswerViewModel>> UpdateAsync(UpdateUserSurveyQuestionAnswerModel model)
    {
        var mappedEntity = _mapper.Map<UserSurveyQuestionAnswer>(model);

        _UserSurveyQuestionAnswerRepository.Update(mappedEntity);
        await _UserSurveyQuestionAnswerRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<UserSurveyQuestionAnswerViewModel>(model);

        return new SuccessDataResult<UserSurveyQuestionAnswerViewModel>(mappedViewModel);
    }

    public async Task<IResult> DeleteAsync(DeleteUserSurveyQuestionAnswerModel model)
    {
        var mappedEntity = _mapper.Map<UserSurveyQuestionAnswer>(model);

        _UserSurveyQuestionAnswerRepository.Delete(mappedEntity);
        await _UserSurveyQuestionAnswerRepository.SaveChangesAsync();

        return new SuccessResult();
    }

    public IDataResult<UserSurveyQuestionAnswerViewModel> Get(long id)
    {
        return new SuccessDataResult<UserSurveyQuestionAnswerViewModel>(_mapper.Map<UserSurveyQuestionAnswerViewModel>(_UserSurveyQuestionAnswerRepository.Get(x => x.Id == id)));
    }

    public async Task<IDataResult<UserSurveyQuestionAnswerViewModel>> GetAsync(long id)
    {
        return new SuccessDataResult<UserSurveyQuestionAnswerViewModel>(_mapper.Map<UserSurveyQuestionAnswerViewModel>(await _UserSurveyQuestionAnswerRepository.GetAsync(x => x.Id == id)));
    }

    public IDataResult<List<UserSurveyQuestionAnswerViewModel>> GetList()
    {
        return new SuccessDataResult<List<UserSurveyQuestionAnswerViewModel>>(_mapper.Map<List<UserSurveyQuestionAnswerViewModel>>(_UserSurveyQuestionAnswerRepository.GetList().ToList()));
    }

    public async Task<IDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListAsync()
    {
        var data = await _UserSurveyQuestionAnswerRepository.GetListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<UserSurveyQuestionAnswerViewModel>>(data);
        return new SuccessDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>(mappedEntity);
    }

    public async Task<IDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListWithDetailsAsync()
    {
        var data = await _UserSurveyQuestionAnswerRepository.Query().AsNoTracking().ToListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<UserSurveyQuestionAnswerViewModel>>(data);
        return new SuccessDataResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>(mappedEntity);
    }

    public Task<IDataResult<UserSurveyQuestionAnswerViewModel>> GetWithDetailsAsync(long id)
    {
        throw new NotImplementedException();
    }
}
