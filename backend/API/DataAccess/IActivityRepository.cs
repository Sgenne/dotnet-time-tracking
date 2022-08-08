using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;

namespace API.DataAccess;

public interface IActivityRepository
{

    public Result<Activity> AddActivity(Activity activity);
    public Optional<Activity> GetActivityById(int activityId);
    public List<Activity> GetActivityByProjectId(int projectId);
}