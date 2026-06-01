namespace MergingtonHighSchool.Models;

/// <summary>
/// Response from signup endpoint
/// </summary>
public class SignupResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}
