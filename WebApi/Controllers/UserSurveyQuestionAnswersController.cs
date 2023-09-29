using Business.Abstract;
using Entities.Concrete.Models.UsersModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserSurveyQuestionAnswersController : ControllerBase
{
    private readonly IUserSurveyQuestionAnswerService _UserSurveyQuestionAnswerService;

    public UserSurveyQuestionAnswersController(IUserSurveyQuestionAnswerService UserSurveyQuestionAnswerService)
    {
        _UserSurveyQuestionAnswerService = UserSurveyQuestionAnswerService;
    }

    [HttpPost()]
    [Route("create-user-survey-question-answer")]
    public async Task<ActionResult<UserSurveyQuestionAnswerViewModel>> CreateAsync([FromBody] CreateUserSurveyQuestionAnswerModel model)
    {
        var result = await _UserSurveyQuestionAnswerService.CreateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut()]
    [Route("update-user-survey-question-answer")]
    public async Task<ActionResult<UserSurveyQuestionAnswerViewModel>> UpdateAsync([FromBody] UpdateUserSurveyQuestionAnswerModel model)
    {
        var result = await _UserSurveyQuestionAnswerService.UpdateAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete()]
    [Route("delete-user-survey-question-answer")]
    public async Task<ActionResult> DeleteAsync([FromBody] DeleteUserSurveyQuestionAnswerModel model)
    {
        var result = await _UserSurveyQuestionAnswerService.DeleteAsync(model);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-user-survey-question-answer")]
    public async Task<ActionResult<UserSurveyQuestionAnswerViewModel>> GetAsync([FromQuery] long id)
    {
        var result = await _UserSurveyQuestionAnswerService.GetAsync(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-user-survey-question-answer")]
    public async Task<ActionResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListAsync()
    {
        var result = await _UserSurveyQuestionAnswerService.GetListAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet()]
    [Route("get-list-with-details-user-survey-question-answer")]
    public async Task<ActionResult<IEnumerable<UserSurveyQuestionAnswerViewModel>>> GetListWithDetailsAsync()
    {
        var result = await _UserSurveyQuestionAnswerService.GetListWithDetailsAsync();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
