using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete.DbEntities;
using Entities.Concrete.Models.SurveyChoiceModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;


public class SurveyChoiceManager : ISurveyChoiceService
{
    private readonly ISurveyChoiceRepository _SurveyChoiceRepository;
    private readonly IMapper _mapper;

    public SurveyChoiceManager(ISurveyChoiceRepository SurveyChoiceRepository, IMapper mapper)
    {
        _SurveyChoiceRepository = SurveyChoiceRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<SurveyChoiceViewModel>> CreateAsync(CreateSurveyChoiceModel model)
    {
        var mappedEntity = _mapper.Map<SurveyChoice>(model);

        _SurveyChoiceRepository.Add(mappedEntity);
        await _SurveyChoiceRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyChoiceViewModel>(model);

        return new SuccessDataResult<SurveyChoiceViewModel>(mappedViewModel);
    }

    public async Task<IDataResult<SurveyChoiceViewModel>> UpdateAsync(UpdateSurveyChoiceModel model)
    {
        var mappedEntity = _mapper.Map<SurveyChoice>(model);

        _SurveyChoiceRepository.Update(mappedEntity);
        await _SurveyChoiceRepository.SaveChangesAsync();

        var mappedViewModel = _mapper.Map<SurveyChoiceViewModel>(model);

        return new SuccessDataResult<SurveyChoiceViewModel>(mappedViewModel);
    }

    public async Task<IResult> DeleteAsync(DeleteSurveyChoiceModel model)
    {
        var mappedEntity = _mapper.Map<SurveyChoice>(model);

        _SurveyChoiceRepository.Delete(mappedEntity);
        await _SurveyChoiceRepository.SaveChangesAsync();

        return new SuccessResult();
    }

    public IDataResult<SurveyChoiceViewModel> Get(long id)
    {
        return new SuccessDataResult<SurveyChoiceViewModel>(_mapper.Map<SurveyChoiceViewModel>(_SurveyChoiceRepository.Get(x => x.Id == id)));
    }

    public async Task<IDataResult<SurveyChoiceViewModel>> GetAsync(long id)
    {
        return new SuccessDataResult<SurveyChoiceViewModel>(_mapper.Map<SurveyChoiceViewModel>(await _SurveyChoiceRepository.GetAsync(x => x.Id == id)));
    }

    public IDataResult<List<SurveyChoiceViewModel>> GetList()
    {
        return new SuccessDataResult<List<SurveyChoiceViewModel>>(_mapper.Map<List<SurveyChoiceViewModel>>(_SurveyChoiceRepository.GetList().ToList()));
    }

    public async Task<IDataResult<IEnumerable<SurveyChoiceViewModel>>> GetListAsync()
    {
        var data = await _SurveyChoiceRepository.GetListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyChoiceViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyChoiceViewModel>>(mappedEntity);
    }

    public async Task<IDataResult<IEnumerable<SurveyChoiceViewModel>>> GetListWithDetailsAsync()
    {
        var data = await _SurveyChoiceRepository.Query().AsNoTracking().Include(x => x.SurveyQuestion).ToListAsync();
        var mappedEntity = _mapper.Map<IEnumerable<SurveyChoiceViewModel>>(data);
        return new SuccessDataResult<IEnumerable<SurveyChoiceViewModel>>(mappedEntity);
    }

    public Task<IDataResult<SurveyChoiceViewModel>> GetWithDetailsAsync(long id)
    {
        throw new NotImplementedException();
    }
}
