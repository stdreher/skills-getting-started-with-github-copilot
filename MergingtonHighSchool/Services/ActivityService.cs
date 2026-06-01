using MergingtonHighSchool.Models;

namespace MergingtonHighSchool.Services;

/// <summary>
/// Service for managing extracurricular activities
/// </summary>
public class ActivityService : IActivityService
{
    private readonly Dictionary<string, Activity> _activities;

    public ActivityService()
    {
        _activities = InitializeActivities();
    }

    public Dictionary<string, Activity> GetAllActivities()
    {
        return _activities;
    }

    public SignupResponse SignupForActivity(string activityName, string email)
    {
        if (!_activities.TryGetValue(activityName, out var activity))
        {
            return new SignupResponse
            {
                Success = false,
                Message = "Activity not found."
            };
        }

        if (activity.Participants.Contains(email))
        {
            return new SignupResponse
            {
                Success = false,
                Message = $"You are already signed up for {activityName}."
            };
        }

        if (activity.Participants.Count >= activity.MaxParticipants)
        {
            return new SignupResponse
            {
                Success = false,
                Message = $"Sorry, {activityName} is full. No more participants can be added."
            };
        }

        activity.Participants.Add(email);

        return new SignupResponse
        {
            Success = true,
            Message = $"You have successfully signed up for {activityName}!"
        };
    }

    private Dictionary<string, Activity> InitializeActivities()
    {
        return new Dictionary<string, Activity>
        {
            {
                "Chess Club", new Activity
                {
                    Name = "Chess Club",
                    Description = "Learn strategies and compete in chess tournaments",
                    Schedule = "Fridays, 3:30 PM - 5:00 PM",
                    MaxParticipants = 12,
                    Participants = new List<string> { "michael@mergington.edu", "daniel@mergington.edu" }
                }
            },
            {
                "Programming Class", new Activity
                {
                    Name = "Programming Class",
                    Description = "Learn programming fundamentals and build software projects",
                    Schedule = "Tuesdays and Thursdays, 3:30 PM - 4:30 PM",
                    MaxParticipants = 20,
                    Participants = new List<string> { "emma@mergington.edu", "sophia@mergington.edu" }
                }
            },
            {
                "Gym Class", new Activity
                {
                    Name = "Gym Class",
                    Description = "Physical education and sports activities",
                    Schedule = "Mondays, Wednesdays, Fridays, 2:00 PM - 3:00 PM",
                    MaxParticipants = 30,
                    Participants = new List<string> { "john@mergington.edu", "olivia@mergington.edu" }
                }
            },
            {
                "Debate Team", new Activity
                {
                    Name = "Debate Team",
                    Description = "Practice public speaking and structured debate",
                    Schedule = "Mondays, 3:45 PM - 5:00 PM",
                    MaxParticipants = 16,
                    Participants = new List<string> { "liam@mergington.edu", "ava@mergington.edu" }
                }
            },
            {
                "Art Workshop", new Activity
                {
                    Name = "Art Workshop",
                    Description = "Explore drawing, painting, and creative techniques",
                    Schedule = "Wednesdays, 3:30 PM - 5:00 PM",
                    MaxParticipants = 18,
                    Participants = new List<string> { "mia@mergington.edu", "noah@mergington.edu" }
                }
            },
            {
                "Science Club", new Activity
                {
                    Name = "Science Club",
                    Description = "Run experiments and discuss scientific discoveries",
                    Schedule = "Thursdays, 3:30 PM - 4:45 PM",
                    MaxParticipants = 22,
                    Participants = new List<string> { "ethan@mergington.edu", "isabella@mergington.edu" }
                }
            },
            {
                "Drama Society", new Activity
                {
                    Name = "Drama Society",
                    Description = "Acting, stage presence, and theater production",
                    Schedule = "Tuesdays, 4:00 PM - 5:30 PM",
                    MaxParticipants = 20,
                    Participants = new List<string> { "charlotte@mergington.edu", "james@mergington.edu" }
                }
            },
            {
                "Robotics Lab", new Activity
                {
                    Name = "Robotics Lab",
                    Description = "Build and program robots for school competitions",
                    Schedule = "Fridays, 4:00 PM - 5:30 PM",
                    MaxParticipants = 15,
                    Participants = new List<string> { "benjamin@mergington.edu", "amelia@mergington.edu" }
                }
            },
            {
                "Photography Club", new Activity
                {
                    Name = "Photography Club",
                    Description = "Learn composition, lighting, and photo editing",
                    Schedule = "Wednesdays, 2:30 PM - 4:00 PM",
                    MaxParticipants = 14,
                    Participants = new List<string> { "lucas@mergington.edu", "harper@mergington.edu" }
                }
            },
            {
                "Math Circle", new Activity
                {
                    Name = "Math Circle",
                    Description = "Solve challenging math puzzles and problems",
                    Schedule = "Tuesdays, 3:30 PM - 4:45 PM",
                    MaxParticipants = 25,
                    Participants = new List<string> { "henry@mergington.edu", "evelyn@mergington.edu" }
                }
            },
            {
                "Music Ensemble", new Activity
                {
                    Name = "Music Ensemble",
                    Description = "Rehearse songs and perform at school events",
                    Schedule = "Thursdays, 4:00 PM - 5:30 PM",
                    MaxParticipants = 24,
                    Participants = new List<string> { "jack@mergington.edu", "abigail@mergington.edu" }
                }
            },
            {
                "Environmental Club", new Activity
                {
                    Name = "Environmental Club",
                    Description = "Lead sustainability projects and campus cleanups",
                    Schedule = "Mondays, 2:45 PM - 4:00 PM",
                    MaxParticipants = 21,
                    Participants = new List<string> { "logan@mergington.edu", "ella@mergington.edu" }
                }
            },
            {
                "Creative Writing", new Activity
                {
                    Name = "Creative Writing",
                    Description = "Write short stories, poems, and peer feedback",
                    Schedule = "Fridays, 3:00 PM - 4:30 PM",
                    MaxParticipants = 17,
                    Participants = new List<string> { "alexander@mergington.edu", "scarlett@mergington.edu" }
                }
            }
        };
    }
}
