using MergingtonHighSchool.Models;

namespace MergingtonHighSchool.Services;

/// <summary>
/// Service interface for managing extracurricular activities
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// Get all activities
    /// </summary>
    Dictionary<string, Activity> GetAllActivities();

    /// <summary>
    /// Sign up a student for an activity
    /// </summary>
    SignupResponse SignupForActivity(string activityName, string email);
}
