using Microsoft.AspNetCore.Mvc;
using MergingtonHighSchool.Models;
using MergingtonHighSchool.Services;

namespace MergingtonHighSchool.Controllers;

/// <summary>
/// API controller for managing extracurricular activities
/// </summary>
[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;
    private readonly ILogger<ActivitiesController> _logger;

    public ActivitiesController(IActivityService activityService, ILogger<ActivitiesController> logger)
    {
        _activityService = activityService;
        _logger = logger;
    }

    /// <summary>
    /// Get all available activities
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetActivities()
    {
        var activities = _activityService.GetAllActivities();
        return Ok(activities);
    }

    /// <summary>
    /// Sign up a student for an activity
    /// </summary>
    /// <param name="name">The activity name</param>
    /// <param name="email">The student's email address</param>
    [HttpPost("{name}/signup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult SignUp(string name, [FromQuery] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            _logger.LogWarning("Signup attempt with empty email for activity: {ActivityName}", name);
            return BadRequest(new SignupResponse
            {
                Success = false,
                Message = "Email is required."
            });
        }

        if (!_activityService.GetAllActivities().ContainsKey(name))
        {
            return NotFound(new SignupResponse
            {
                Success = false,
                Message = "Activity not found."
            });
        }

        var result = _activityService.SignupForActivity(name, email);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
}
