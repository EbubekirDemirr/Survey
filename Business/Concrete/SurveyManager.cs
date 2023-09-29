using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities;
using Entities.Concrete.Models.SurveyModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class SurveyManager : ISurveyService
{
    private readonly ISurveyRepository _SurveyRepository;
    private readonly IMapper _mapper;

    public SurveyManager(ISurveyRepository SurveyRepository, IMapper mapper)
    {
        _SurveyRepository = SurveyRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<SurveyViewModel>> CreateAsync(CreateSurveyModel model)
    {
        var mappedEntity = _mapper.Map<Survey>(model);

        _SurveyRepository.Add(mappedEntity);
        await _SurveyRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyViewModel>(model);

        return new SuccessDataResult<SurveyViewModel>(mappedViewModel);
    }

    public async Task<IDataResult<SurveyViewModel>> UpdateAsync(UpdateSurveyModel model)
    {
        var mappedEntity = _mapper.Map<Survey>(model);

        _SurveyRepository.Update(mappedEntity);
        await _SurveyRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyViewModel>(model);

        return new SuccessDataResult<SurveyViewModel>(mappedViewModel);
    }

    public async Task<IResult> DeleteAsync(DeleteSurveyModel model)
    {
        var mappedEntity = _mapper.Map<Survey>(model);

        _SurveyRepository.Delete(mappedEntity);
        await _SurveyRepository.SaveChangesAsync();

        return new SuccessResult();
    }

    public IDataResult<SurveyViewModel> Get(long id)
    {
        return new SuccessDataResult<SurveyViewModel>(_mapper.Map<SurveyViewModel>(_SurveyRepository.Get(x => x.Id == id)));
    }

    public async Task<IDataResult<SurveyViewModel>> GetAsync(long id)
    {
        return new SuccessDataResult<SurveyViewModel>(_mapper.Map<SurveyViewModel>(await _SurveyRepository.GetAsync(x => x.Id == id)));
    }

    public IDataResult<List<SurveyViewModel>> GetList()
    {
        return new SuccessDataResult<List<SurveyViewModel>>(_mapper.Map<List<SurveyViewModel>>(_SurveyRepository.GetList().ToList()));
    }

    public async Task<IDataResult<IEnumerable<SurveyViewModel>>> GetListAsync()
    {
        var data = await _SurveyRepository.GetListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyViewModel>>(mappedEntity);
    }

    public async Task<IDataResult<IEnumerable<SurveyViewModel>>> GetListWithDetailsAsync()
    {
        var data = await _SurveyRepository.Query().AsNoTracking().Include(x=>x.SurveyQuestions).ThenInclude(x=>x.SurveyChoices).ToListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyViewModel>>(mappedEntity);
    }

    public Task<IDataResult<SurveyViewModel>> GetWithDetailsAsync(long id)
    {
        throw new NotImplementedException();
    }
}
