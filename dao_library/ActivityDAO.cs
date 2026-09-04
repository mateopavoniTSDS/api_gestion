namespace dao_library;
using entity_library;

public class ActivityDAO
{
    public Activity CreateActivity(Activity activity)
    {
        activity.Id = MockDatabase.Activities.Count + 1;
        MockDatabase.Activities.Add(activity);
        return activity;
    }

    public Activity? GetActivityById(long id)
    {
        return MockDatabase.Activities.FirstOrDefault(a => a.Id == id);
    }

    public List<Activity> GetAllActivities()
    {
        return MockDatabase.Activities;
    }

    public bool UpdateActivity(Activity activity)
    {
        var existing = GetActivityById(activity.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Title = activity.Title;
        existing.Description = activity.Description;
        existing.Date = activity.Date;
        existing.Type = activity.Type;
        existing.CourseId = activity.CourseId;
        return true;
    }

    public bool DeleteActivityById(long id)
    {
        var existing = GetActivityById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Activities.Remove(existing);
        return true;
    }
}
