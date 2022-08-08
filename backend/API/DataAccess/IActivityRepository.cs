using API.Domain;
using API.Utils.Optional;
using API.Utils.Result;

namespace API.DataAccess;

public interface IActivityRepository
{

    public Task<Result<Activity>> AddActivity(Activity activity);
    public Task<Optional<Activity>> GetActivityById(int activityId);
    public Task<IEnumerable<Activity>> GetActivityByProjectId(int projectId);
}