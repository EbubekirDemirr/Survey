using Business.Abstract;
using Entities.Concrete.Models.SurveyChoiceModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;



[Route("api/[controller]")]
[ApiController]
public class SurveyChoicesController : ControllerBase
{
    private readonly ISurveyChoiceService _SurveyChoiceService;

    public SurveyChoicesController(ISurveyChoiceService SurveyChoiceService)
    {
        _SurveyChoiceService = SurveyChoiceService;
    }

    [HttpPost()]
    [Route("create-survey-choice")]
    public async Task<ActionResult<SurveyChoiceViewModel>> CreateAsync([FromBody] CreateSurveyChoiceModel model)
    {
        var result = await _SurveyChoiceService.CreateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut()]
    [Route("update-survey-choice")]
    public async Task<ActionResult<SurveyChoiceViewModel>> UpdateAsync([FromBody] UpdateSurveyChoiceModel model)
    {
        var result = await _SurveyChoiceService.UpdateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete()]
    [Route("delete-survey-choice")]
    public async Task<ActionResult> DeleteAsync([FromBody] DeleteSurveyChoiceModel model)
    {
        var result = await _SurveyChoiceService.DeleteAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-survey-choice")]
    public async Task<ActionResult<SurveyChoiceViewModel>> GetAsync([FromQuery] long id)
    {
        var result = await _SurveyChoiceService.GetAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-survey-choice")]
    public async Task<ActionResult<IEnumerable<SurveyChoiceViewModel>>> GetListAsync()
    {
        var result = await _SurveyChoiceService.GetListAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-with-details-survey-choice")]
    public async Task<ActionResult<IEnumerable<SurveyChoiceViewModel>>> GetListWithDetailsAsync()
    {
        var result = await _SurveyChoiceService.GetListWithDetailsAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
