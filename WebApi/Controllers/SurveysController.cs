using Business.Abstract;
using Entities.Concrete.Models.SurveyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SurveysController : ControllerBase
{
    private readonly ISurveyService _SurveyService;

    public SurveysController(ISurveyService SurveyService)
    {
        _SurveyService = SurveyService;
    }

    [HttpPost()]
    [Route("create-survey")]
    public async Task<ActionResult<SurveyViewModel>> CreateAsync([FromBody] CreateSurveyModel model)
    {
        var result = await _SurveyService.CreateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut()]
    [Route("update-survey")]
    public async Task<ActionResult<SurveyViewModel>> UpdateAsync([FromBody] UpdateSurveyModel model)
    {
        var result = await _SurveyService.UpdateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete()]
    [Route("delete-survey")]
    public async Task<ActionResult> DeleteAsync([FromBody] DeleteSurveyModel model)
    {
        var result = await _SurveyService.DeleteAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-survey")]
    public async Task<ActionResult<SurveyViewModel>> GetAsync([FromQuery] long id)
    {
        var result = await _SurveyService.GetAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    [Route("get-list-survey")]
    public async Task<ActionResult<IEnumerable<SurveyViewModel>>> GetListAsync()
    {
        var result = await _SurveyService.GetListAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    [Route("get-list-with-details-survey")]
    public async Task<ActionResult<IEnumerable<SurveyViewModel>>> GetListWithDetailsAsync()
    {
        var result = await _SurveyService.GetListWithDetailsAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
