using Flunt.Notifications;

namespace LojaMVC.EndPoints;

public static class ProblemDetails
{
    public static Dictionary<string, string[]> ConvertProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications.GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }

}
