using Business.Abstract;
using Entities.Concrete.Models.SurveyQuestionModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class SurveyQuestionsController : ControllerBase
{
    private readonly ISurveyQuestionService _surveyQuestionService;

    public SurveyQuestionsController(ISurveyQuestionService surveyQuestionService)
    {
        _surveyQuestionService = surveyQuestionService;
    }

    [HttpPost()]
    [Route("create-survey-question")]
    public async Task<ActionResult<SurveyQuestionViewModel>> CreateAsync([FromBody] CreateSurveyQuestionModel model)
    {
        var result = await _surveyQuestionService.CreateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut()]
    [Route("update-survey-question")]
    public async Task<ActionResult<SurveyQuestionViewModel>> UpdateAsync([FromBody] UpdateSurveyQuestionModel model)
    {
        var result = await _surveyQuestionService.UpdateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete()]
    [Route("delete-survey-question")]
    public async Task<ActionResult> DeleteAsync([FromBody] DeleteSurveyQuestionModel model)
    {
        var result = await _surveyQuestionService.DeleteAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-survey-question")]
    public async Task<ActionResult<SurveyQuestionViewModel>> GetAsync([FromQuery] long id)
    {
        var result = await _surveyQuestionService.GetAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-survey-question")]
    public async Task<ActionResult<IEnumerable<SurveyQuestionViewModel>>> GetListAsync()
    {
        var result = await _surveyQuestionService.GetListAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-with-details-survey-question")]
    public async Task<ActionResult<IEnumerable<SurveyQuestionViewModel>>> GetListWithDetailsAsync()
    {
        var result = await _surveyQuestionService.GetListWithDetailsAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
