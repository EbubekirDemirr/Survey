using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities;
using Entities.Concrete.Models.SurveyQuestionModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class SurveyQuestionManager : ISurveyQuestionService
{
    private readonly ISurveyQuestionRepository _surveyQuestionRepository;
    private readonly IMapper _mapper;

    public SurveyQuestionManager(ISurveyQuestionRepository surveyQuestionRepository, IMapper mapper)
    {
        _surveyQuestionRepository = surveyQuestionRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<SurveyQuestionViewModel>> CreateAsync(CreateSurveyQuestionModel model)
    {
        var mappedEntity = _mapper.Map<SurveyQuestion>(model);

        _surveyQuestionRepository.Add(mappedEntity);
        await _surveyQuestionRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyQuestionViewModel>(model);

        return new SuccessDataResult<SurveyQuestionViewModel>(mappedViewModel);
    }

    public async Task<IDataResult<SurveyQuestionViewModel>> UpdateAsync(UpdateSurveyQuestionModel model)
    {
        var mappedEntity = _mapper.Map<SurveyQuestion>(model);

        _surveyQuestionRepository.Update(mappedEntity);
        await _surveyQuestionRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyQuestionViewModel>(model);

        return new SuccessDataResult<SurveyQuestionViewModel>(mappedViewModel);
    }

    public async Task<IResult> DeleteAsync(DeleteSurveyQuestionModel model)
    {
        var mappedEntity = _mapper.Map<SurveyQuestion>(model);

        _surveyQuestionRepository.Delete(mappedEntity);
        await _surveyQuestionRepository.SaveChangesAsync();

        return new SuccessResult();
    }

    public IDataResult<SurveyQuestionViewModel> Get(long id)
    {
        return new SuccessDataResult<SurveyQuestionViewModel>(_mapper.Map<SurveyQuestionViewModel>(_surveyQuestionRepository.Get(x => x.Id == id)));
    }

    public async Task<IDataResult<SurveyQuestionViewModel>> GetAsync(long id)
    {
        return new SuccessDataResult<SurveyQuestionViewModel>(_mapper.Map<SurveyQuestionViewModel>(await _surveyQuestionRepository.GetAsync(x => x.Id == id)));
    }

    public IDataResult<List<SurveyQuestionViewModel>> GetList()
    {
        return new SuccessDataResult<List<SurveyQuestionViewModel>>(_mapper.Map<List<SurveyQuestionViewModel>>(_surveyQuestionRepository.GetList().ToList()));
    }

    public async Task<IDataResult<IEnumerable<SurveyQuestionViewModel>>> GetListAsync()
    {
        var data = await _surveyQuestionRepository.GetListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyQuestionViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyQuestionViewModel>>(mappedEntity);
    }

    public async Task<IDataResult<IEnumerable<SurveyQuestionViewModel>>> GetListWithDetailsAsync()
    {
        var data = await _surveyQuestionRepository.Query().AsNoTracking().ToListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyQuestionViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyQuestionViewModel>>(mappedEntity);
    }

    public Task<IDataResult<SurveyQuestionViewModel>> GetWithDetailsAsync(long id)
    {
        throw new NotImplementedException();
    }
}
