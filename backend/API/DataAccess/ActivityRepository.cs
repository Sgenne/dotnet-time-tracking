using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;

namespace API.DataAccess;

public class ActivityRepository : IActivityRepository
{
    private readonly DataContext _dataContext;

    public ActivityRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Result<Activity> AddActivity(Activity activity)
    {
        throw new NotImplementedException();
    }

    public Optional<Activity> GetActivityById(int activityId)
    {
        throw new NotImplementedException();
    }

    public List<Activity> GetActivityByProjectId(int projectId)
    {
        throw new NotImplementedException();
    }
}