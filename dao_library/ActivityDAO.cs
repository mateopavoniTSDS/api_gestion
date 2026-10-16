namespace dao_library;
using entity_library;

public class ActivityDAO
{
    private readonly AppDbContext context;

    public ActivityDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Activity CreateActivity(Activity activity)
    {
        context.Activities.Add(activity);
        context.SaveChanges();
        return activity;
    }

    public Activity? GetActivityById(long id)
    {
        return context.Activities.FirstOrDefault(a => a.Id == id);
    }

    public List<Activity> GetAllActivities()
    {
        return context.Activities.ToList();
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
        context.SaveChanges();
        return true;
    }

    public bool DeleteActivityById(long id)
    {
        var existing = GetActivityById(id);
        if (existing == null)
        {
            return false;
        }

        context.Activities.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
